/*
 * Created by SharpDevelop.
 * User: DikBSD
 * Date: 05.04.2009
 * Time: 14:31
 * 
 * License: GPL 2.1
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using filesWorker = Core.FilesWorker.FilesWorker;

namespace Options
{
	/// <summary>
	/// ��������� ����� ���� ������������
	/// </summary>
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			#region ��� ������������
			InitializeComponent();
			/* ��-��������� */
			// �����
			DefGeneral();
			// ���������
			DefValidator();
			// �������� ������
			// �������� ��� ��������� ������
			DefFMGeneral();
			// �������� ����� ���������� ���� ��� ������
			DefFMDirNameForTagNotData();
			// �������� ��� ������ ������������ �� Description ����� ��� ������ ����
			DefFMDirNameForPublisherTagNotData();
			// �������� ��� ������ fb2-����� �� Description ����� ��� ������ ����
			DefFMDirNameForFB2TagNotData();
			// �������� ����� ������
			DefFMGenresGroups();
			/* ������ ����������� ���������, ���� ��� ���� */
			ReadSettings();
			#endregion
		}
		
		#region �������� ��������������� ������
		private void DefGeneral() {
			// ����� ���������
			tboxWinRarPath.Text	= Settings.Settings.GetDefWinRARPath();
			tboxRarPath.Text	= Settings.Settings.GetDefRarPath();
			tboxUnRarPath.Text	= Settings.Settings.GetDefUnRARPath();
			tbox7zaPath.Text	= Settings.Settings.GetDef7zaPath();
			tboxFBEPath.Text	= Settings.Settings.GetDefFBEPath();
			tboxTextEPath.Text	= Settings.Settings.GetDefTFB2Path();
			tboxReaderPath.Text = Settings.Settings.GetDefFBReaderPath();
			tboxDiffPath.Text 	= Settings.Settings.GetDiffPath();
			cboxDSValidator.Text		= Settings.SettingsValidator.GetDefValidatorcboxDSValidatorText();
			cboxTIRValidator.Text		= Settings.SettingsValidator.GetDefValidatorcboxTIRValidatorText();;
			cboxDSArchiveManager.Text	= Settings.SettingsAM.GetDefAMcboxDSArchiveManagerText();
			cboxTIRArchiveManager.Text	= Settings.SettingsAM.GetDefAMcboxTIRArchiveManagerText();
			cboxDSFileManager.Text		= Settings.SettingsFM.GetDefFMcboxDSFileManagerText();
			cboxTIRFileManager.Text 	= Settings.SettingsFM.GetDefFMcboxTIRFileManagerText();
			cboxDSFB2Dup.Text			= Settings.SettingsFB2Dup.GetDefDupcboxDSFB2DupText();
			cboxTIRFB2Dup.Text			= Settings.SettingsFB2Dup.GetDefDupcboxTIRFB2DupText();
			chBoxConfirmationForExit.Checked = true;
		}
		private void DefValidator() {
			// ���������
			cboxValidatorForFB2.SelectedIndex			= Settings.SettingsValidator.GetDefValidatorFB2SelectedIndex();
			cboxValidatorForFB2Archive.SelectedIndex	= Settings.SettingsValidator.GetDefValidatorFB2ArchiveSelectedIndex();
			cboxValidatorForFB2PE.SelectedIndex			= Settings.SettingsValidator.GetDefValidatorFB2SelectedIndexPE();
			cboxValidatorForFB2ArchivePE.SelectedIndex	= Settings.SettingsValidator.GetDefValidatorFB2ArchiveSelectedIndexPE();
		}
		private void DefFMGeneral() {
			// �������� ��� ��������� ������
			chBoxTranslit.Checked = Settings.SettingsFM.GetDefFMchBoxTranslitCheked();
			chBoxStrict.Checked = Settings.SettingsFM.GetDefFMchBoxStrictCheked();
			cboxSpace.SelectedIndex = Settings.SettingsFM.GetDefFMcboxSpaceSelectedIndex();
			cboxFileExist.SelectedIndex = Settings.SettingsFM.GetDefFMcboxFileExistSelectedIndex();
			rbtnAsIs.Checked = Settings.SettingsFM.GetDefFMrbtnAsIsCheked();
			rbtnAsSentence.Checked = Settings.SettingsFM.GetDefFMrbtnAsSentenceCheked();
			rbtnLower.Checked = Settings.SettingsFM.GetDefFMrbtnLowerCheked();
			rbtnUpper.Checked = Settings.SettingsFM.GetDefFMrbtnUpperCheked();
			rbtnGenreOne.Checked = Settings.SettingsFM.GetDefFMrbtnGenreOneCheked();
			rbtnGenreAll.Checked = Settings.SettingsFM.GetDefFMrbtnGenreAllCheked();
			rbtnAuthorOne.Checked = Settings.SettingsFM.GetDefFMrbtnAuthorOneCheked();
			rbtnAuthorAll.Checked = Settings.SettingsFM.GetDefFMrbtnAuthorAllCheked();
			rbtnGenreSchema.Checked = Settings.SettingsFM.GetDefFMrbtnGenreSchemaCheked();
			rbtnGenreText.Checked = Settings.SettingsFM.GetDefFMrbtnGenreTextCheked();
			chBoxAddToFileNameBookID.Checked = Settings.SettingsFM.GetDefFMchBoxAddToFileNameBookIDChecked();
			rbtnFMAllFB2.Checked		= Settings.SettingsFM.GetDefFMrbtnFMAllFB2Cheked();
			rbtnFMOnleValidFB2.Checked	= Settings.SettingsFM.GetDefFMrbtnFMOnlyValidFB2Cheked();
		}
		private void DefFMDirNameForTagNotData() {
			// �������� ����� ���������� ���� ��� ������
			txtBoxFMNoGenreGroup.Text	= Settings.SettingsFM.GetDefFMNoGenreGroup();
			txtBoxFMNoGenre.Text		= Settings.SettingsFM.GetDefFMNoGenre();
			txtBoxFMNoLang.Text			= Settings.SettingsFM.GetDefFMNoLang();
			txtBoxFMNoFirstName.Text	= Settings.SettingsFM.GetDefFMNoFirstName();
			txtBoxFMNoMiddleName.Text	= Settings.SettingsFM.GetDefFMNoMiddleName();
			txtBoxFMNoLastName.Text		= Settings.SettingsFM.GetDefFMNoLastName();
			txtBoxFMNoNickName.Text		= Settings.SettingsFM.GetDefFMNoNickName();
			txtBoxFMNoBookTitle.Text	= Settings.SettingsFM.GetDefFMNoBookTitle();
			txtBoxFMNoSequence.Text		= Settings.SettingsFM.GetDefFMNoSequence();
			txtBoxFMNoNSequence.Text	= Settings.SettingsFM.GetDefFMNoNSequence();
			txtBoxFMNoDateText.Text		= Settings.SettingsFM.GetDefFMNoDateText();
			txtBoxFMNoDateValue.Text	= Settings.SettingsFM.GetDefFMNoDateValue();
		}
		private void DefFMDirNameForPublisherTagNotData() {
			// �������� ��� ������ ������������ �� Description ����� ��� ������ ����
			txtBoxFMNoYear.Text			= Settings.SettingsFM.GetDefFMNoYear();
			txtBoxFMNoPublisher.Text	= Settings.SettingsFM.GetDefFMNoPublisher();
			txtBoxFMNoCity.Text			= Settings.SettingsFM.GetDefFMNoCity();
		}
		private void DefFMDirNameForFB2TagNotData() {
			// �������� ��� ������ fb2-����� �� Description ����� ��� ������ ����
			txtBoxFMNoFB2FirstName.Text		= Settings.SettingsFM.GetDefFMNoFB2FirstName();
			txtBoxFMNoFB2MiddleName.Text	= Settings.SettingsFM.GetDefFMNoFB2MiddleName();
			txtBoxFMNoFB2LastName.Text		= Settings.SettingsFM.GetDefFMNoFB2LastName();
			txtBoxFMNoFB2NickName.Text		= Settings.SettingsFM.GetDefFMNoFB2NickName();
		}
		
		private void DefFMGenresGroups() {
			// �������� ����� ������
			txtboxFMsf.Text			= Settings.SettingsFM.GetDefFMGenresGroupSf();
			txtboxFMdetective.Text	= Settings.SettingsFM.GetDefFMGenresGroupDetective();
			txtboxFMprose.Text		= Settings.SettingsFM.GetDefFMGenresGroupProse();
			txtboxFMlove.Text		= Settings.SettingsFM.GetDefFMGenresGroupLove();
			txtboxFMadventure.Text	= Settings.SettingsFM.GetDefFMGenresGroupAdventure();
			txtboxFMchildren.Text	= Settings.SettingsFM.GetDefFMGenresGroupChildren();
			txtboxFMpoetry.Text		= Settings.SettingsFM.GetDefFMGenresGroupPoetry();
			txtboxFMantique.Text	= Settings.SettingsFM.GetDefFMGenresGroupAntique();
			txtboxFMscience.Text	= Settings.SettingsFM.GetDefFMGenresGroupScience();
			txtboxFMcomputers.Text	= Settings.SettingsFM.GetDefFMGenresGroupComputers();
			txtboxFMreference.Text	= Settings.SettingsFM.GetDefFMGenresGroupReference();
			txtboxFMnonfiction.Text	= Settings.SettingsFM.GetDefFMGenresGroupNonfiction();
			txtboxFMreligion.Text	= Settings.SettingsFM.GetDefFMGenresGroupReligion();
			txtboxFMhumor.Text		= Settings.SettingsFM.GetDefFMGenresGroupHumor();
			txtboxFMhome.Text		= Settings.SettingsFM.GetDefFMGenresGroupHome();
			txtboxFMbusiness.Text	= Settings.SettingsFM.GetDefFMGenresGroupBusiness();
			txtboxFMtech.Text		= Settings.SettingsFM.GetDefFMGenresGroupTech();
			txtboxFMmilitary.Text	= Settings.SettingsFM.GetDefFMGenresGroupMilitary();
			txtboxFMfolklore.Text	= Settings.SettingsFM.GetDefFMGenresGroupFolklore();
			txtboxFMother.Text		= Settings.SettingsFM.GetDefFMGenresGroupOther();
		}

		private void ReadSettings() {
			// ������ �������� �� xml-�����
			#region ���
			string sSettings = Settings.Settings.GetSettingsPath();
			if( !File.Exists( sSettings ) ) return;
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			using ( XmlReader reader = XmlReader.Create( sSettings, settings ) ) {
				try {
					// ����� 
					reader.ReadToFollowing("WinRar");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("WinRarPath") != null )
							tboxWinRarPath.Text = reader.GetAttribute("WinRarPath");
						if ( reader.GetAttribute("RarPath") != null )
							tboxRarPath.Text = reader.GetAttribute("RarPath");
						if ( reader.GetAttribute("UnRarPath") != null )
							tboxUnRarPath.Text = reader.GetAttribute("UnRarPath");
					}
					reader.ReadToFollowing("A7za");
					if( reader.HasAttributes ) {
						tbox7zaPath.Text = reader.GetAttribute("A7zaPath");
					}
					reader.ReadToFollowing("Editors");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("FBEPath") != null )
							tboxFBEPath.Text = reader.GetAttribute("FBEPath");
						if ( reader.GetAttribute("TextFB2EPath") != null )
							tboxTextEPath.Text = reader.GetAttribute("TextFB2EPath");
					}
					reader.ReadToFollowing("Reader");
					if( reader.HasAttributes ) {
						tboxReaderPath.Text = reader.GetAttribute("FBReaderPath");
					}
					reader.ReadToFollowing("Diff");
					if( reader.HasAttributes ) {
						tboxDiffPath.Text = reader.GetAttribute("DiffPath");
					}
					reader.ReadToFollowing("ValidatorToolButtons");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxDSValidatorText") != null )
							cboxDSValidator.Text = reader.GetAttribute("cboxDSValidatorText");
						if ( reader.GetAttribute("cboxTIRValidatorText") != null )
							cboxTIRValidator.Text = reader.GetAttribute("cboxTIRValidatorText");
					}
					reader.ReadToFollowing("FileManagerToolButtons");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxDSFileManagerText") != null )
							cboxDSFileManager.Text = reader.GetAttribute("cboxDSFileManagerText");
						if ( reader.GetAttribute("cboxTIRFileManagerText") != null )
							cboxTIRFileManager.Text = reader.GetAttribute("cboxTIRFileManagerText");
					}
					reader.ReadToFollowing("ArchiveManagerToolButtons");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxDSArchiveManagerText") != null )
							cboxDSArchiveManager.Text = reader.GetAttribute("cboxDSArchiveManagerText");
						if ( reader.GetAttribute("cboxTIRArchiveManagerText") != null )
							cboxTIRArchiveManager.Text = reader.GetAttribute("cboxTIRArchiveManagerText");
					}
					reader.ReadToFollowing("DupToolButtons");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxDSFB2DupText") != null )
							cboxDSFB2Dup.Text = reader.GetAttribute("cboxDSFB2DupText");
						if ( reader.GetAttribute("cboxTIRFB2DupText") != null )
							cboxTIRFB2Dup.Text = reader.GetAttribute("cboxTIRFB2DupText");
					}
					reader.ReadToFollowing("ConfirmationForExit");
					if( reader.HasAttributes ) {
						chBoxConfirmationForExit.Checked = Convert.ToBoolean( reader.GetAttribute("ConfirmationForExit") );
					}
					// ���������
					reader.ReadToFollowing("ValidatorDoubleClick");
					if (reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxValidatorForFB2SelectedIndex") != null )
							cboxValidatorForFB2.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxValidatorForFB2SelectedIndex") );
						if ( reader.GetAttribute("cboxValidatorForFB2ArchiveSelectedIndex") != null )
							cboxValidatorForFB2Archive.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxValidatorForFB2ArchiveSelectedIndex") );
					}
					reader.ReadToFollowing("ValidatorPressEnter");
					if (reader.HasAttributes ) {
						if ( reader.GetAttribute("cboxValidatorForFB2SelectedIndexPE") != null )
							cboxValidatorForFB2PE.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxValidatorForFB2SelectedIndexPE") );
						if ( reader.GetAttribute("cboxValidatorForFB2ArchiveSelectedIndexPE") != null )
							cboxValidatorForFB2ArchivePE.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxValidatorForFB2ArchiveSelectedIndexPE") );
					}
					// �������� ������
					reader.ReadToFollowing("Register");
					if (reader.HasAttributes ) {
						rbtnAsIs.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnAsIsChecked") );
						rbtnAsSentence.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnAsSentenceChecked") );
						rbtnLower.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnLowerChecked") );
						rbtnUpper.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnUpperChecked") );
					}
					reader.ReadToFollowing("Translit");
					if( reader.HasAttributes ) {
						chBoxTranslit.Checked = Convert.ToBoolean( reader.GetAttribute("chBoxTranslitChecked") );
					}
					reader.ReadToFollowing("Strict");
					if( reader.HasAttributes ) {
						chBoxStrict.Checked = Convert.ToBoolean( reader.GetAttribute("chBoxStrictChecked") );
					}
					reader.ReadToFollowing("Space");
					if( reader.HasAttributes ) {
						cboxSpace.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxSpaceSelectedIndex") );
					}
					reader.ReadToFollowing("IsFileExist");
					if( reader.HasAttributes ) {
						cboxFileExist.SelectedIndex = Convert.ToInt16( reader.GetAttribute("cboxFileExistSelectedIndex") );
					}
					reader.ReadToFollowing("AddToFileNameBookID");
					if( reader.HasAttributes ) {
						chBoxAddToFileNameBookID.Checked = Convert.ToBoolean( reader.GetAttribute("chBoxAddToFileNameBookIDChecked") );
					}
					reader.ReadToFollowing("AuthorsToDirs");
					if( reader.HasAttributes ) {
						rbtnAuthorOne.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnAuthorOneChecked") );
						rbtnAuthorAll.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnAuthorAllChecked") );
					}
					reader.ReadToFollowing("GenresToDirs");
					if( reader.HasAttributes ) {
						rbtnGenreOne.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnGenreOneChecked") );
						rbtnGenreAll.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnGenreAllChecked") );
					}
					reader.ReadToFollowing("GenresType");
					if( reader.HasAttributes ) {
						rbtnGenreSchema.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnGenreSchemaChecked") );
						rbtnGenreText.Checked = Convert.ToBoolean( reader.GetAttribute("rbtnGenreTextChecked") );
					}
					reader.ReadToFollowing("SortType");
					if( reader.HasAttributes ) {
						rbtnFMAllFB2.Checked		= Convert.ToBoolean( reader.GetAttribute("rbtnFMAllFB2Checked") );
						rbtnFMOnleValidFB2.Checked	= Convert.ToBoolean( reader.GetAttribute("rbtnFMOnleValidFB2Checked") );
					}
					reader.ReadToFollowing("TagsNoText");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("txtBoxFMNoGenreGroup") != null )
							txtBoxFMNoGenreGroup.Text = reader.GetAttribute("txtBoxFMNoGenreGroup");
						if ( reader.GetAttribute("txtBoxFMNoGenre") != null )
							txtBoxFMNoGenre.Text = reader.GetAttribute("txtBoxFMNoGenre");
						if ( reader.GetAttribute("txtBoxFMNoLang") != null )
							txtBoxFMNoLang.Text = reader.GetAttribute("txtBoxFMNoLang");
						if ( reader.GetAttribute("txtBoxFMNoFirstName") != null )
							txtBoxFMNoFirstName.Text = reader.GetAttribute("txtBoxFMNoFirstName");
						if ( reader.GetAttribute("txtBoxFMNoMiddleName") != null )
							txtBoxFMNoMiddleName.Text = reader.GetAttribute("txtBoxFMNoMiddleName");
						if ( reader.GetAttribute("txtBoxFMNoLastName") != null )
							txtBoxFMNoLastName.Text = reader.GetAttribute("txtBoxFMNoLastName");
						if ( reader.GetAttribute("txtBoxFMNoNickName") != null )
							txtBoxFMNoNickName.Text = reader.GetAttribute("txtBoxFMNoNickName");
						if ( reader.GetAttribute("txtBoxFMNoBookTitle") != null )
							txtBoxFMNoBookTitle.Text = reader.GetAttribute("txtBoxFMNoBookTitle");
						if ( reader.GetAttribute("txtBoxFMNoSequence") != null )
							txtBoxFMNoSequence.Text = reader.GetAttribute("txtBoxFMNoSequence");
						if ( reader.GetAttribute("txtBoxFMNoNSequence") != null )
							txtBoxFMNoNSequence.Text = reader.GetAttribute("txtBoxFMNoNSequence");
						if ( reader.GetAttribute("txtBoxFMNoDateText") != null )
							txtBoxFMNoDateText.Text = reader.GetAttribute("txtBoxFMNoDateText");
						if ( reader.GetAttribute("txtBoxFMNoDateValue") != null )
							txtBoxFMNoDateValue.Text = reader.GetAttribute("txtBoxFMNoDateValue");
						if ( reader.GetAttribute("txtBoxFMNoYear") != null )
							txtBoxFMNoYear.Text = reader.GetAttribute("txtBoxFMNoYear");
						if ( reader.GetAttribute("txtBoxFMNoPublisher") != null )
							txtBoxFMNoPublisher.Text = reader.GetAttribute("txtBoxFMNoPublisher");
						if ( reader.GetAttribute("txtBoxFMNoCity") != null )
							txtBoxFMNoCity.Text = reader.GetAttribute("txtBoxFMNoCity");
						if ( reader.GetAttribute("txtBoxFMNoFB2FirstName") != null )
							txtBoxFMNoFB2FirstName.Text = reader.GetAttribute("txtBoxFMNoFB2FirstName");
						if ( reader.GetAttribute("txtBoxFMNoFB2MiddleName") != null )
							txtBoxFMNoFB2MiddleName.Text = reader.GetAttribute("txtBoxFMNoFB2MiddleName");
						if ( reader.GetAttribute("txtBoxFMNoFB2LastName") != null )
							txtBoxFMNoFB2LastName.Text = reader.GetAttribute("txtBoxFMNoFB2LastName");
						if ( reader.GetAttribute("txtBoxFMNoFB2NickName") != null )
							txtBoxFMNoFB2NickName.Text = reader.GetAttribute("txtBoxFMNoFB2NickName");
					}
					reader.ReadToFollowing("GenresGroups");
					if( reader.HasAttributes ) {
						if ( reader.GetAttribute("txtboxFMsf") != null )
							txtboxFMsf.Text = reader.GetAttribute("txtboxFMsf");
						if ( reader.GetAttribute("txtboxFMdetective") != null )
							txtboxFMdetective.Text = reader.GetAttribute("txtboxFMdetective");
						if ( reader.GetAttribute("txtboxFMprose") != null )
							txtboxFMprose.Text = reader.GetAttribute("txtboxFMprose");
						if ( reader.GetAttribute("txtboxFMlove") != null )
							txtboxFMlove.Text = reader.GetAttribute("txtboxFMlove");
						if ( reader.GetAttribute("txtboxFMadventure") != null )
							txtboxFMadventure.Text = reader.GetAttribute("txtboxFMadventure");
						if ( reader.GetAttribute("txtboxFMchildren") != null )
							txtboxFMchildren.Text = reader.GetAttribute("txtboxFMchildren");
						if ( reader.GetAttribute("txtboxFMpoetry") != null )
							txtboxFMpoetry.Text = reader.GetAttribute("txtboxFMpoetry");
						if ( reader.GetAttribute("txtboxFMantique") != null )
							txtboxFMantique.Text = reader.GetAttribute("txtboxFMantique");
						if ( reader.GetAttribute("txtboxFMscience") != null )
							txtboxFMscience.Text = reader.GetAttribute("txtboxFMscience");
						if ( reader.GetAttribute("txtboxFMcomputers") != null )
							txtboxFMcomputers.Text = reader.GetAttribute("txtboxFMcomputers");
						if ( reader.GetAttribute("txtboxFMreference") != null )
							txtboxFMreference.Text = reader.GetAttribute("txtboxFMreference");
						if ( reader.GetAttribute("txtboxFMnonfiction") != null )
							txtboxFMnonfiction.Text = reader.GetAttribute("txtboxFMnonfiction");
						if ( reader.GetAttribute("txtboxFMreligion") != null )
							txtboxFMreligion.Text = reader.GetAttribute("txtboxFMreligion");
						if ( reader.GetAttribute("txtboxFMhumor") != null )
							txtboxFMhumor.Text = reader.GetAttribute("txtboxFMhumor");
						if ( reader.GetAttribute("txtboxFMhome") != null )
							txtboxFMhome.Text = reader.GetAttribute("txtboxFMhome");
						if ( reader.GetAttribute("txtboxFMbusiness") != null )
							txtboxFMbusiness.Text = reader.GetAttribute("txtboxFMbusiness");
						if ( reader.GetAttribute("txtboxFMtech") != null )
							txtboxFMtech.Text = reader.GetAttribute("txtboxFMtech");
						if ( reader.GetAttribute("txtboxFMmilitary") != null )
							txtboxFMmilitary.Text = reader.GetAttribute("txtboxFMmilitary");
						if ( reader.GetAttribute("txtboxFMfolklore") != null )
							txtboxFMfolklore.Text = reader.GetAttribute("txtboxFMfolklore");
						if ( reader.GetAttribute("txtboxFMother") != null )
							txtboxFMother.Text = reader.GetAttribute("txtboxFMother");
					}
				} catch {
					MessageBox.Show( "��������� ���� ��������: \""+Settings.Settings.GetSettingsPath()+"\".\n������� ���, �� ��������� ������������� ��� ���������� ��������", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				} finally {
					reader.Close();
				}
			}
			#endregion
		}
		
		private void WriteSettings() {
			// ���������� �������� � ini
			#region ���
			// ������������� ������� ����� - ����� ���������
			Environment.CurrentDirectory = Settings.Settings.GetProgDir();
			XmlWriter writer = null;
			try {
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Indent = true;
				settings.IndentChars = ("\t");
				settings.OmitXmlDeclaration = true;
				
				writer = XmlWriter.Create( Settings.Settings.GetSettingsPath(), settings );
				writer.WriteStartElement( "SharpFBTools" );
					// �����
					writer.WriteStartElement( "General" );
						writer.WriteStartElement( "WinRar" );
							writer.WriteAttributeString( "WinRarPath", tboxWinRarPath.Text );
							writer.WriteAttributeString( "RarPath", tboxRarPath.Text );
							writer.WriteAttributeString( "UnRarPath", tboxUnRarPath.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "A7za" );
							writer.WriteAttributeString( "A7zaPath", tbox7zaPath.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Editors" );
							writer.WriteAttributeString( "FBEPath", tboxFBEPath.Text );
							writer.WriteAttributeString( "TextFB2EPath", tboxTextEPath.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Reader" );
							writer.WriteAttributeString( "FBReaderPath", tboxReaderPath.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Diff" );
							writer.WriteAttributeString( "DiffPath", tboxDiffPath.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "ToolButtons" );
							writer.WriteStartElement( "ValidatorToolButtons" );
								writer.WriteAttributeString( "cboxDSValidatorText", cboxDSValidator.Text );
								writer.WriteAttributeString( "cboxTIRValidatorText", cboxTIRValidator.Text );
							writer.WriteFullEndElement();
							writer.WriteStartElement( "FileManagerToolButtons" );
								writer.WriteAttributeString( "cboxDSFileManagerText", cboxDSFileManager.Text );
								writer.WriteAttributeString( "cboxTIRFileManagerText", cboxTIRFileManager.Text );
							writer.WriteFullEndElement();
							writer.WriteStartElement( "ArchiveManagerToolButtons" );
								writer.WriteAttributeString( "cboxDSArchiveManagerText", cboxDSArchiveManager.Text );
								writer.WriteAttributeString( "cboxTIRArchiveManagerText", cboxTIRArchiveManager.Text );
							writer.WriteFullEndElement();
							writer.WriteStartElement( "DupToolButtons" );
								writer.WriteAttributeString( "cboxDSFB2DupText", cboxDSFB2Dup.Text );
								writer.WriteAttributeString( "cboxTIRFB2DupText", cboxTIRFB2Dup.Text );
							writer.WriteFullEndElement();
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "ConfirmationForExit" );
						writer.WriteAttributeString( "ConfirmationForExit", Convert.ToString( chBoxConfirmationForExit.Checked ) );
						writer.WriteFullEndElement();
						
					writer.WriteEndElement();
					
					// ���������
					writer.WriteStartElement( "FB2Validator" );
						writer.WriteStartElement( "ValidatorDoubleClick" );
							writer.WriteAttributeString( "cboxValidatorForFB2SelectedIndex", cboxValidatorForFB2.SelectedIndex.ToString() );
							writer.WriteAttributeString( "cboxValidatorForFB2ArchiveSelectedIndex", cboxValidatorForFB2Archive.SelectedIndex.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "ValidatorPressEnter" );
							writer.WriteAttributeString( "cboxValidatorForFB2SelectedIndexPE", cboxValidatorForFB2PE.SelectedIndex.ToString() );
							writer.WriteAttributeString( "cboxValidatorForFB2ArchiveSelectedIndexPE", cboxValidatorForFB2ArchivePE.SelectedIndex.ToString() );
						writer.WriteFullEndElement();
					writer.WriteEndElement();
					
					// �������� ������
					writer.WriteStartElement( "FileManager" );
						writer.WriteStartElement( "Register" );
							writer.WriteAttributeString( "rbtnAsIsChecked", rbtnAsIs.Checked.ToString() );
							writer.WriteAttributeString( "rbtnAsSentenceChecked", rbtnAsSentence.Checked.ToString() );
							writer.WriteAttributeString( "rbtnLowerChecked", rbtnLower.Checked.ToString() );
							writer.WriteAttributeString( "rbtnUpperChecked", rbtnUpper.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Translit" );
							writer.WriteAttributeString( "chBoxTranslitChecked", chBoxTranslit.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Strict" );
							writer.WriteAttributeString( "chBoxStrictChecked", chBoxStrict.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "Space" );
							writer.WriteAttributeString( "cboxSpaceSelectedIndex", cboxSpace.SelectedIndex.ToString() );
							writer.WriteAttributeString( "cboxSpaceText", cboxSpace.Text.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "IsFileExist" );
							writer.WriteAttributeString( "cboxFileExistSelectedIndex", cboxFileExist.SelectedIndex.ToString() );
							writer.WriteAttributeString( "cboxFileExistText", cboxFileExist.Text.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "AddToFileNameBookID" );
							writer.WriteAttributeString( "chBoxAddToFileNameBookIDChecked", chBoxAddToFileNameBookID.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "AuthorsToDirs" );
							writer.WriteAttributeString( "rbtnAuthorOneChecked", rbtnAuthorOne.Checked.ToString() );
							writer.WriteAttributeString( "rbtnAuthorAllChecked", rbtnAuthorAll.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "GenresToDirs" );
							writer.WriteAttributeString( "rbtnGenreOneChecked", rbtnGenreOne.Checked.ToString() );
							writer.WriteAttributeString( "rbtnGenreAllChecked", rbtnGenreAll.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "GenresType" );
							writer.WriteAttributeString( "rbtnGenreSchemaChecked", rbtnGenreSchema.Checked.ToString() );
							writer.WriteAttributeString( "rbtnGenreTextChecked", rbtnGenreText.Checked.ToString() );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "SortType" );
							writer.WriteAttributeString( "rbtnFMAllFB2Checked", rbtnFMAllFB2.Checked.ToString() );
							writer.WriteAttributeString( "rbtnFMOnleValidFB2Checked", rbtnFMOnleValidFB2.Checked.ToString() );
						writer.WriteFullEndElement();
						
						// ��� ������ �����
						writer.WriteStartElement( "TagsNoText" );
							writer.WriteAttributeString( "txtBoxFMNoGenreGroup", txtBoxFMNoGenreGroup.Text );
							writer.WriteAttributeString( "txtBoxFMNoGenre", txtBoxFMNoGenre.Text );
							writer.WriteAttributeString( "txtBoxFMNoLang", txtBoxFMNoLang.Text );
							writer.WriteAttributeString( "txtBoxFMNoFirstName", txtBoxFMNoFirstName.Text );
							writer.WriteAttributeString( "txtBoxFMNoMiddleName", txtBoxFMNoMiddleName.Text );
							writer.WriteAttributeString( "txtBoxFMNoLastName", txtBoxFMNoLastName.Text );
							writer.WriteAttributeString( "txtBoxFMNoNickName", txtBoxFMNoNickName.Text );
							writer.WriteAttributeString( "txtBoxFMNoBookTitle", txtBoxFMNoBookTitle.Text );
							writer.WriteAttributeString( "txtBoxFMNoSequence", txtBoxFMNoSequence.Text );
							writer.WriteAttributeString( "txtBoxFMNoNSequence", txtBoxFMNoNSequence.Text );
							writer.WriteAttributeString( "txtBoxFMNoDateText", txtBoxFMNoDateText.Text );
							writer.WriteAttributeString( "txtBoxFMNoDateValue", txtBoxFMNoDateValue.Text );
							writer.WriteAttributeString( "txtBoxFMNoYear", txtBoxFMNoYear.Text );
							writer.WriteAttributeString( "txtBoxFMNoPublisher", txtBoxFMNoPublisher.Text );
							writer.WriteAttributeString( "txtBoxFMNoCity", txtBoxFMNoCity.Text );
							writer.WriteAttributeString( "txtBoxFMNoFB2FirstName", txtBoxFMNoFB2FirstName.Text );
							writer.WriteAttributeString( "txtBoxFMNoFB2MiddleName", txtBoxFMNoFB2MiddleName.Text );
							writer.WriteAttributeString( "txtBoxFMNoFB2LastName", txtBoxFMNoFB2LastName.Text );
							writer.WriteAttributeString( "txtBoxFMNoFB2NickName", txtBoxFMNoFB2NickName.Text );
						writer.WriteFullEndElement();
						
						writer.WriteStartElement( "GenresGroups" );
							writer.WriteAttributeString( "txtboxFMsf", txtboxFMsf.Text );
							writer.WriteAttributeString( "txtboxFMdetective", txtboxFMdetective.Text );
							writer.WriteAttributeString( "txtboxFMprose", txtboxFMprose.Text );
							writer.WriteAttributeString( "txtboxFMlove", txtboxFMlove.Text );
							writer.WriteAttributeString( "txtboxFMadventure", txtboxFMadventure.Text );
							writer.WriteAttributeString( "txtboxFMchildren", txtboxFMchildren.Text );
							writer.WriteAttributeString( "txtboxFMpoetry", txtboxFMpoetry.Text );
							writer.WriteAttributeString( "txtboxFMantique", txtboxFMantique.Text );
							writer.WriteAttributeString( "txtboxFMscience", txtboxFMscience.Text );
							writer.WriteAttributeString( "txtboxFMcomputers", txtboxFMcomputers.Text );
							writer.WriteAttributeString( "txtboxFMreference", txtboxFMreference.Text );
							writer.WriteAttributeString( "txtboxFMnonfiction", txtboxFMnonfiction.Text );
							writer.WriteAttributeString( "txtboxFMreligion", txtboxFMreligion.Text );
							writer.WriteAttributeString( "txtboxFMhumor", txtboxFMhumor.Text );
							writer.WriteAttributeString( "txtboxFMhome", txtboxFMhome.Text );
							writer.WriteAttributeString( "txtboxFMbusiness", txtboxFMbusiness.Text );
							writer.WriteAttributeString( "txtboxFMtech", txtboxFMtech.Text );
							writer.WriteAttributeString( "txtboxFMmilitary", txtboxFMmilitary.Text );
							writer.WriteAttributeString( "txtboxFMfolklore", txtboxFMfolklore.Text );
							writer.WriteAttributeString( "txtboxFMother", txtboxFMother.Text );
						writer.WriteFullEndElement();
						
					writer.WriteEndElement();
					
				writer.WriteEndElement();
				writer.Flush();
			}  finally  {
				if (writer != null)
				writer.Close();
			}
			#endregion
		}
		
		#endregion
		
		#region �����������
				
		void BtnOKClick(object sender, EventArgs e)
		{
			// �������� �� �������� �����
			if( txtBoxFMNoGenreGroup.Text.Trim().Length==0 || txtBoxFMNoGenre.Text.Trim().Length==0 ||
				txtBoxFMNoLang.Text.Trim().Length==0 || txtBoxFMNoFirstName.Text.Trim().Length==0 ||
				txtBoxFMNoMiddleName.Text.Trim().Length==0 || txtBoxFMNoLastName.Text.Trim().Length==0 ||
				txtBoxFMNoNickName.Text.Trim().Length==0 || txtBoxFMNoBookTitle.Text.Trim().Length==0 ||
				txtBoxFMNoSequence.Text.Trim().Length==0 || txtBoxFMNoNSequence.Text.Trim().Length==0 ||
				txtBoxFMNoDateText.Text.Trim().Length==0 || txtBoxFMNoDateValue.Text.Trim().Length==0 ) {
					MessageBox.Show( "������� '�����������' -> ������� '����� ���������� ���� ��� ������' -> ������� '�����'\n�������� ����� ������ ����� ���� �� 1 ������!",
				                "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			} else if ( txtBoxFMNoYear.Text.Trim().Length==0 || txtBoxFMNoPublisher.Text.Trim().Length==0 ||
			          txtBoxFMNoCity.Text.Trim().Length==0 ) {
				MessageBox.Show( "������� '�����������' -> ������� '����� ���������� ���� ��� ������' -> ������� '������������'\n�������� ����� ������ ����� ���� �� 1 ������!",
				                "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			} else if ( txtBoxFMNoFB2FirstName.Text.Trim().Length==0 || txtBoxFMNoFB2MiddleName.Text.Trim().Length==0 ||
						txtBoxFMNoFB2LastName.Text.Trim().Length==0 || txtBoxFMNoFB2NickName.Text.Trim().Length==0 ) {
				MessageBox.Show( "������� '�����������' -> ������� '����� ���������� ���� ��� ������' -> ������� 'FB2-����'\n�������� ����� ������ ����� ���� �� 1 ������!",
				                "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
				
			} else if( txtboxFMsf.Text.Trim().Length==0 || txtboxFMdetective.Text.Trim().Length==0 ||
			          txtboxFMprose.Text.Trim().Length==0 || txtboxFMlove.Text.Trim().Length==0 || 
			          txtboxFMadventure.Text.Trim().Length==0 || txtboxFMchildren.Text.Trim().Length==0 || 
			          txtboxFMpoetry.Text.Trim().Length==0 || txtboxFMantique.Text.Trim().Length==0 || 
			          txtboxFMscience.Text.Trim().Length==0 || txtboxFMcomputers.Text.Trim().Length==0 || 
			          txtboxFMreference.Text.Trim().Length==0 || txtboxFMnonfiction.Text.Trim().Length==0 || 
			          txtboxFMreligion.Text.Trim().Length==0 || txtboxFMhumor.Text.Trim().Length==0 || 
			          txtboxFMhome.Text.Trim().Length==0 || txtboxFMbusiness.Text.Trim().Length==0 ||
			          txtboxFMtech.Text.Trim().Length==0 || txtboxFMmilitary.Text.Trim().Length==0 ||
			          txtboxFMfolklore.Text.Trim().Length==0 || txtboxFMother.Text.Trim().Length==0) {
							MessageBox.Show( "������� '�����������', ������� '������ ������'\n�������� ����� ������ ����� ���� �� 1 ������!",
				                "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			// ���������� �������� � ini
			WriteSettings();
			this.Close();
		}
		
		#region �����
		void BtnWinRarPathClick(object sender, EventArgs e)
		{
			// �������� ���� � WinRar
			ofDlg.Title = "������� ���� � WinRar:";
			ofDlg.FileName = "";
			ofDlg.Filter = "WinRAR.exe|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxWinRarPath.Text = ofDlg.FileName;
            }
		}

		void BtnRarPathClick(object sender, EventArgs e)
		{
			// �������� ���� � Rar (�����������)
			ofDlg.Title = "������� ���� � Rar (�����������):";
			ofDlg.FileName = "";
			ofDlg.Filter = "Rar.exe|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxRarPath.Text = ofDlg.FileName;
            }
		}
		
		void BtnUnRarPathClick(object sender, EventArgs e)
		{
			// �������� ���� � UnRar (�����������)
			ofDlg.Title = "������� ���� � UnRar (�����������):";
			ofDlg.FileName = "";
			ofDlg.Filter = "UnRar.exe|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxUnRarPath.Text = ofDlg.FileName;
            }
		}
		
		void Btn7zaPathClick(object sender, EventArgs e)
		{
			// �������� ���� � 7za (�����������)
			ofDlg.Title = "������� ���� � 7z(a) (�����������):";
			ofDlg.FileName = "";
			ofDlg.Filter = "��������� (*.exe)|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tbox7zaPath.Text = ofDlg.FileName;
            }
		}
		
		void BtnFBEPathClick(object sender, EventArgs e)
		{
			// �������� ���� � fb2-���������
			ofDlg.Title = "������� ���� � FB2-���������:";
			ofDlg.FileName = "";
			ofDlg.Filter = "��������� (*.exe)|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxFBEPath.Text = ofDlg.FileName;
            }
		}
		
		void BtnTextEPathClick(object sender, EventArgs e)
		{
			// �������� ���� � ���������� ��������� fb2-������
			ofDlg.Title = "������� ���� � ���������� ��������� fb2-������:";
			ofDlg.FileName = "";
			ofDlg.Filter = "��������� (*.exe)|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxTextEPath.Text = ofDlg.FileName;
            }
		}
		
		void BtnReaderPathClick(object sender, EventArgs e)
		{
			// �������� ���� � ������� fb2-������
			ofDlg.Title = "������� ���� � ������� fb2-������:";
			ofDlg.FileName = "";
			ofDlg.Filter = "��������� (*.exe)|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxReaderPath.Text = ofDlg.FileName;
            }
		}
		
		void BtnDiffPathClick(object sender, EventArgs e)
		{
			// �������� ���� � diff-���������
			ofDlg.Title = "������� ���� � diff-��������� ����������� ��������� ������:";
			ofDlg.FileName = "";
			ofDlg.Filter = "��������� (*.exe)|*.exe|��� ����� (*.*)|*.*";
			DialogResult result = ofDlg.ShowDialog();
			if (result == DialogResult.OK) {
                tboxDiffPath.Text = ofDlg.FileName;
            }
		}
		
		void CboxDSValidatorSelectedIndexChanged(object sender, EventArgs e)
		{
			cboxTIRValidator.Enabled = cboxDSValidator.SelectedIndex == 2;
		}
		
		void CboxDSFileManagerSelectedIndexChanged(object sender, EventArgs e)
		{
			cboxTIRFileManager.Enabled = cboxDSFileManager.SelectedIndex == 2;
		}
		
		void CboxDSArchiveManagerSelectedIndexChanged(object sender, EventArgs e)
		{
			cboxTIRArchiveManager.Enabled = cboxDSArchiveManager.SelectedIndex == 2;
		}
		
		void CboxDSFB2DupSelectedIndexChanged(object sender, EventArgs e)
		{
			cboxTIRFB2Dup.Enabled = cboxDSFB2Dup.SelectedIndex == 2;
		}
		#endregion

		#region �������� ������
		void CboxFileExistSelectedIndexChanged(object sender, EventArgs e)
		{
			chBoxAddToFileNameBookID.Visible = cboxFileExist.SelectedIndex != 0;
			if( cboxFileExist.SelectedIndex == 0 ) {
				chBoxAddToFileNameBookID.Checked = false;
			}
		}
		
		#endregion
		
		#region �������������� ��-���������
		void BtnDefRestoreClick(object sender, EventArgs e) {
			switch( tcOptions.SelectedIndex ) {
				case 0: // �����
					DefGeneral();
					break;
				case 1: // ���������
					DefValidator();
					break;
				case 2: // �������� ������
					switch( tcFM.SelectedIndex ) {
						case 0: // �������� - ��� ��������� ������
							DefFMGeneral();
							break;
						case 1: // �������� ����� ���������� ���� ��� ������
							switch( tcDesc.SelectedIndex ) {
								case 0: // �������� ��� ������ ����� �� Description ����� ��� ������ ����
									DefFMDirNameForTagNotData();
									break;
								case 1: // �������� ��� ������ ������������ �� Description ����� ��� ������ ����
									DefFMDirNameForPublisherTagNotData();
									break;
								case 2: // �������� ��� ������ fb2-����� �� Description ����� ��� ������ ����
									DefFMDirNameForFB2TagNotData();
									break;
							}
							break;
						case 2: // �������� ����� ������
							DefFMGenresGroups();
							break;
					}
					break;
			}
		}
		#endregion
		
		#endregion

	}
}
