﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 29.04.2009
 * Time: 14:33
 * 
 * License: GPL 2.1
 */
using System;
using FB2.Common;

namespace FB2.Description.Common
{
	/// <summary>
	/// Description of TextFieldType.
	/// </summary>
	public class TextFieldType : ITextFieldType
	{
		#region Закрытые данные класса
		private string m_sValue	= null;
		private string m_sLang	= null;
		#endregion
		
		#region Конструкторы класса
		public TextFieldType()
		{
			m_sValue	= null;
        	m_sLang		= null;
		}
		public TextFieldType( string sValue, string sLang )
        {
            m_sValue	= sValue;
        	m_sLang		= sLang;
        }
        public TextFieldType( string sValue )
        {
            m_sValue	= sValue;
        }
		#endregion

		#region Открытые методы класса
		public virtual bool Equals( TextFieldType t )
        {
			bool bThisIsNull = ( m_sValue == null && m_sLang == null );
			if( bThisIsNull || t == null ) {
				return true;
			} else if( !bThisIsNull && t != null ) {
				return Value.Equals( t.Value ) &&
            			Lang.Equals( t.Lang );
			}
			return false;
        }
		#endregion
		
		#region Открытые свойства класса - атрибуты fb2-элементов
		public virtual string Lang {
            get { return m_sLang; }
            set { m_sLang = value; }
        }
		#endregion
		
		#region Открытые свойства класса - элементы fb2-элементов
        public virtual string Value {
            get { return m_sValue; }
            set { m_sValue = value; }
        }
        #endregion
	}
}
