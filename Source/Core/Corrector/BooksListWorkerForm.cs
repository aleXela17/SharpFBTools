﻿/*
 * Сделано в SharpDevelop.
 * Пользователь: Вадим Кузнецов (DikBSD)
 * Дата: 03.08.2015
 * Время: 7:23
 * 
 */
using System;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Linq;

using Core.Common;

using EndWorkMode	= Core.Common.EndWorkMode;
using MiscListView	= Core.Common.MiscListView;

// enums
using EndWorkModeEnum		= Core.Common.Enums.EndWorkModeEnum;
using ResultViewCollumnEnum = Core.Common.Enums.ResultViewCollumnEnum;
using BooksWorkModeEnum		= Core.Common.Enums.BooksWorkModeEnum;

namespace Core.Corrector
{
	/// <summary>
	/// Сохранение/Загрузка списка обрабатываемых fb2 книг
	/// </summary>
	public partial class BooksListWorkerForm : Form
	{
		#region Закрытые данные класса
		private readonly BooksWorkModeEnum	m_WorkMode; // режим обработки книг
		private readonly string			m_FilePath			= string.Empty;
		private readonly TextBox		m_textBoxAddress	= new TextBox();
		private readonly ListView		m_listViewFB2Files	= new ListView();
		private readonly EndWorkMode	m_EndMode			= new EndWorkMode();
		
		private 		 int			m_LastSelectedItem	= -1; // выделенный итем, на котором закончилась обработка списка...
		
		private DateTime m_dtStart;
		private BackgroundWorker		m_bw = null; // фоновый обработчик
		#endregion
		
		public BooksListWorkerForm(
			BooksWorkModeEnum WorkMode, string FromFilePath, ListView listViewFB2Files,
			TextBox textBoxAddress, int LastSelectedItem )
		{
			InitializeComponent();
			m_FilePath			= FromFilePath;
			m_textBoxAddress	= textBoxAddress;
			m_listViewFB2Files	= listViewFB2Files;
			m_WorkMode			= WorkMode;
			m_LastSelectedItem	= LastSelectedItem;

			InitializeBackgroundWorker();
			
			if ( !m_bw.IsBusy )
				m_bw.RunWorkerAsync(); //если не занят, то запустить процесс
		}
		// =============================================================================================
		// 								ОТКРЫТЫЕ СВОЙСТВА
		// =============================================================================================
		#region Открытые свойства
		public virtual EndWorkMode EndMode {
			get { return m_EndMode; }
		}
		public virtual int LastSelectedItem {
			get { return m_LastSelectedItem; }
		}
		#endregion
		
		// =============================================================================================
		//			BACKGROUNDWORKER: ОБРАБОТКА ФАЙЛОВ
		// =============================================================================================
		#region BackgroundWorker: Обработка файлов
		private void InitializeBackgroundWorker() {
			// Инициализация перед использование BackgroundWorker
			m_bw = new BackgroundWorker();
			m_bw.WorkerReportsProgress		= true; // Позволить выводить прогресс процесса
			m_bw.WorkerSupportsCancellation	= true; // Позволить отменить выполнение работы процесса
			m_bw.DoWork 			+= new DoWorkEventHandler( bw_DoWork );
			m_bw.ProgressChanged 	+= new ProgressChangedEventHandler( bw_ProgressChanged );
			m_bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler( bw_RunWorkerCompleted );
		}
		
		// Обработка файлов
		private void bw_DoWork( object sender, DoWorkEventArgs e ) {
			m_dtStart = DateTime.Now;
			ProgressBar.Value = 0;
			switch ( m_WorkMode ) {
				case BooksWorkModeEnum.SaveFB2List:
					this.Text = "Сохранение списка fb2 книг";
					saveListToXml( ref m_bw, ref e, m_FilePath );
					break;
				case BooksWorkModeEnum.LoadFB2List:
					this.Text = "Загрузка списка fb2 книг";
					loadListFromXML( ref m_bw, ref e, m_FilePath );
					break;
				default:
					return;
			}

			if ( ( m_bw.CancellationPending ) ) {
				e.Cancel = true;
				return;
			}
//			m_listViewFB2Files.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		
		// Отображение результата
		private void bw_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			++ProgressBar.Value;
		}
		
		// Проверяем - это отмена, ошибка, или конец задачи и сообщить
		private void bw_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
			DateTime dtEnd = DateTime.Now;
			string sTime = dtEnd.Subtract( m_dtStart ).ToString() + " (час.:мин.:сек.)";
			if ( e.Cancelled ) {
				m_EndMode.EndMode = EndWorkModeEnum.Cancelled;
				m_EndMode.Message = "Работа прервана и не выполнена до конца!\nЗатрачено времени: "+sTime;
			} else if ( e.Error != null ) {
				m_EndMode.EndMode = EndWorkModeEnum.Error;
				m_EndMode.Message = "Ошибка:\n" + e.Error.Message + "\n" + e.Error.StackTrace + "\nЗатрачено времени: "+sTime;
			} else {
				m_EndMode.EndMode = EndWorkModeEnum.Done;
				m_EndMode.Message = "Обработка fb2-файлов завершена!\nЗатрачено времени: "+sTime;
//				if ( m_lvResult.Items.Count == 0 )
//					m_EndMode.Message += "\n\nНе найдено НИ ОДНОЙ копии книг!";
			}
			this.Close();
		}
		#endregion
		
		// =============================================================================================
		// 				СОХРАНЕНИЕ В XML И ЗАГРУЗКА ИЗ XML СПИСКА FB2 КНИГ
		// =============================================================================================
		#region Сохранение в xml и Загрузка из xml списка fb2 книг
		
		#region Сохранение в xml списка fb2 книг
		// сохранение списка книг в xml-файл
		private void saveListToXml( ref BackgroundWorker bw, ref DoWorkEventArgs e, string ToFileName ) {
			XElement xeBooks = null;
			XDocument doc = new XDocument(
				new XDeclaration("1.0", "utf-8", "yes"),
				new XComment("Файл обрабатывакмых fb2 книг, сохраненный после полного окончания работы Редактора Метаданных (режим Проводник)"),
				new XElement("Files", new XAttribute("type", "metaeditor_explorer"),
				             new XComment("Папка для обработки fb2 книг"),
				             new XElement("SourceDir", m_textBoxAddress.Text.Trim()),
				             new XComment("Список обрабатываемых книг"),
				             xeBooks = new XElement("Books", new XAttribute("count", "0")),
				             new XComment("Выделенный элемент списка, на котором завершили обработку книг"),
				             new XElement("SelectedItem", m_LastSelectedItem.ToString() )
				            )
			);

			if ( m_listViewFB2Files.Items.Count > 0 ) {
				ProgressBar.Maximum	= m_listViewFB2Files.Items.Count;
				int BookCount = 0;
				int FileNumber = 0;
				int i = 0;
				foreach ( ListViewItem lvi in m_listViewFB2Files.Items ) {
					ListViewItemType it = (ListViewItemType)lvi.Tag;
					// в список - только существующие на диске книги и каталоги
					bool IsExist = false;
					if ( it.Type == "f" )
						IsExist = File.Exists( it.Value ) ? true : false;
					else
						IsExist = Directory.Exists( it.Value) ? true : false;
					if ( IsExist ) {
						doc.Root.Element("Books").Add(
							new XElement("Book",
							             new XAttribute("number", ++FileNumber),
							             new XAttribute("type", it.Type == "f" ? "file" : "dir"),
							             new XAttribute("path", it.Value),
							             new XElement("FileName", lvi.SubItems[(int)ResultViewCollumnEnum.Path].Text),
							             new XElement("BookTitle", lvi.SubItems[(int)ResultViewCollumnEnum.BookTitle].Text),
							             new XElement("Authors", lvi.SubItems[(int)ResultViewCollumnEnum.Authors].Text),
							             new XElement("Genres", lvi.SubItems[(int)ResultViewCollumnEnum.Genres].Text),
							             new XElement("Sequence", lvi.SubItems[(int)ResultViewCollumnEnum.Sequences].Text),
							             new XElement("Lang", lvi.SubItems[(int)ResultViewCollumnEnum.Lang].Text),
							             new XElement("BookID", lvi.SubItems[(int)ResultViewCollumnEnum.BookID].Text),
							             new XElement("Version", lvi.SubItems[(int)ResultViewCollumnEnum.Version].Text),
							             new XElement("Encoding", lvi.SubItems[(int)ResultViewCollumnEnum.Encoding].Text),
							             new XElement("Validation", lvi.SubItems[(int)ResultViewCollumnEnum.Validate].Text),
							             new XElement("Format", lvi.SubItems[(int)ResultViewCollumnEnum.Format].Text),
							             new XElement("FileLength", lvi.SubItems[(int)ResultViewCollumnEnum.FileLength].Text),
							             new XElement("FileCreationTime", lvi.SubItems[(int)ResultViewCollumnEnum.CreationTime].Text),
							             new XElement("FileLastWriteTime", lvi.SubItems[(int)ResultViewCollumnEnum.LastWriteTime].Text),
							             new XElement("ForeColor", lvi.ForeColor.Name),
							             new XElement("BackColor", lvi.BackColor.Name),
							             new XElement("IsChecked", lvi.Checked)
							            )
						);
						xeBooks.SetAttributeValue( "count", ++BookCount );
					}
					bw.ReportProgress( ++i );
				}
			}
			doc.Save(ToFileName);
		}
		#endregion
		
		#region Загрузка из xml списка fb2 книг
		// загрузка из xml-файла в хэш таблицу данных о копиях книг
		private void loadListFromXML( ref BackgroundWorker bw, ref DoWorkEventArgs e, string FromXML ) {
			XElement xmlTree = XElement.Load( FromXML );
			if ( xmlTree != null ) {
				XElement xmlBooks = xmlTree.Element("Books");
				if ( xmlBooks != null ) {
					ProgressBar.Maximum	= Convert.ToInt32( xmlBooks.Attribute("count").Value );
					// устанавливаем данные настройки поиска-сравнения
					m_textBoxAddress.Text = xmlTree.Element("SourceDir").Value;
					// перебор книг
					int i = 0;
					ListViewItem lvi = null;
					IEnumerable<XElement> Books = xmlBooks.Elements("Book");
					foreach ( XElement book in Books ) {
						if ( ( bw.CancellationPending ) )  {
							e.Cancel = true;
							return;
						}
						string BookPath = book.Attribute("path").Value;
						string type = book.Attribute("type").Value;
						// в список - только существующие на диске книги и каталоги
						bool IsExist = false;
						if ( type == "dir" )
							IsExist = Directory.Exists( BookPath ) ? true : false;
						else
							IsExist = File.Exists( BookPath) ? true : false;
						if ( IsExist ) {
							string FileName = book.Element("FileName").Value;
							string sForeColor = book.Element("ForeColor").Value;
							string sBackColor = book.Element("BackColor").Value;
							if ( type == "dir" ) {
								if ( FileName == ".." ) {
									lvi = new ListViewItem( FileName, 3 ) ;
									lvi.Tag = new ListViewItemType( "dUp", BookPath );
								} else {
									lvi = new ListViewItem( FileName, 0 ) ;
									lvi.Tag = new ListViewItemType( "d", BookPath );
								}
							} else {
								lvi = new ListViewItem( FileName, FilesWorker.isFB2File( BookPath ) ? 1 : 2 );
								lvi.Tag = new ListViewItemType( "f", BookPath );
							}
							lvi.ForeColor = Color.FromName( sForeColor );
							lvi.BackColor = Color.FromName( sBackColor );
							lvi.SubItems.Add( book.Element("BookTitle").Value );
							lvi.SubItems.Add( book.Element("Authors").Value );
							lvi.SubItems.Add( book.Element("Genres").Value );
							lvi.SubItems.Add( book.Element("Sequence").Value );
							lvi.SubItems.Add( book.Element("Lang").Value );
							lvi.SubItems.Add( book.Element("BookID").Value );
							lvi.SubItems.Add( book.Element("Version").Value );
							lvi.SubItems.Add( book.Element("Encoding").Value );
							lvi.SubItems.Add( book.Element("Validation").Value );
							lvi.SubItems.Add( book.Element("Format").Value );
							lvi.SubItems.Add( book.Element("FileLength").Value );
							lvi.SubItems.Add( book.Element("FileCreationTime").Value );
							lvi.SubItems.Add( book.Element("FileLastWriteTime").Value );
							lvi.Checked = Convert.ToBoolean( book.Element("IsChecked").Value );
							m_listViewFB2Files.Items.Add( lvi );
						}
						bw.ReportProgress( ++i );
					}
					m_LastSelectedItem = Convert.ToInt32( xmlTree.Element("SelectedItem").Value );
					MiscListView.SelectedItemEnsureVisible(m_listViewFB2Files, m_LastSelectedItem == -1 ? 0 : m_LastSelectedItem );
				}
			}
		}
		#endregion
		
		#endregion
		
		// =============================================================================================
		// 								ОБРАБОТЧИКИ СОБЫТИЙ
		// =============================================================================================
		#region Обработчики событий
		// нажатие кнопки прерывания работы
		void BtnStopClick(object sender, EventArgs e)
		{
			if ( m_bw.WorkerSupportsCancellation )
				m_bw.CancelAsync();
		}
		#endregion
		
	}
}
