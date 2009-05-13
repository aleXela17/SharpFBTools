﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 07.05.2009
 * Time: 8:40
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;

namespace FB2.Genres
{
	/// <summary>
	/// Description of FB22Genres.
	/// </summary>
	public class FB22Genres
	{
		#region Закрытые данные класса
		private Dictionary<string, string> m_dFB22Genres = new Dictionary<string, string>();
		private string[] m_sFB22GenreCode = {
			"sf_history","sf_action","sf_epic","sf_heroic","sf_detective","sf_cyberpunk","sf_space","sf_social","sf_horror","sf_humor",
			"sf_fantasy","sf",
			
			"det_classic","det_police","det_action","det_irony","det_history","det_espionage","det_crime","det_political","det_maniac",
			"det_hard","thriller","detective",
			
			"prose_classic","prose_history","prose_contemporary","prose_counter","prose_rus_classic","prose_su_classics","prose_military",
			
			"love_contemporary","love_history","love_detective","love_short","love_erotica","love_sf",
			
			"adv_western","adv_history","adv_indian","adv_maritime","adv_geo","adv_animal","adventure",
			
			"child_tale","child_verse","child_prose","child_sf","child_det","child_adv","child_education","children",
			
			"poetry","dramaturgy",
			
			"antique_ant","antique_european","antique_russian","antique_east","antique_myths","antique",
			
			"sci_history","sci_psychology","sci_culture","sci_religion","sci_philosophy","sci_politics","sci_juris","sci_linguistic",
			"sci_medicine","sci_phys","sci_math","sci_chem","sci_biology","sci_tech","science",
			
			"comp_www","comp_programming","comp_hard","comp_soft","comp_db","comp_osnet","computers",
			
			"ref_encyc","ref_dict","ref_ref","ref_guide","reference",
			
			"nonf_biography","nonf_publicism","nonf_criticism","design","nonfiction",
			
			"religion_rel","religion_esoterics","religion_self","religion",
			
			"humor_anecdote","humor_prose","humor_verse","humor",
			
			"home_cooking","home_pets","home_crafts","home_entertain","home_health","home_garden","home_diy","home_sport","home_sex","home",
			
			"job_hunting","management","marketing","banking","stock","accounting","global_economy","economics","industries","org_behavior",
			"personal_finance","real_estate","popular_business","small_business","paper_work","economics_ref"
		};
		private string[] m_sFB22GenreNames = {
			"Альтернативная история","Боевая Фантастика","Эпическая Фантастика","Героическая фантастика","Детективная Фантастика","Киберпанк",
			"Космическая Фантастика","Социальная фантастика","Ужасы и Мистика","Юмористическая фантастика","Фэнтези","Научная Фантастика",
				
			"Классический Детектив","Полицейский Детектив","Боевики","Иронический Детектив","Исторический Детектив","Шпионский Детектив",
			"Криминальный Детектив","Политический детектив","Маньяки","Крутой Детектив","Триллеры","Детектив",
				
			"Классическая Проза","Историческая Проза","Современная Проза","Контркультура","Русская Классика","Советская Классика","Военная проза",
				
			"Современные Любовные Романы","Исторические Любовные Романы","Остросюжетные Любовные Романы","Короткие Любовные Романы","Эротика",
			"Любовная фантастика",
				
			"Вестерны","Исторические Приключения","Приключения - Индейцы","Морские Приключения", "Путешествия и География","Природа и Животные",
			"Приключения - Прочее",
			
			"Сказки","Детские Стихи","Детская Проза","Детская Фантастика","Детские Остросюжетные","Детские Приключения",
			"Детская Образовательная литература","Детское - Прочее",
				
			"Поэзия","Драматургия",
				
			"Античная Литература","Европейская Старинная Литература","Древнерусская Литература","Древневосточная Литература","Мифы. Легенды. Эпос",
			"Старинная Литература - Прочее",
				
			"История","Психология","Культурология","Религиоведение","Философия","Политика","Юриспруденция","Языкознание","Медицина",
			"Физика","Математика","Химия","Биология","Технические","Научно-образовательная - Прочее",
				
			"Интернет","Программирование","Компьютерное Железо","Программы","Базы данных","ОС и Сети","Компьютеры - Прочее",
			
			"Энциклопедии","Словари","Справочники","Руководства","Справочная Литература - Прочее",
				
			"Биографии и Мемуары","Публицистика","Критика","Искусство, Дизайн","Документальное - Прочее",
				
			"Религия","Эзотерика","Самосовершенствование","Религия и духовность - Прочее",
			
			"Анекдоты","Юмористическая Проза","Юмористические стихи","Юмор - Прочее",
			
			"Кулинария","Домашние Животные","Хобби, Ремесла","Развлечения","Здоровье","Сад и Огород","Сделай Сам","Спорт","Эротика, Секс",
			"Дом и Семья - Прочее",
			
			"Поиск работы, карьера","Управление, подбор персонала","Маркетинг, PR, реклама","Банковское дело","Ценные бумаги, инвестиции",
			"Бухучет, налогообложение, аудит","Внешнеэкономическая деятельность","Экономика","Отраслевые издания","Корпоративная культура",
			"Личные финансы","Недвижимость","О бизнесе популярно","Малый бизнес","Делопроизводство","Справочники"
		};
		#endregion
		
		public FB22Genres()
		{
			// инициализация словаря
			for( int i=0; i!= m_sFB22GenreCode.Length; ++i ) {
				m_dFB22Genres.Add(m_sFB22GenreCode[i], m_sFB22GenreNames[i] );
			}
		}
		
		#region Открытые методы класса
		public string GetFB22GenreName( string sGenreCode ) {
			if( !m_dFB22Genres.ContainsKey( sGenreCode ) ) return "";
			return m_dFB22Genres[sGenreCode];
		}
		#endregion
	}
}
