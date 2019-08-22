﻿/*
 * User: Кузнецов Вадим (DikBSD)
 * Date: 15.08.2019
 * Time: 15:2
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;


using Core.Common;

using SharpZipLibWorker = Core.Common.SharpZipLibWorker;

namespace Core.Duplicator
{
    /// <summary>
    /// Одинаковые Автор(ы), Название и Одинаковый Id Книги (разделять по разным группам разные издания книг)
    /// </summary>
    class CompareAuthorBookTitleBookID
    {
        private CompareCommon _compComm = new CompareCommon();

        /// <summary>
        /// Хэширование fb2-файлов по ID книги в пределах одинаковых Авторов и Названий книги
        /// 5. Автор(ы), Название и Одинаковый Id Книги (разделять по разным группам разные издания книг)
        /// </summary
        /// <param name="bw">Экземплар фонового обработчика класса BackgroundWorker</param>
        /// <param name="e">Экземпляр класса DoWorkEventArgs</param>
        /// <param name="htBookTitleAuthors">Хэш Таблица с книгами по критерию одинаковости их Названия и Авторов</param>
        /// <param name="htWorkingBook">Хэш Таблица с книгами по критерию одинаковости их ID</param>
        public void FilesHashForBTAuthorsBookIDParser(ref BackgroundWorker bw, ref DoWorkEventArgs e,
                                                      Label StatusLabel, ProgressBar ProgressBar,
                                                      ref Hashtable htBookTitleAuthors, ref Hashtable htWorkingBook)
        {
            StatusLabel.Text += "Хэширование fb2-файлов по ID книги в пределах одинаковых Авторов и Названий книги...\r";
            ProgressBar.Maximum = htBookTitleAuthors.Count;
            ProgressBar.Value = 0;
            // генерация списка ключей хеш-таблицы (для удаления обработанного элемента таблицы)
            List<string> keyList = _compComm.makeSortedKeysForGroups(ref htBookTitleAuthors);
            // группировка книг по одинаковым Id Книги в пределах сгенерированных Групп книг одинаковых Авторов и по одинаковым Названиям
            int i = 0;
            foreach (string key in keyList) {
                // разбивка на группы для одинакового Id книги по Названию и по Авторам
                Hashtable AuthorsTitleBookID = FindDupForAuthorsTitleBookID(
                    ref bw, ref e, (FB2FilesDataInGroup)htBookTitleAuthors[key]
                );
                if (bw.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                foreach (FB2FilesDataInGroup fb2List in AuthorsTitleBookID.Values) {
                    if (!htBookTitleAuthors.ContainsKey(fb2List.Group))
                        htWorkingBook.Add(fb2List.Group, fb2List);
                    else {
                        FB2FilesDataInGroup fb2ListInGroup = (FB2FilesDataInGroup)htBookTitleAuthors[fb2List.Group];
                        fb2ListInGroup.AddRange(fb2List);
                    }
                }
                // удаление обработанной группы книг, сгруппированных по одинаковому названию
                htBookTitleAuthors.Remove(key);
                bw.ReportProgress(++i);
            }
        }

        /// <summary>
        /// Разбивка на группы для одинакового Id книги по Названию и по Авторам
        /// </summary
        /// <param name="bw">Экземплар фонового обработчика класса BackgroundWorker</param>
        /// <param name="e">Экземпляр класса DoWorkEventArgs</param>
        /// <param name="fb2Group">Экземпляр класса для хранения информации по одинаковым книгам в одной группе</param>
        private Hashtable FindDupForAuthorsTitleBookID(ref BackgroundWorker bw, ref DoWorkEventArgs e,
                                                       FB2FilesDataInGroup fb2Group)
        {
            // в fb2Group.Group - название группы (название книги у всех книг одинаковое, а пути - разные )
            // внутри fb2Group в BookData - данные на каждую книгу группы
            Hashtable ht = new Hashtable(new FB2CultureComparer());
            // 2 итератора для перебора всех книг группы. 1-й - только на текущий элемент группы, 2-й - скользящий на все последующие. т.е. iter2 = iter1+1
            for (int iter1 = 0; iter1 != fb2Group.Count; ++iter1) {
                if (bw.CancellationPending) {
                    e.Cancel = true;
                    return ht;
                }
                BookData bd1 = fb2Group[iter1]; // текущая книга
                FB2FilesDataInGroup fb2NewGroup = new FB2FilesDataInGroup();
                // перебор всех книг в группе, за исключением текущей
                for (int iter2 = iter1 + 1; iter2 != fb2Group.Count; ++iter2) {
                    // сравнение текущей книги со всеми последующими
                    BookData bd2 = fb2Group[iter2];
                    // Проверка ID книги на наличие и/или пустоту
                    _compComm.VerifyBookID(bd1);
                    _compComm.VerifyBookID(bd2);
                    if (bd1.Id.ToLower().Equals(bd2.Id.ToLower())) {
                        if (!fb2NewGroup.isBookExists(bd2.Path))
                            fb2NewGroup.Add(bd2);
                    }
                }
                if (fb2NewGroup.Count >= 1) {
                    // только для копий, а не для единичных книг
                    fb2NewGroup.Group = fb2Group.Group + " { " + bd1.Id.ToString() + " }";
                    fb2NewGroup.Insert(0, bd1);
                    if (!ht.ContainsKey(fb2NewGroup.Group))
                        ht.Add(fb2NewGroup.Group, fb2NewGroup);
                }
            }
            return ht;
        }

    }
}
