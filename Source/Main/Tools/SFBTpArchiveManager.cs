﻿/*
 * Created by SharpDevelop.
 * User: Вадим Кузнецов (DikBSD)
 * Date: 16.03.2009
 * Time: 9:55
 * 
 * License: GPL 2.1
 */

using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

using FB2.Description.DocumentInfo;
using StringProcessing;
using FilesWorker;

namespace SharpFBTools.Tools
{
	/// <summary>
	/// Description of SFBTpArchiveManager.
	/// </summary>
	public partial class SFBTpArchiveManager : UserControl
	{
		#region Закрытые члены-данные класса
		private string m_sReady = "Готово.";
		#endregion
		
		public SFBTpArchiveManager()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			InitA();	// инициализация контролов (Упаковка)
			InitUA();	// инициализация контролов (Распаковка
			cboxExistArchive.SelectedIndex		= 1; // добавление к создаваемому fb2-архиву очередного номера
			cboxArchiveType.SelectedIndex		= 1; // Zip
			cboxUAExistArchive.SelectedIndex	= 1; // добавление к создаваемому fb2-файлу очередного номера
			cboxUAType.SelectedIndex			= 6; // Все архивы
		}
		
		#region Закрытые Общие Вспомогательны методы класса
		private void InitA() {
			// инициализация контролов и переменных  (Упаковка)
			for( int i=0; i!=lvGeneralCount.Items.Count; ++i ) {
				lvGeneralCount.Items[i].SubItems[1].Text = "0";
			}
			tsProgressBar.Value		= 1;
			tsslblProgress.Text		= m_sReady;
			tsProgressBar.Visible	= false;
		}
		
		private void InitUA() {
			// инициализация контролов и переменных  (Распаковка)
			for( int i=0; i!=lvUAGeneralCount.Items.Count; ++i ) {
				lvUAGeneralCount.Items[i].SubItems[1].Text = "0";
			}
			for( int i=0; i!=lvUACount.Items.Count; ++i ) {
				lvUACount.Items[i].SubItems[1].Text = "0";
			}
			tsProgressBar.Value		= 1;
			tsslblProgress.Text		= m_sReady;
			tsProgressBar.Visible	= false;
		}
		
		private string ExistsFB2FileFileToDirWorker( string sFromFile, string sNewFile, string sSufix ) {
			// Обработка существующих в папке-приемнике файлов при копировании
			if( File.Exists( sNewFile ) ) {
				if( cboxUAExistArchive.SelectedIndex==0 ) {
					File.Delete( sNewFile );
				} else {
					if( chBoxAddFileNameBookID.Checked ) {
						try {
							sSufix = "_" + StringProcessing.StringProcessing.GetBookID( sFromFile );
						} catch { }
					}
					if( cboxUAExistArchive.SelectedIndex == 1 ) {
						// Добавить к создаваемому файлу очередной номер
						sSufix += "_" + StringProcessing.StringProcessing.GetFileNewNumber( sNewFile ).ToString();
					} else {
						// Добавить к создаваемому файлу дату и время
						sSufix += "_" + StringProcessing.StringProcessing.GetDateTimeExt();
					}
					sNewFile = sNewFile.Remove( sNewFile.Length-4 ) + sSufix + ".fb2";
				}
			}
			return sNewFile;
		}
		
		private bool FileToDir( string sFile, string sArchiveFile, string sTargetDir, bool bFB2 ) {
			// Переместить в папку
			// bFB2=true - копировать только fb2-файлы. false - любые
			if( bFB2 && Path.GetExtension( sFile ).ToLower() != ".fb2" ) return false;
			
			Regex rx = new Regex( @"\\+" );
			sFile = rx.Replace( sFile, "\\" );
			sArchiveFile = rx.Replace( sArchiveFile, "\\" );
			
			string sFileSourceDir = tboxUASourceDir.Text.Trim();
			string sNewDir = Path.GetDirectoryName( sTargetDir+"\\"+sArchiveFile.Remove( 0, sFileSourceDir.Length ) );
			string sNewFile = "";
			string sSufix = ""; // для добавления к имени нового файла суфикса
			string sFromFile = Settings.Settings.GetTempDir() + "\\" + sFile;
			if( rbtnUAToSomeDir.Checked ) {
				// файл - в ту же папку, где и исходный архив
				sNewFile = Path.GetDirectoryName( sArchiveFile )+"\\"+sFile;
				// Обработка существующих в папке-приемнике файлов при копировании
				sNewFile = ExistsFB2FileFileToDirWorker( sFromFile, sNewFile, sSufix );
			} else {
				// файл - в другую папку
				sNewFile = sNewDir + "\\" + sFile;
				FileInfo fi = new FileInfo( sNewFile );
				if( !fi.Directory.Exists ) {
					Directory.CreateDirectory( fi.Directory.ToString() );
				}
				// Обработка существующих в папке-приемнике файлов при копировании
				sNewFile = ExistsFB2FileFileToDirWorker( sFromFile, sNewFile, sSufix );
			}
			File.Move( Settings.Settings.GetTempDir()+"\\"+sFile, sNewFile );
			return true;
		}
		
		#endregion
		
		#region Архивация
		private void FileToArchive( string sArchPath, List<string> lFilesList, bool bZip, ToolStripProgressBar pBar ) {
			// упаковка fb2-файлов в .fb2.??? - где ??? - тип архива (задается в cboxArchiveType)
			#region Код
			long lFB2 = 0;
			foreach( string sFile in lFilesList ) {
				string sExt = Path.GetExtension( sFile );
				if( sExt.ToLower() == ".fb2" ) {
					lvGeneralCount.Items[2].SubItems[1].Text = (++lFB2).ToString();
					lvGeneralCount.Refresh();
					// упаковываем
					string sArchiveFile = "";
					string sDotExt = "."+StringProcessing.StringProcessing.GetArchiveExt( cboxArchiveType.Text );
					string sSufix = ""; // для добавления к имени нового архива суфикса
					if( rbtnToSomeDir.Checked ) {
						// создаем архив в той же папке, где и исходный fb2-файл
						sArchiveFile = sFile + sDotExt;
						if( File.Exists( sArchiveFile ) ) {
							if( cboxExistArchive.SelectedIndex==0 ) {
								File.Delete( sArchiveFile );
							} else {
								if( chBoxAddArchiveNameBookID.Checked ) {
									try {
										sSufix = "_" + StringProcessing.StringProcessing.GetBookID( sFile );
									} catch { }
								}
								if( cboxExistArchive.SelectedIndex == 1 ) {
									// Добавить к создаваемому файлу очередной номер
									sSufix += "_" + StringProcessing.StringProcessing.GetFileNewNumber( sFile ).ToString();
								} else {
									// Добавить к создаваемому файлу дату и время
									sSufix += "_" + StringProcessing.StringProcessing.GetDateTimeExt();
								}
								sArchiveFile = sFile.Remove( sFile.Length-4 ) + sSufix + ".fb2" + sDotExt;
							}
						}
					} else {
						// создаем архив в другой папке
						string sSource = tboxSourceDir.Text.Trim();
						string sTarget = tboxToAnotherDir.Text.Trim();
						string sNewFilePath = sFile.Remove( 0, sSource.Length );
						sArchiveFile = sTarget + sNewFilePath + sDotExt;
						FileInfo fi = new FileInfo( sArchiveFile );
						if( !fi.Directory.Exists ) {
							Directory.CreateDirectory( fi.Directory.ToString() );
						}
						if( File.Exists( sArchiveFile ) ) {
							if( cboxExistArchive.SelectedIndex==0 ) {
								File.Delete( sArchiveFile );
							} else {
								if( chBoxAddArchiveNameBookID.Checked ) {
									try {
										sSufix = "_" + StringProcessing.StringProcessing.GetBookID( sFile );
									} catch { }
								}
								if( cboxExistArchive.SelectedIndex == 1 ) {
									// Добавить к создаваемому файлу очередной номер
									sSufix += "_" + StringProcessing.StringProcessing.GetFileNewNumber( sArchiveFile ).ToString();
								} else {
									// Добавить к создаваемому файлу дату и время
									sSufix += "_" + StringProcessing.StringProcessing.GetDateTimeExt();
								}
								sArchiveFile = sTarget + sNewFilePath.Remove( sNewFilePath.Length-4 ) + sSufix + ".fb2" + sDotExt;
							}
						}
					}
					if( bZip ) {
						FilesWorker.Archiver.zip( sArchPath, cboxArchiveType.Text.ToLower(), sFile, sArchiveFile );
					} else {
						FilesWorker.Archiver.rar( sArchPath, sFile, sArchiveFile, cboxAddRestoreInfo.Checked );
					}
					
					if( cboxDelFB2Files.Checked ) {
						// удаляем исходный fb2-файл
						if( File.Exists( sFile ) ) {
							File.Delete( sFile );
						}
					}
				}
				++pBar.Value;
			}
			#endregion
		}
		#endregion
				
		#region Распаковка
		private bool DeleteSourceFileIsNeeds( string sFile ) {
			if( cboxUADelFB2Files.Checked ) {
				// удаляем исходный архив
				if( File.Exists( sFile ) ) {
					File.Delete( sFile );
					return true;
				}
			}
			return false;
		}
		
		private long AllArchivesToFile( List<string> lFilesList, string sMoveToDir, ToolStripProgressBar pBar ) {
			// Распаковать все архивы
			long lCount, lFB2, lRar, lZip, l7Z, lBZip2, lGZip, lTar;
			lCount = lFB2 = lRar = lZip = l7Z = lBZip2 = lGZip = lTar = 0;
			string sTempDir = Settings.Settings.GetTempDir();
			foreach( string sFile in lFilesList ) {
				string sExt = Path.GetExtension( sFile );
				if( sExt.ToLower() != "" ) {
					FilesWorker.FilesWorker.RemoveDir( sTempDir );
					string s7zaPath		= Settings.Settings.Read7zaPath();
					string sUnRarPath	= Settings.Settings.ReadUnRarPath();
					switch( sExt.ToLower() ) {
						case ".rar":
							FilesWorker.Archiver.unrar( sUnRarPath, sFile, sTempDir );
							lvUACount.Items[0].SubItems[1].Text = (++lRar).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
						case ".zip":
							FilesWorker.Archiver.unzip( s7zaPath, sFile, sTempDir );
							lvUACount.Items[1].SubItems[1].Text = (++lZip).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
						case ".7z":
							FilesWorker.Archiver.unzip( s7zaPath, sFile, sTempDir );
							lvUACount.Items[2].SubItems[1].Text = (++l7Z).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
						case ".bz2":
							FilesWorker.Archiver.unzip( s7zaPath, sFile, sTempDir );
							lvUACount.Items[3].SubItems[1].Text = (++lBZip2).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
						case ".gz":
							FilesWorker.Archiver.unzip( s7zaPath, sFile, sTempDir );
							lvUACount.Items[4].SubItems[1].Text = (++lGZip).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
						case ".tar":
							FilesWorker.Archiver.unzip( s7zaPath, sFile, sTempDir );
							lvUACount.Items[5].SubItems[1].Text = (++lTar).ToString();
							++lCount;
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
							break;
					}
					if( Directory.Exists( sTempDir ) ) {
						lvUAGeneralCount.Items[2].SubItems[1].Text = (lCount).ToString();
						string [] files = Directory.GetFiles( sTempDir );
						foreach( string sFB2File in files ) {
							string sFileName = Path.GetFileName( sFB2File );
							if( Path.GetExtension( sFileName )==".fb2" ) {
								lvUAGeneralCount.Items[3].SubItems[1].Text = (++lFB2).ToString();
							}
							if( FileToDir( sFileName, sFile, sMoveToDir, false ) ) {
								
							} else {
								File.Delete( sFileName );
							}
						}
					}
					lvUAGeneralCount.Refresh();
					lvUACount.Refresh();
				}
				++pBar.Value;
			}
			return lCount;
		}
		
		private long TypeArchToFile( List<string> lFilesList, string sMoveToDir, ToolStripProgressBar pBar,
		                   string sExt, int nArchCountItem, int nFB2CountItem ) {
			// Распаковать выбранный тип ахрива
			long lCount = 0;
			long lAllArchive = 0;
			long lFB2 = 0;
			string sTempDir = Settings.Settings.GetTempDir();
			foreach( string sFile in lFilesList ) {
				if( Path.GetExtension( sFile.ToLower() ) == sExt ) {
					FilesWorker.Archiver.unzip( Settings.Settings.Read7zaPath(), sFile, sTempDir );
					lvUAGeneralCount.Items[2].SubItems[1].Text = (++lAllArchive).ToString();
					lvUACount.Items[nArchCountItem].SubItems[1].Text = (++lCount).ToString();
					if( Directory.Exists( sTempDir ) ) {
						string [] files = Directory.GetFiles( sTempDir );
						foreach( string sFB2File in files ) {
							string sFileName = Path.GetFileName( sFB2File );
							if( Path.GetExtension( sFileName )==".fb2" ) {
								lvUAGeneralCount.Items[nFB2CountItem].SubItems[1].Text = (++lFB2).ToString();
							}
							if( FileToDir( sFileName, sFile, sMoveToDir, false ) ) {
								
							} else {
								File.Delete( sFileName );
							}
						}
					}
					// удаление исходного архива, если включена опция
					DeleteSourceFileIsNeeds( sFile );
				}
				lvUAGeneralCount.Refresh();
				lvUACount.Refresh();
				++pBar.Value;
			}
			return lCount;
		}
		
		private long ArchivesToFile( List<string> lFilesList, string sMoveToDir, ToolStripProgressBar pBar ) {
			// Распаковать ахривы
			string sArchType = StringProcessing.StringProcessing.GetArchiveExt( cboxUAType.Text );
			long lAllArchive, lRar, lFB2, lCount;
			lAllArchive = lRar = lFB2 = lCount = 0;
			string sTempDir = Settings.Settings.GetTempDir();
			FilesWorker.FilesWorker.RemoveDir( sTempDir );
			switch( sArchType.ToLower() ) {
				case "":
					lCount = AllArchivesToFile( lFilesList, sMoveToDir, pBar );
					break;
				case "rar":
					foreach( string sFile in lFilesList ) {
						string sExt = Path.GetExtension( sFile );
						if( sExt.ToLower() == ".rar" ) {
							FilesWorker.Archiver.unrar( Settings.Settings.ReadUnRarPath(), sFile, sTempDir );
							lvUAGeneralCount.Items[2].SubItems[1].Text = (++lAllArchive).ToString();
							lvUACount.Items[0].SubItems[1].Text = (++lRar).ToString();
							if( Directory.Exists( sTempDir ) ) {
								string [] files = Directory.GetFiles( sTempDir );
								foreach( string sFB2File in files ) {
									string sFileName = Path.GetFileName( sFB2File );
									if( Path.GetExtension( sFileName )==".fb2" ) {
										lvUAGeneralCount.Items[3].SubItems[1].Text = (++lFB2).ToString();
									}
									if( FileToDir( sFileName, sFile, sMoveToDir, false ) ) {
										
									}  else {
										File.Delete( sFileName );
									}
								}
							}
							// удаление исходного архива, если включена опция
							DeleteSourceFileIsNeeds( sFile );
						}
						lvUAGeneralCount.Refresh();
						lvUACount.Refresh();
						++pBar.Value;
						lCount = lRar;
					}
					break;
				case "zip":
					lCount = TypeArchToFile( lFilesList, sMoveToDir, pBar, ".zip", 1, 3 );
					break;
				case "7z":
					lCount = TypeArchToFile( lFilesList, sMoveToDir, pBar, ".7z", 2, 3 );
					break;
				case "bz2":
					lCount = TypeArchToFile( lFilesList, sMoveToDir, pBar, ".bz2", 3, 3 );
					break;
				case "gz":
					lCount = TypeArchToFile( lFilesList, sMoveToDir, pBar, ".gz", 4, 3 );
					break;
				case "tar":
					lCount = TypeArchToFile( lFilesList, sMoveToDir, pBar, ".tar", 5, 3 );
					break;
			}
			return lCount;
		}
		#endregion
		
		#region Обработчики событий
		void TsbtnOpenDirClick(object sender, EventArgs e)
		{
			// задание папки с fb2-файлами для сканирования (Архивация)
			if( FilesWorker.FilesWorker.OpenDirDlg( tboxSourceDir, fbdDir, "Укажите папку с fb2-файлами для Упаковки" ) ) {
				InitA();
			}
		}
		void BtnToAnotherDirClick(object sender, EventArgs e)
		{
			// задание папки для копирования запакованных fb2-файлов
			FilesWorker.FilesWorker.OpenDirDlg( tboxToAnotherDir, fbdDir, "Укажите папку для размещения упакованных fb2-файлов" );
		}
		void TsbtnUAOpenDirClick(object sender, EventArgs e)
		{
			// задание папки с fb2-архивами для сканирования (Распаковка)
			if( FilesWorker.FilesWorker.OpenDirDlg( tboxUASourceDir, fbdDir, "Укажите папку с fb2-архивами для Распаковки" ) ) {
				InitUA();
			}
		}
		void BtnUAToAnotherDirClick(object sender, EventArgs e)
		{
			// задание папки для копирования распакованных файлов
			FilesWorker.FilesWorker.OpenDirDlg( tboxUAToAnotherDir, fbdDir, "Укажите папку для размещения распакованных файлов" );
		}
		
		void RbtnToAnotherDirCheckedChanged(object sender, EventArgs e)
		{
			btnToAnotherDir.Enabled = rbtnToAnotherDir.Checked;
			tboxToAnotherDir.ReadOnly = !rbtnToAnotherDir.Checked;
			if( rbtnToAnotherDir.Checked ) {
				tboxToAnotherDir.Focus();
			}
		}
		
		void CboxArchiveTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			cboxAddRestoreInfo.Visible = cboxArchiveType.SelectedIndex == 0;
		}
		
		void TsbtnArchiveClick(object sender, EventArgs e)
		{
			// Запаковка fb2-файлов
			string sSource = tboxSourceDir.Text.Trim();
			string sTarget = tboxToAnotherDir.Text.Trim();
			// проверки перед запуском архивации
			if( sSource == "" ) {
				MessageBox.Show( "Выберите папку для сканирования!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DirectoryInfo diFolder = new DirectoryInfo( sSource );
			if( !diFolder.Exists ) {
				MessageBox.Show( "Папка для сканирования не найдена:" + tboxSourceDir.Text, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			if( rbtnToAnotherDir.Checked ) {
				if( sTarget == "" ) {
					MessageBox.Show( "Не задана папка-приемник архивов!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return;
				} else {
					DirectoryInfo df = new DirectoryInfo( sTarget );
					if( !df.Exists ) {
						MessageBox.Show( "Папка-приемник не найдена:" + sTarget, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
						return;
					}
				}
			}
			// читаем путь к архиваторам из настроек
			string s7zPath = Settings.Settings.Read7zaPath();
			string sRarPath = Settings.Settings.ReadRarPath();
			if( cboxArchiveType.SelectedIndex == 0 && sRarPath.Trim() == "" ) {
				MessageBox.Show( "Не указана папка с установленным консольным Rar-архиватором!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			// проверка на наличие архиваторов
			if( cboxArchiveType.SelectedIndex == 0 ) {
				if( !File.Exists( sRarPath ) ) {
					MessageBox.Show( "Не найден файл консольного Rar-архиватора "+sRarPath+"!\nРабота остановлена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return;
				} else {
					tsslblProgress.Text = "Упаковка найденных файлов в rar:";
				}
			} else {
				if( !File.Exists( s7zPath ) ) {
					MessageBox.Show( "Не найден файл Zip-архиватора \""+s7zPath+"\"!\nРабота остановлена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return;
				} else {
					tsslblProgress.Text = "Упаковка найденных файлов в zip:";
				}
			}
			// Упаковываем fb2-файлы
			DateTime dtStart = DateTime.Now;
			InitA();
			tsProgressBar.Visible = true;
			// сортированный список всех вложенных папок
			List<string> lDirList = new List<string>();
			if( !cboxScanSubDirToArchive.Checked ) {
				// сканировать только указанную папку
				lDirList.Add( diFolder.FullName );
				lvGeneralCount.Items[0].SubItems[1].Text = "1";
				lvGeneralCount.Refresh();
			} else {
				// сканировать и все подпапки
				lDirList = FilesWorker.FilesWorker.DirsParser( diFolder.FullName, lvGeneralCount );
				lDirList.Sort();
			}
			// сортированный список всех файлов
			tsslblProgress.Text = "Создание списка файлов:";
			List<string> lFilesList = FilesWorker.FilesWorker.AllFilesParser( lDirList, ssProgress, lvGeneralCount, tsProgressBar );
			lFilesList.Sort();
			
			if( lFilesList.Count == 0 ) {
				MessageBox.Show( "Не найдено ни одного файла!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				InitA();
				return;
			}
			tsslblProgress.Text = "Упаковка файлов:";
			tsProgressBar.Maximum = lFilesList.Count+1;
			tsProgressBar.Value = 1;
			ssProgress.Refresh();
			if( cboxArchiveType.SelectedIndex == 0 ) {
				FileToArchive( sRarPath, lFilesList, false, tsProgressBar ); // rar
			} else {
				FileToArchive( s7zPath, lFilesList, true, tsProgressBar ); // zip, 7z...
			}
			DateTime dtEnd = DateTime.Now;
			string sTime = dtEnd.Subtract( dtStart ).ToString() + " (час.:мин.:сек.)";
			MessageBox.Show( "Упаковка fb2-файлов завершена!\nЗатрачено времени: "+sTime, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
		}

		void RbtnUAToAnotherDirCheckedChanged(object sender, EventArgs e)
		{
			btnUAToAnotherDir.Enabled = rbtnUAToAnotherDir.Checked;
			tboxUAToAnotherDir.ReadOnly = !rbtnUAToAnotherDir.Checked;
			if( rbtnUAToAnotherDir.Checked ) {
				tboxUAToAnotherDir.Focus();
			}
		}
		
		void TsbtnUAAnalyzeClick(object sender, EventArgs e)
		{
			// анализ файлов - какие архивы есть в папке сканирования
			string sSource = tboxUASourceDir.Text.Trim();
			if( sSource == "" ) {
				MessageBox.Show( "Выберите папку для сканирования!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DirectoryInfo diFolder = new DirectoryInfo( sSource );
			if( !diFolder.Exists ) {
				MessageBox.Show( "Папка для сканирования не найдена:" + sSource, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DateTime dtStart = DateTime.Now;
			InitUA();
			tsProgressBar.Visible = true;
			// сортированный список всех вложенных папок
			List<string> lDirList = new List<string>();
			if( !cboxScanSubDirToUnArchive.Checked ) {
				// сканировать только указанную папку
				lDirList.Add( diFolder.FullName );
				lvUAGeneralCount.Items[0].SubItems[1].Text = "1";
				lvUAGeneralCount.Refresh();
			} else {
				// сканировать и все подпапки
				lDirList = FilesWorker.FilesWorker.DirsParser( diFolder.FullName, lvUAGeneralCount );
				lDirList.Sort();
			}
			ssProgress.Refresh();
			// сортированный список всех файлов
			tsslblProgress.Text = "Создание списка файлов:";
			gboxUACount.Refresh();
			List<string> lFilesList = FilesWorker.FilesWorker.AllFilesParser( lDirList, ssProgress, lvUAGeneralCount, tsProgressBar );
			lFilesList.Sort();
			
			if( lFilesList.Count == 0 ) {
				MessageBox.Show( "В указанной папке не найдено ни одного файла!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
			}
			tsslblProgress.Text = "Анализ файлов на наличие архивов:";
			tsProgressBar.Maximum = lFilesList.Count+1;
			tsProgressBar.Value = 1;
			ssProgress.Refresh();
			gboxUACount.Refresh();

			long lRar, lZip, l7Z, lBZip2, lGZip, lTar;
			lRar = lZip = l7Z = lBZip2 = lGZip = lTar = 0;
			foreach( string sFile in lFilesList ) {
				string sExt = Path.GetExtension( sFile );
				if( sExt.ToLower() == ".rar" )
					lvUACount.Items[0].SubItems[1].Text = (++lRar).ToString();
				else if( sExt.ToLower() == ".zip" )
					lvUACount.Items[1].SubItems[1].Text = (++lZip).ToString();
				else if( sExt.ToLower() == ".7z" )	
					lvUACount.Items[2].SubItems[1].Text = (++l7Z).ToString();
				else if( sExt.ToLower() == ".bz2" )	
					lvUACount.Items[3].SubItems[1].Text = (++lBZip2).ToString();
				else if( sExt.ToLower() == ".gz" )	
					lvUACount.Items[4].SubItems[1].Text = (++lGZip).ToString();
				else if( sExt.ToLower() == ".tar" )
					lvUACount.Items[5].SubItems[1].Text = (++lTar).ToString();
				++tsProgressBar.Value;
			}
			
			DateTime dtEnd = DateTime.Now;
			string sTime = dtEnd.Subtract( dtStart ).ToString() + " (час.:мин.:сек.)";
			MessageBox.Show( "Анализ имеющихся файлов завершена!\nЗатрачено времени: "+sTime, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
		}
		
		void TsbtnUnArchiveClick(object sender, EventArgs e)
		{
			// Распаковка архивов
			string sSource = tboxUASourceDir.Text.Trim();
			string sTarget = tboxUAToAnotherDir.Text.Trim();
			if( sSource == "" ) {
				MessageBox.Show( "Выберите папку для сканирования!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DirectoryInfo diFolder = new DirectoryInfo( sSource );
			if( !diFolder.Exists ) {
				MessageBox.Show( "Папка для сканирования не найдена:" + sSource, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			if( rbtnUAToAnotherDir.Checked ) {
				if( sTarget == "") {
					MessageBox.Show( "Не указана папка-приемник файлов!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return;
				} else {
					DirectoryInfo df = new DirectoryInfo( sTarget );
					if( !df.Exists ) {
						MessageBox.Show( "Папка-приемник не найдена:" + sTarget, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
						return;
					}
				}
				if( sTarget == sSource ) {
					MessageBox.Show( "Папка-приемник файлов совпадает с папкой сканирования!\nРабота прекращена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
					return;
				}
			}
			
			// читаем путь к UnRar из настроек
			string sUnRarPath = Settings.Settings.ReadUnRarPath();
			if( sUnRarPath.Trim() == "" ) {
				MessageBox.Show( "Не указана папка с установленным консольным UnRar.exe!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return;
			}
			DateTime dtStart = DateTime.Now;
			InitUA();
			tsProgressBar.Visible = true;
			// сортированный список всех вложенных папок
			List<string> lDirList = new List<string>();
			if( !cboxScanSubDirToUnArchive.Checked ) {
				// сканировать только указанную папку
				lDirList.Add( diFolder.FullName );
				lvUAGeneralCount.Items[0].SubItems[1].Text = "1";
				lvUAGeneralCount.Refresh();
			} else {
				// сканировать и все подпапки
				lDirList = FilesWorker.FilesWorker.DirsParser( diFolder.FullName, lvUAGeneralCount );
				lDirList.Sort();
			}
			// сортированный список всех файлов
			tsslblProgress.Text = "Создание списка файлов:";
			gboxUACount.Refresh();
			List<string> lFilesList = FilesWorker.FilesWorker.AllFilesParser( lDirList, ssProgress, lvUAGeneralCount, tsProgressBar );
			lFilesList.Sort();
			
			if( lFilesList.Count == 0 ) {
				MessageBox.Show( "В указанной папке не найдено ни одного файла!", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Warning );
			}
			tsslblProgress.Text = "Распаковка архивов:";
			tsProgressBar.Maximum = lFilesList.Count+1;
			tsProgressBar.Value = 1;
			ssProgress.Refresh();
			gboxUACount.Refresh();

			long lCount = ArchivesToFile( lFilesList, sTarget, tsProgressBar );
			
			DateTime dtEnd = DateTime.Now;
			string sTime = dtEnd.Subtract( dtStart ).ToString() + " (час.:мин.:сек.)";
			if( lCount > 0 ) {
				MessageBox.Show( "Распаковка архивов завершена!\nЗатрачено времени: "+sTime, "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			} else {
				MessageBox.Show( "В папке для сканирования не найдено ни одного архива указанного типа!\nРаспаковка не произведена.", "SharpFBTools", MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
			tsslblProgress.Text = m_sReady;
			tsProgressBar.Visible = false;
		}
		
		void CboxExistArchiveSelectedIndexChanged(object sender, EventArgs e)
		{
			chBoxAddArchiveNameBookID.Enabled = ( cboxExistArchive.SelectedIndex != 0 );
		}
		
		void CboxUAExistArchiveSelectedIndexChanged(object sender, EventArgs e)
		{
			chBoxAddFileNameBookID.Enabled = ( cboxUAExistArchive.SelectedIndex != 0 );
		}
		#endregion
	}
}