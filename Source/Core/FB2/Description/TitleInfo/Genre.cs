﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 9:53
 * 
 * License: GPL 2.1
 */
using System;

namespace Core.FB2.Description.TitleInfo
{
	/// <summary>
	/// Description of Genre.
	/// </summary>
	public class Genre
	{
		#region Закрытые данные класса
		private uint 	m_unMath	= 100;
        private string 	m_sName		= null;
        #endregion
        
		#region Конструкторы класса
		public Genre()
        {
            m_sName 	= null;
			m_unMath 	= 100;
        }
		public Genre( string sName, uint unMath )
        {
            m_sName = sName;
            if( unMath < 0 ) {
                m_unMath = 0;
            } else if( unMath > 100 ) {
            	m_unMath = 100;
            } else {
            	m_unMath = unMath;
            }
        }
		public Genre( string sName )
        {
            m_sName 	= sName;
            m_unMath 	= 100;
        }
        #endregion
        
        #region Открытые свойства класса - fb2-элементы
        public virtual string Name {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public virtual uint Math {
            get { return m_unMath; }
            set { m_unMath = value; }
        }
        #endregion
	}
}
