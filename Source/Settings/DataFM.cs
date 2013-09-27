﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 14.05.2009
 * Time: 22:19
 * 
 * * License: GPL 2.1
 */
using System;

namespace Settings
{
	/// <summary>
	/// Description of DataFM.
	/// </summary>
	public class DataFM
	{
		#region Закрытые данные класса
		// названия папки для тэга. у которого нет данных
		private string m_sNoGenreGroup	= SettingsFM.ReadFMNoGenreGroup();
		private string m_sNoGenre		= SettingsFM.ReadFMNoGenre();
		private string m_sNoLang		= SettingsFM.ReadFMNoLang();
		private string m_sNoFirstName	= SettingsFM.ReadFMNoFirstName();
		private string m_sNoMiddleName	= SettingsFM.ReadFMNoMiddleName();
		private string m_sNoLastName	= SettingsFM.ReadFMNoLastName();
		private string m_sNoNickName	= SettingsFM.ReadFMNoNickName();
		private string m_sNoBookTitle	= SettingsFM.ReadFMNoBookTitle();
		private string m_sNoSequence	= SettingsFM.ReadFMNoSequence();
		private string m_sNoNSequence	= SettingsFM.ReadFMNoNSequence();
		private string m_sNoDateText	= SettingsFM.ReadFMNoDateText();
		private string m_sNoDateValue	= SettingsFM.ReadFMNoDateValue();
		private string m_sNoYear		= SettingsFM.ReadFMNoYear();
		private string m_sNoPublisher	= SettingsFM.ReadFMNoPublisher();
		private string m_sNoCity		= SettingsFM.ReadFMNoCity();
		private string m_sNoFB2FirstName		= SettingsFM.ReadFMNoFB2FirstName();
		private string m_sNoFB2MiddleName		= SettingsFM.ReadFMNoFB2MiddleName();
		private string m_sNoFB2LastName			= SettingsFM.ReadFMNoFB2LastName();
		private string m_sNoFB2NickName			= SettingsFM.ReadFMNoFB2NickName();
		
		// название Групп Жанров
		private string m_sSf			= SettingsFM.ReadFMSf();
		private string m_sDetective		= SettingsFM.ReadFMDetective();
		private string m_sProse			= SettingsFM.ReadFMProse();
		private string m_sLove			= SettingsFM.ReadFMLove();
		private string m_sAdventure		= SettingsFM.ReadFMAdventure();
		private string m_sChildren		= SettingsFM.ReadFMChildren();
		private string m_sPoetry		= SettingsFM.ReadFMPoetry();
		private string m_sAntique		= SettingsFM.ReadFMAntique();
		private string m_sScience		= SettingsFM.ReadFMScience();
		private string m_sComputers		= SettingsFM.ReadFMComputers();
		private string m_sReference		= SettingsFM.ReadFMReference();
		private string m_sNonfiction	= SettingsFM.ReadFMNonfiction();
		private string m_sReligion		= SettingsFM.ReadFMReligion();
		private string m_sHumor			= SettingsFM.ReadFMHumor();
		private string m_sHome			= SettingsFM.ReadFMHome();
		private string m_sBusiness		= SettingsFM.ReadFMBusiness();
		private string m_sTech			= SettingsFM.ReadFMTech();
		private string m_sMilitary		= SettingsFM.ReadFMMilitary();
		private string m_sFolklore		= SettingsFM.ReadFMFolklore();
		private string m_sOther			= SettingsFM.ReadFMOther();
		// пути к архиваторам
		private string m_s7zaPath	= Settings.Read7zaPath();
		private string m_sUnRarPath	= Settings.ReadUnRarPath();
		private string m_sRarPath	= Settings.ReadRarPath();
		// папки для "проблемных" файлов
		private string m_sNotReadFB2Dir		= SettingsFM.GetDefFMFB2NotReadDir();
		private string m_sFileLongPathDir	= SettingsFM.GetDefFMFB2LongPathDir();
		private string m_sNotValidFB2Dir	= SettingsFM.GetDefFMFB2NotValidDir();
		private string m_sNotOpenArchDir	= SettingsFM.GetDefFMArchNotOpenDir();
		// основные настройки
		private bool m_bGenreTypeMode			= SettingsFM.ReadGenreTypeMode();
		private bool m_bFSGenresFB2LibrusecScheme	= FileManagerSettings.ReadXmlFullSortingFB2Librusec();
		private bool m_bSSGenresFB2LibrusecScheme	= FileManagerSettings.ReadXmlSelectedSortingFB2Librusec();
		private bool m_bAuthorOneMode			= SettingsFM.ReadAuthorOneMode();
		private bool m_bGenreOneMode			= SettingsFM.ReadGenreOneMode();
		private bool m_bAllFB2					= SettingsFM.ReadSortValidType();
		private bool m_bAddToFileNameBookIDMode	= SettingsFM.ReadAddToFileNameBookIDMode();
		private int	 m_nFileExistMode			= SettingsFM.ReadFileExistMode();
		private bool m_bFullSortingToZip		= FileManagerSettings.ReadXmlFullSortingToZip();
		private bool m_bSelectedSortingToZip	= FileManagerSettings.ReadXmlSelectedSortingToZip();
		#endregion
		
		public DataFM()
		{
		}
		
		#region Свойства класса
		// основные настройки
		public virtual bool GenreTypeMode {
			get { return m_bGenreTypeMode; }
			set { m_bGenreTypeMode = value; }
        }
		public virtual bool FSGenresFB2LibrusecScheme {
			get { return m_bFSGenresFB2LibrusecScheme; }
			set { m_bFSGenresFB2LibrusecScheme = value; }
        }
		public virtual bool SSGenresFB2LibrusecScheme {
			get { return m_bSSGenresFB2LibrusecScheme; }
			set { m_bSSGenresFB2LibrusecScheme = value; }
        }
		public virtual bool AuthorOneMode {
			get { return m_bAuthorOneMode; }
			set { m_bAuthorOneMode = value; }
        }
		public virtual bool GenreOneMode {
			get { return m_bGenreOneMode; }
			set { m_bGenreOneMode = value; }
        }
		public virtual bool SortValidType {
			get { return m_bAllFB2; }
			set { m_bAllFB2 = value; }
        }
		public virtual int FileExistMode {
			get { return m_nFileExistMode; }
			set { m_nFileExistMode = value; }
        }
		public virtual bool AddToFileNameBookIDMode {
			get { return m_bAddToFileNameBookIDMode; }
			set { m_bAddToFileNameBookIDMode = value; }
        }
		// пути к архиваторам
		public virtual string A7zaPath {
			get { return m_s7zaPath; }
			set { m_s7zaPath = value; }
        }
		public virtual string UnRarPath {
			get { return m_sUnRarPath; }
			set { m_sUnRarPath = value; }
        }
		public virtual string RarPath {
			get { return m_sRarPath; }
			set { m_sRarPath = value; }
        }
		// папки для "проблемных" файлов
		public virtual string NotReadFB2Dir {
			get { return m_sNotReadFB2Dir; }
			set { m_sNotReadFB2Dir = value; }
        }
		public virtual string FileLongPathDir {
			get { return m_sFileLongPathDir; }
			set { m_sFileLongPathDir = value; }
        }
		public virtual string NotValidFB2Dir {
			get { return m_sNotValidFB2Dir; }
			set { m_sNotValidFB2Dir = value; }
        }
		public virtual string NotOpenArchDir {
			get { return m_sNotOpenArchDir; }
			set { m_sNotOpenArchDir = value; }
        }
		// названия папок для шаблонных тэгов, которые не имеют данных
		public virtual string NoGenreGroup {
			get { return m_sNoGenreGroup; }
			set { m_sNoGenreGroup = value; }
        }
		public virtual string NoGenre {
			get { return m_sNoGenre; }
			set { m_sNoGenre = value; }
        }
		public virtual string NoLang {
			get { return m_sNoLang; }
			set { m_sNoLang = value; }
        }
		public virtual string NoFirstName {
			get { return m_sNoFirstName; }
			set { m_sNoFirstName = value; }
        }
		public virtual string NoMiddleName {
			get { return m_sNoMiddleName; }
			set { m_sNoMiddleName = value; }
        }
		public virtual string NoLastName {
			get { return m_sNoLastName; }
			set { m_sNoLastName = value; }
        }
		public virtual string NoNickName {
			get { return m_sNoNickName; }
			set { m_sNoNickName = value; }
        }
		public virtual string NoBookTitle {
			get { return m_sNoBookTitle; }
			set { m_sNoBookTitle = value; }
        }
		public virtual string NoSequence {
			get { return m_sNoSequence; }
			set { m_sNoSequence = value; }
        }
		public virtual string NoNSequence {
			get { return m_sNoNSequence; }
			set { m_sNoNSequence = value; }
        }
		public virtual string NoDateText {
			get { return m_sNoDateText; }
			set { m_sNoDateText = value; }
        }
		public virtual string NoDateValue {
			get { return m_sNoDateValue; }
			set { m_sNoDateValue = value; }
        }
		public virtual string NoYear {
			get { return m_sNoYear; }
			set { m_sNoYear = value; }
        }
		public virtual string NoPublisher {
			get { return m_sNoPublisher; }
			set { m_sNoPublisher = value; }
        }
		public virtual string NoCity {
			get { return m_sNoCity; }
			set { m_sNoCity = value; }
        }
		public virtual string NoFB2FirstName {
			get { return m_sNoFB2FirstName; }
			set { m_sNoFB2FirstName = value; }
        }
		public virtual string NoFB2MiddleName {
			get { return m_sNoFB2MiddleName; }
			set { m_sNoFB2MiddleName = value; }
        }
		public virtual string NoFB2LastName {
			get { return m_sNoFB2LastName; }
			set { m_sNoFB2LastName = value; }
        }
		public virtual string NoFB2NickName {
			get { return m_sNoFB2NickName; }
			set { m_sNoFB2NickName = value; }
        }
		// название Групп Жанров
		public virtual string GenresGroupSf {
			get { return m_sSf; }
			set { m_sSf = value; }
        }
		public virtual string GenresGroupDetective {
			get { return m_sDetective; }
			set { m_sDetective = value; }
        }
		public virtual string GenresGroupProse {
			get { return m_sProse; }
			set { m_sProse = value; }
        }
		public virtual string GenresGroupLove {
			get { return m_sLove; }
			set { m_sLove = value; }
        }
		public virtual string GenresGroupAdventure {
			get { return m_sAdventure; }
			set { m_sAdventure = value; }
        }
		public virtual string GenresGroupChildren {
			get { return m_sChildren; }
			set { m_sChildren = value; }
        }
		public virtual string GenresGroupPoetry {
			get { return m_sPoetry; }
			set { m_sPoetry = value; }
        }
		public virtual string GenresGroupAntique {
			get { return m_sAntique; }
			set { m_sAntique = value; }
        }
		public virtual string GenresGroupScience {
			get { return m_sScience; }
			set { m_sScience = value; }
        }
		public virtual string GenresGroupComputers {
			get { return m_sComputers; }
			set { m_sComputers = value; }
        }
		public virtual string GenresGroupReference {
			get { return m_sReference; }
			set { m_sReference = value; }
        }
		public virtual string GenresGroupNonfiction {
			get { return m_sNonfiction; }
			set { m_sNonfiction = value; }
        }
		public virtual string GenresGroupReligion {
			get { return m_sReligion; }
			set { m_sReligion = value; }
        }
		public virtual string GenresGroupHumor {
			get { return m_sHumor; }
			set { m_sHumor = value; }
        }
		public virtual string GenresGroupHome {
			get { return m_sHome; }
			set { m_sHome = value; }
        }
		public virtual string GenresGroupBusiness {
			get { return m_sBusiness; }
			set { m_sBusiness = value; }
        }
		public virtual string GenresGroupTech {
			get { return m_sTech; }
			set { m_sTech = value; }
        }
		public virtual string GenresGroupMilitary {
			get { return m_sMilitary; }
			set { m_sMilitary = value; }
        }
		public virtual string GenresGroupFolklore {
			get { return m_sFolklore; }
			set { m_sFolklore = value; }
        }
		public virtual string GenresGroupOther {
			get { return m_sOther; }
			set { m_sOther = value; }
        }
		#endregion
	}
}
