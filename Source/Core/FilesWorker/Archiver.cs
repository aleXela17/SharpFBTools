﻿/*
 * Created by SharpDevelop.
 * User: Вадим Кузнецов (DikBSD)
 * Date: 09.03.2009
 * Time: 9:41
 * 
 * License: GPL 2.1
 */

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;


namespace FilesWorker
{
	/// <summary>
	/// Description of Archiver.
	/// </summary>
	public class Archiver
	{
		public Archiver()
		{
		}

		public static int debug_unzip( List<string> gebug, string sZipPath, string sFilePath, string sTempDir ) {
			// распаковка zip-фрхива
			Regex rx = new Regex( @"\\+" );
			sZipPath = rx.Replace( sZipPath, "\\" );
			sFilePath = rx.Replace( sFilePath, "\\" );
			sTempDir = rx.Replace( sTempDir, "\\" );
			
			if( !Directory.Exists( sTempDir ) ) {
				Directory.CreateDirectory( sTempDir );
			}
			
			string s = "\"" + sZipPath + "\" e"; // Распаковать (для полных путей - x)
			s += " -y"; // На все отвечать yes
			s += " " + "\"" + sFilePath + "\""; // Файл который нужно распаковать
			s += " -o" + "\"" + sTempDir + "\""; // Временная папка распаковки
			
			try {
				return Microsoft.VisualBasic.Interaction.Shell(s, Microsoft.VisualBasic.AppWinStyle.Hide, true, -1);
			} catch {
				gebug.Add( "строка s= "+s+"sZipPath= "+sZipPath+" | sFilePath="+sFilePath+" | sTempDir="+sTempDir );
				return -1;
			}
		}
		
		public static int _unzip( string sZipPath, string sFilePath, string sTempDir ) {
			// распаковка zip-фрхива
			Regex rx = new Regex( @"\\+" );
			sZipPath = rx.Replace( sZipPath, "\\" );
			sFilePath = rx.Replace( sFilePath, "\\" );
			sTempDir = rx.Replace( sTempDir, "\\" );
			
			if( !Directory.Exists( sTempDir ) ) {
				Directory.CreateDirectory( sTempDir );
			}
			
			string s = "\"" + sZipPath + "\" e"; // Распаковать (для полных путей - x)
			s += " -y"; // На все отвечать yes
			s += " " + "\"" + sFilePath + "\""; // Файл который нужно распаковать
			s += " -o" + "\"" + sTempDir + "\""; // Временная папка распаковки
			
			return Microsoft.VisualBasic.Interaction.Shell(s, Microsoft.VisualBasic.AppWinStyle.Hide, true, -1);
		}
		
		public static int _unrar( string sUnRarPath, string sFilePath, string sTempDir ) {
			// распаковка rar-фрхива
			Regex rx = new Regex( @"\\+" );
			sUnRarPath = rx.Replace( sUnRarPath, "\\" );
			sFilePath = rx.Replace( sFilePath, "\\" );
			sTempDir = rx.Replace( sTempDir, "\\" );
			
			if( !Directory.Exists( sTempDir ) ) {
				Directory.CreateDirectory( sTempDir );
			}
			
			string s = "\"" + sUnRarPath + "\" e"; // Распаковать (для полных путей - x)
			s += " -y"; // На все отвечать yes
			s += " " + "\"" + sFilePath + "\""; // Файл который нужно распаковать
			s += " " + "\"" + sTempDir + "\""; // Временная папка распаковки
			return Microsoft.VisualBasic.Interaction.Shell(s, Microsoft.VisualBasic.AppWinStyle.Hide, true, -1);
		}
		
		public static int _zip( string sZipPath, string sType, string sFilePath,
		                      string sFB2ZipFilePath ) {
			// упаковка в zip-фрхив
			Regex rx = new Regex( @"\\+" );
			sZipPath = rx.Replace( sZipPath, "\\" );
			sFilePath = rx.Replace( sFilePath, "\\" );
			sFB2ZipFilePath = rx.Replace( sFB2ZipFilePath, "\\" );
			
			string s = "\"" + sZipPath + "\" a"; // запаковать
			s += " -t"+sType.ToLower(); // в sType - тип архивации
			s += " -y"; // На все отвечать yes
			s += " \"" + sFB2ZipFilePath + "\""; // файл-архив .fb2.sType
			s += " \"" + sFilePath + "\""; // Файл который нужно запаковать
			return Microsoft.VisualBasic.Interaction.Shell(s, Microsoft.VisualBasic.AppWinStyle.Hide, true, -1);
		}
		
		public static int _rar( string sRarPath, string sFilePath,
		                      string sFB2RarFilePath, bool bRestoreInfo ) {
			// упаковка в rar-фрхив
			Regex rx = new Regex( @"\\+" );
			sRarPath = rx.Replace( sRarPath, "\\" );
			sFilePath = rx.Replace( sFilePath, "\\" );
			sFB2RarFilePath = rx.Replace( sFB2RarFilePath, "\\" );
			
			string s = "\"" + sRarPath + "\" a -m5"; // запаковать с максимальным сжатием
			if( bRestoreInfo ) {
				s += " -rr"; // добавить информацию для восстановления
			}
			s += " -y"; // На все отвечать yes
			s += " -ep"; // Исключить пути из имен
			s += " \"" + sFB2RarFilePath + "\""; // файл-архив .fb2.rar
			s += " \"" + sFilePath + "\""; // Файл который нужно запаковать
			return Microsoft.VisualBasic.Interaction.Shell(s, Microsoft.VisualBasic.AppWinStyle.Hide, true, -1);
		}
		
		public static bool IsArchivatorsPathCorrectForUnArchive( string s7zPath, string sUnRarPath, string sMessTitle ) {
			// проверка на наличие архиваторов и корректность путей к ним
			if( s7zPath.Trim().Length == 0 ) {
				MessageBox.Show( "В Настройках не указана папка с установленным консольным 7z(a).exe!",
				                sMessTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return false;
			}
			if( sUnRarPath.Trim().Length == 0 ) {
				MessageBox.Show( "В Настройках не указана папка с установленным консольным UnRar.exe!",
				                sMessTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return false;
			}
			
			if( !File.Exists( s7zPath ) ) {
				MessageBox.Show( "Не найден файл консольного Zip-архиватора 7z(a).exe \""+s7zPath+"\"!\nУкажите путь к нему в Настройках.\nРабота остановлена.",
				                sMessTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return false;
			}
			if( !File.Exists( sUnRarPath ) ) {
				MessageBox.Show( "Не найден файл консольного UnRar-распаковщика \""+sUnRarPath+"\"!\nУкажите путь к нему в Настройках.\nРабота остановлена!",
				                sMessTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning );
				return false;
			}
			
			return true;
		}
		
		public static void unzip( string sZipPath, string sFilePath, string sTempDir ) {
			// распаковка zip-фрхива
			Regex rx	= new Regex( @"\\+" );
			sZipPath	= rx.Replace( sZipPath, "\\" );
			sFilePath	= rx.Replace( sFilePath, "\\" );
			sTempDir	= rx.Replace( sTempDir, "\\" );
			
			if( !Directory.Exists( sTempDir ) ) {
				Directory.CreateDirectory( sTempDir );
			}
			
			string s = " e"; 				// Распаковать (для полных путей - x)
			s += " -y"; 					// На все отвечать yes
			s += " \"" + sFilePath + "\"";	// Файл который нужно распаковать
			s += " -o\"" + sTempDir + "\"";	// Временная папка распаковки
			
			ProcessStartInfo startInfo = new ProcessStartInfo( sZipPath, s );
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process p = Process.Start(startInfo);
			p.PriorityClass = ProcessPriorityClass.High;
			p.WaitForExit();
			p.Close();
			p.Dispose();
		}
		
		public static void unrar( string sUnRarPath, string sFilePath, string sTempDir ) {
			// распаковка rar-фрхива
			Regex rx	= new Regex( @"\\+" );
			sUnRarPath	= rx.Replace( sUnRarPath, "\\" );
			sFilePath	= rx.Replace( sFilePath, "\\" );
			sTempDir	= rx.Replace( sTempDir, "\\" );
			
			if( !Directory.Exists( sTempDir ) ) {
				Directory.CreateDirectory( sTempDir );
			}
			
			string s = " e"; 					// Распаковать (для полных путей - x)
			s += " -y"; 						// На все отвечать yes
			s += " " + "\"" + sFilePath + "\"";	// Файл который нужно распаковать
			s += " " + "\"" + sTempDir + "\"";	// Временная папка распаковки
			
			ProcessStartInfo startInfo = new ProcessStartInfo( sUnRarPath, s );
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process p = Process.Start(startInfo);
			p.PriorityClass = ProcessPriorityClass.High;
			p.WaitForExit();
			p.Close();
			p.Dispose();
		}
		
		public static void zip( string sZipPath, string sType, string sFilePath,
		                      	string sFB2ZipFilePath ) {
			// упаковка в zip-фрхив
			Regex rx		= new Regex( @"\\+" );
			sZipPath		= rx.Replace( sZipPath, "\\" );
			sFilePath		= rx.Replace( sFilePath, "\\" );
			sFB2ZipFilePath = rx.Replace( sFB2ZipFilePath, "\\" );
			
			string s = " a"; 						// запаковать
			s += " -t"+sType.ToLower(); 			// в sType - тип архивации
			s += " -y"; 							// На все отвечать yes
			s += " \"" + sFB2ZipFilePath + "\""; 	// файл-архив .fb2.sType
			s += " \"" + sFilePath + "\""; 			// Файл который нужно запаковать
			
			ProcessStartInfo startInfo = new ProcessStartInfo( sZipPath, s );
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process p = Process.Start(startInfo);
			p.PriorityClass = ProcessPriorityClass.High;
			p.WaitForExit();
			p.Close();
			p.Dispose();
		}
		
		public static void rar( string sRarPath, string sFilePath,
		                 	     string sFB2RarFilePath, bool bRestoreInfo ) {
			// упаковка в rar-фрхив
			Regex rx		= new Regex( @"\\+" );
			sRarPath		= rx.Replace( sRarPath, "\\" );
			sFilePath		= rx.Replace( sFilePath, "\\" );
			sFB2RarFilePath = rx.Replace( sFB2RarFilePath, "\\" );
			
			string s = " a -m5"; 	// запаковать с максимальным сжатием
			if( bRestoreInfo ) {
				s += " -rr"; 		// добавить информацию для восстановления
			}
			s += " -y"; 							// На все отвечать yes
			s += " -ep"; 							// Исключить пути из имен
			s += " \"" + sFB2RarFilePath + "\""; 	// файл-архив .fb2.rar
			s += " \"" + sFilePath + "\""; 			// Файл который нужно запаковать
			
			/*ProcessStartInfo startInfo = new ProcessStartInfo( sRarPath, s );
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process p = Process.Start(startInfo);
			p.PriorityClass = ProcessPriorityClass.High;
			p.WaitForExit();
			p.Close();
			p.Dispose();*/
			Process p = new Process();
			p.StartInfo.FileName = sRarPath;
			p.StartInfo.Arguments = s;
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.Start();
			p.PriorityClass = ProcessPriorityClass.High;
			p.WaitForExit();
			p.Close();
			p.Dispose();
		}
		
	}
}
