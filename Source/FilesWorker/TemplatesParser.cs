﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 04.05.2009
 * Time: 11:30
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FB2.FB2Parsers;
using FB2.Common;
using FB2.Description;
using FB2.Description.TitleInfo;
using FB2.Description.DocumentInfo;
using FB2.Description.PublishInfo;
using FB2.Description.CustomInfo;
using FB2.Description.Common;

using fB2Parser = FB2.FB2Parsers.FB2Parser;

namespace Lexems
{
	/// <summary>
	/// Description of SimpleType
	/// </summary>
	public enum SimpleType {
		const_template,			// постоянный шаблон
		const_text, 			// постоянные символы
		conditional_template,	// условный шаблон
		conditional_group, 		// условная группа
	}
	
	/// <summary>
	/// Description of ComplexType
	/// </summary>
	public enum ComplexType {
		template,	// постоянный шаблон
		text, 		// постоянные символы
	}
	
	/// <summary>
	/// Description of TPSimple
	/// </summary>
	public class TPSimple {
		private string		m_sLexem	= "";
		private SimpleType	m_Type		= SimpleType.const_template;
		public TPSimple( string sLexem, SimpleType Type )
		{
			m_sLexem	= sLexem;
			m_Type		= Type;
		}
		public virtual string Lexem {
            get { return m_sLexem; }
        }
		public virtual SimpleType Type {
            get { return m_Type; }
        }
	}
	
	/// <summary>
	/// Description of TPComplex
	/// </summary>
	public class TPComplex {
		private string		m_sLexem	= "";
		private ComplexType	m_bType		= ComplexType.template;
		public TPComplex( string sLexem, ComplexType Type )
		{
			m_sLexem	= sLexem;
			m_bType		= Type;
		}
		public virtual string Lexem {
            get { return m_sLexem; }
            set { m_sLexem = value; }
        }
		public virtual ComplexType Type {
            get { return m_bType; }
        }
	}
}
	
namespace FilesWorker
{
	/// <summary>
	/// Description of TemplatesParser.
	/// </summary>
	public class TemplatesParser
	{
		#region Закрытые данные
		private static char cSeparator = '↑';
		private static string[] m_sAllTemplates = new string[] {
								"*L*","*G*","*BAF*","*BAM*","*BAL*","*BAN*","*BT*","*SN*","*SI*",
								};
		#endregion
		
		public TemplatesParser()
		{
		}
		
		#region Закрытые Вспомогательные методы
		private static string InsertSeparatorToAsterik( string sLine ) {
			// вставка разделителя слева от открывающей * и справа от закрывающей *
			if( sLine==null || sLine=="" ) return sLine;
			if( sLine.IndexOf( '*' )==-1 ) return sLine;
			string sTemp = "";
			int nCount = 0; // счетчик * - для определения их четности
			for( int i=0; i!=sLine.Length; ++i ) {
				if( sLine[i]=='*' ) {
					++nCount;
					if( nCount % 2 == 0 ) {
						// закрывающая * (четная)
						sTemp += sLine[i];
						sTemp += cSeparator;
					} else {
						// открывающая * (не четная)
						sTemp += cSeparator;
						sTemp += sLine[i];
					}
				} else {
					sTemp += sLine[i];
				}
			}
			return sTemp;
		}
		
		private static string InsertSeparatorToSquareBracket( string sLine ) {
			// вставка разделителя слева от [ и справа от ]
			if( sLine==null || sLine=="" ) return sLine;
			string sTemp = "";
			for( int i=0; i!=sLine.Length; ++i ) {
				if( sLine[i]=='[' ) {
					sTemp += cSeparator;
					sTemp += sLine[i];
				} else {
					sTemp += sLine[i];
					if( sLine[i]==']' ) {
						sTemp += cSeparator;
					}
				}
			}
			return sTemp;
		}
		
		private static int CountElement( string sLine, char cChar ) {
			// подсчет числа элементов cChar в строке sLine
			int nCount = 0;
			for( int i=0; i!=sLine.Length; ++i ) {
				if( sLine[i]== cChar ) {
					++nCount;
				}
			}
			return  nCount;
		}
		
		private static bool IsTemplateExsist( string sLine ) {
			// проверка, есть ли шаблоны в строке
			foreach( string t in m_sAllTemplates ) {
				if( sLine.IndexOf( t )!=-1 ) {
					return true;
				}
			}
			return false;
		}
		
		private static string GetTemplate( string sLine ) {
			// возвращает 1-й шаблон в строке, если он есть, или ""
			foreach( string t in m_sAllTemplates ) {
				if( sLine.IndexOf( t )!=-1 ) {
					return t;
				}
			}
			return "";
		}
		
		private static List<Lexems.TPSimple> GemSimpleLexems( string sLine ) {
			/* получение простых лексем из шаблонной строки */
			// разбиваем строку относительно [ и ]
			string [] sTemp = InsertSeparatorToSquareBracket( sLine ).Split( new char[] { cSeparator }, StringSplitOptions.RemoveEmptyEntries );
			// разбиваем строки sLexems, где нет [] относительно *
			List<string> lsLexems = new List<string>();
			foreach( string sStr in sTemp ) {
				if( sStr.IndexOf( '[' )!=-1 || sStr.IndexOf( '*' )==-1 ) {
					lsLexems.Add( sStr );
				} else {
					lsLexems.AddRange( InsertSeparatorToAsterik( sStr ).Split( new char[] { cSeparator }, StringSplitOptions.RemoveEmptyEntries ) );
				}
			}
			// задаем лексемам их тип
			List<Lexems.TPSimple> lexems = new List<Lexems.TPSimple>();
			foreach( string s in lsLexems ) {
				if( !IsTemplateExsist( s ) ) {
					// постоянные символы
					lexems.Add( new Lexems.TPSimple( s, Lexems.SimpleType.const_text ) );
				} else {
					if( s.IndexOf( '[' )==-1 ) {
						// постоянный шаблон
						lexems.Add( new Lexems.TPSimple( s, Lexems.SimpleType.const_template ) );
					} else {
						// удаляем шаблон из строки и смотрим, есть ли там еще что, помимо него
						string st = GetTemplate( s );
						string sRem = s.Remove( s.IndexOf( st ), st.Length ).Remove( 0, 1 );
						sRem = sRem.Remove( (sRem.Length-1), 1 );
						if( sRem == "" ) {
							// условный шаблон
							lexems.Add( new Lexems.TPSimple( s, Lexems.SimpleType.conditional_template ) );
						} else {
							// условная группа
							lexems.Add( new Lexems.TPSimple( s, Lexems.SimpleType.conditional_group ) );
						}
					}
				}
			}
			return lexems;
		}
		
		
		private static List<Lexems.TPComplex> GemComplexLexems( string sLine ) {
			/* получение лексем из сложной группы */
			// разбиваем строку относительно *
			string str = sLine.Remove( 0, 1 );
			str = str.Remove( (str.Length-1), 1 );
			string [] sLexems = InsertSeparatorToAsterik( str ).Split( new char[] { cSeparator }, StringSplitOptions.RemoveEmptyEntries );
			// задаем лексемам их тип
			List<Lexems.TPComplex> lexems = new List<Lexems.TPComplex>();
			foreach( string s in sLexems ) {
				if( !IsTemplateExsist( s ) ) {
					// символы
					lexems.Add( new Lexems.TPComplex( s, Lexems.ComplexType.text ) );
				} else {
					// шаблон
					lexems.Add( new Lexems.TPComplex( s, Lexems.ComplexType.template ) );
				}
			}
			return lexems;
		}
		
		#endregion
		
		#region Открытые методы
		public static string Parse( string sLine, string sFB2FilePath ) {
			// формирование имени файла на основе данных Description и шаблонов подстановки
			// формируем лексемы шаблонной строки
			List<Lexems.TPSimple> lSLexems = GemSimpleLexems( sLine );
			
			// формирование имени файла
			string sFileName = "";
			fB2Parser fb2 = new fB2Parser( sFB2FilePath );
			TitleInfo ti = fb2.GetTitleInfo();
			string sLang = ti.Lang;
			IList<Genre> lGenres = ti.Genres;
			IList<Author> lAuthors = ti.Authors;
			string sBookTitle = ti.BookTitle.Value;
			IList<Sequence> lSequences = ti.Sequences;
			
			foreach( Lexems.TPSimple lexem in lSLexems ) {
				switch( lexem.Type ) {
					case Lexems.SimpleType.const_text:
						// постоянные символы
						sFileName += lexem.Lexem;
						break;
					case Lexems.SimpleType.const_template:
						// постоянный шаблон
						switch( lexem.Lexem ) {
							case "*L*":
								sFileName += ( sLang==null ? "Языка Книги Нет" : sLang );
								break;
							case "*G*":
								sFileName += ( lGenres==null ? "Жанра Нет" : lGenres[0].Name );
								break;
							case "*BAF*":
								sFileName += ( lAuthors[0].FirstName==null ? "Имени Автора Нет" : lAuthors[0].FirstName.Value );
								break;
							case "*BAM*":
								sFileName += ( lAuthors[0].MiddleName==null ? "Отчества Автора Нет" : lAuthors[0].MiddleName.Value );
								break;
							case "*BAL*":
								sFileName += ( lAuthors[0].LastName==null ? "Фамилия Автора Нет" : lAuthors[0].LastName.Value );
								break;
							case "*BAN*":
								sFileName += ( lAuthors[0].NickName==null ? "Ника Автора Нет" : lAuthors[0].NickName.Value );
								break;
							case "*BT*":
								if( sBookTitle==null || sBookTitle=="" ) {
									sFileName += "Названия Книги Нет";
								} else {
									sFileName += sBookTitle;
								}
								break;
							case "*SN*":
								sFileName += ( lSequences==null ? "Серии Нет" : lSequences[0].Name );
								break;
							case "*SI*":
								sFileName += ( lSequences==null ? "Номера Серии Нет" : lSequences[0].Number.ToString() );
								break;
							default :
								sFileName += "";
								break;
						}
						break;
					case Lexems.SimpleType.conditional_template:
						// условный шаблон
						switch( lexem.Lexem ) {
							case "[*L*]":
								sFileName += ( sLang==null ? "" : sLang );
								break;
							case "[*G*]":
								sFileName += ( lGenres==null ? "" : lGenres[0].Name );
								break;
							case "[*BAF*]":
								sFileName += ( lAuthors[0].FirstName==null ? "" : lAuthors[0].FirstName.Value );
								break;
							case "[*BAM*]":
								sFileName += ( lAuthors[0].MiddleName==null ? "" : lAuthors[0].MiddleName.Value );
								break;
							case "[*BAL*]":
								sFileName += ( lAuthors[0].LastName==null ? "" : lAuthors[0].LastName.Value );
								break;
							case "[*BAN*]":
								sFileName += ( lAuthors[0].NickName==null ? "" : lAuthors[0].NickName.Value );
								break;
							case "[*BT*]":
								if( sBookTitle==null || sBookTitle=="" ) {
									sFileName += "";
								} else {
									sFileName += sBookTitle;
								}
								break;
							case "[*SN*]":
								sFileName += ( lSequences==null ? "" : lSequences[0].Name );
								break;
							case "[*SI*]":
								sFileName += ( lSequences==null ? "" : lSequences[0].Number.ToString() );
								break;
							default :
								sFileName += "";
								break;
						}
						break;
					case Lexems.SimpleType.conditional_group:
						// условная группа
						sFileName += ParseComplexGpoup( lexem.Lexem, ti.Lang, ti.Genres, ti.Authors, ti.BookTitle.Value, ti.Sequences );
						
						
						break;
					default :
						// постоянные символы
						sFileName += lexem.Lexem;
						break;
				}
			}
			// если с начала или в конце строки есть один или несколько \ - то убираем их
			Regex rx = new Regex( @"^\\+" );
			sFileName = rx.Replace( sFileName, "" );
			rx = new Regex( @"\\+$" );
			sFileName = rx.Replace( sFileName, "" );
			return sFileName;
		}
		
		
		private static string ParseComplexGpoup( string sLine, string sLang, IList<Genre> lGenres, IList<Author> lAuthors, 
												string sBookTitle, IList<Sequence> lSequences ) {
			string sFileName = "";
			List<Lexems.TPComplex> lCLexems = GemComplexLexems( sLine );
			foreach( Lexems.TPComplex lexem in lCLexems ) {
				switch( lexem.Type ) {
					case Lexems.ComplexType.text:
						// символы
						break;
					case Lexems.ComplexType.template:
						// шаблоны
						switch( lexem.Lexem ) {
							case "*L*":
								lexem.Lexem = ( sLang==null ? "" : sLang );
								break;
							case "*G*":
								lexem.Lexem = ( lGenres==null ? "" : lGenres[0].Name );
								break;
							case "*BAF*":
								lexem.Lexem = ( lAuthors[0].FirstName==null ? "" : lAuthors[0].FirstName.Value );
								break;
							case "*BAM*":
								lexem.Lexem = ( lAuthors[0].MiddleName==null ? "" : lAuthors[0].MiddleName.Value );
								break;
							case "*BAL*":
								lexem.Lexem = ( lAuthors[0].LastName==null ? "" : lAuthors[0].LastName.Value );
								break;
							case "*BAN*":
								lexem.Lexem = ( lAuthors[0].NickName==null ? "" : lAuthors[0].NickName.Value );
								break;
							case "*BT*":
								if( sBookTitle==null || sBookTitle=="" ) {
									lexem.Lexem = "";
								} else {
									lexem.Lexem = sBookTitle;
								}
								break;
							case "*SN*":
								lexem.Lexem = ( lSequences==null ? "" : lSequences[0].Name );
								break;
							case "*SI*":
								lexem.Lexem = ( lSequences==null ? "" : lSequences[0].Number.ToString() );
								break;
							default :
								lexem.Lexem = "";
								break;
						}
						break;
				}
			}
			
			// определение, какой текст, если он есть в группе, будет отображаться вместе с данными "его" шаблона
			for( int i=0; i!=lCLexems.Count; ++i ) {
				// "пустой" шаблон "ликвидирует" текст справа от себя, а 1-й "пустой" шаблон - еще и слева.
				if( lCLexems[i].Type == Lexems.ComplexType.template ) {
					if( lCLexems[i].Lexem == "" ) {
						// не 1-й ли это элемент списка
						if( i < lCLexems.Count-1 && lCLexems[i+1].Type == Lexems.ComplexType.text ) {
							lCLexems[i+1].Lexem = "";
						}
						// если этот шаблон - самый первый из группы шаблонов, а до него есть текст, то еще и "ликвидируем" текст слева от него
						if( i == 1 && lCLexems[0].Type == Lexems.ComplexType.text ) {
							lCLexems[0].Lexem = "";
						}
					}
				}
			}
			// формирование строки
			foreach( Lexems.TPComplex lex in lCLexems ) {
				if( lex.Lexem != "" ) {
					sFileName += lex.Lexem;
				}
			}
			return sFileName;
		}
			
		#endregion
	}
}