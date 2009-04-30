﻿/*
 * Created by SharpDevelop.
 * User: Кузнецов Вадим (DikBSD)
 * Date: 28.04.2009
 * Time: 15:09
 * 
 * License: GPL 2.1
 */
using System;
using System.Collections.Generic;
using FB2.Description.Common;

namespace FB2.Description.DocumentInfo
{
	/// <summary>
	/// Description of DocumentInfo.
	/// </summary>
	public class DocumentInfo
	{
		#region Закрытые данные класса
        private IList<Author>	m_Authors		= null;
        private ProgramUsed		m_ProgramUsed	= null;
        private Date			m_Date			= null;
        private IList<string>	m_SrcUrls		= null;
        private SrcOCR			m_sSrcOCR		= null;
        private string			m_sID			= null;
        private string			m_sVersion		= null;
        private History 		m_History		= null;
        #endregion
        
		#region Конструкторы класса
        public DocumentInfo()
        {
        }
        public DocumentInfo( IList<Author> authors, ProgramUsed programUsed, Date date, IList<string> srcUrls, SrcOCR srcOcr,
                            string sID, string sVersion, History history )
        {
            m_Authors		= authors;
            m_ProgramUsed	= programUsed;
            m_Date			= date;
            m_SrcUrls		= srcUrls;
            m_sSrcOCR		= srcOcr;
            m_sID			= sID;
            m_sVersion		= sVersion;
            m_History		= history;
        }
        public DocumentInfo(IList<Author> authors, Date date, string sID, string sVersion)
        {
            m_Authors	= authors;
            m_Date		= date;
            m_sID		= sID;
            m_sVersion	= sVersion;
        }
        #endregion
  
        #region Открытые Вспомогательные методы класса
		public virtual bool Equals( DocumentInfo d )
        {				
			if( d.GetType() == typeof( DocumentInfo) ) {
				bool b = Authors.Equals( d.Authors ) ;
             /*   bool bRet =
                	( ProgramUsed.Value == ( ( DocumentInfo )d ).ProgramUsed.Value ) &&
                	( ProgramUsed.Lang == ( ( DocumentInfo )d ).ProgramUsed.Lang ) &&
				   	( Date.Text == ( ( DocumentInfo )d ).Date.Text ) &&
                	( Date.Value == ( ( DocumentInfo )d ).Date.Value ) &&
                	( Date.Lang == ( ( DocumentInfo )d ).Date.Lang ) &&
				   	( SrcOcr.Value == ( ( DocumentInfo )d ).SrcOcr.Value ) &&
                	( SrcOcr.Lang == ( ( DocumentInfo )d ).SrcOcr.Lang ) &&
				   	( ID == ( ( DocumentInfo )d ).ID ) &&
				   	( Version == ( ( DocumentInfo )d ).Version ) &&
				   	( History.Value == ( ( DocumentInfo )d ).History.Value ) &&
                	( History.Id == ( ( DocumentInfo )d ).History.Id ) &&
                	( History.Lang == ( ( DocumentInfo )d ).History.Lang );
                if( Authors.Count != d.Authors.Count ) {
                	bRet = false;
                } else {
                	for( int i=0; i!=Authors.Count; ++i  ) {
                		bRet &= Authors[i].FirstName.Value == d.Authors[i].FirstName.Value;
                		bRet &= Authors[i].FirstName.Lang == d.Authors[i].FirstName.Lang;
                		
                		bRet &= Authors[i].MiddleName.Value == d.Authors[i].MiddleName.Value;
                		bRet &= Authors[i].MiddleName.Lang == d.Authors[i].MiddleName.Lang;
                		
                		bRet &= Authors[i].LastName.Value == d.Authors[i].LastName.Value;
                		bRet &= Authors[i].LastName.Lang == d.Authors[i].LastName.Lang;
               		}
                }
                if( SrcUrls.Count != d.SrcUrls.Count ) {
                	bRet = false;
                } else {
                	for( int i=0; i!=SrcUrls.Count; ++i  ) {
                		bRet &= SrcUrls[i] == d.SrcUrls[i];
               		}
                }
                	*/
				if( ( Authors == ( ( DocumentInfo )d ).Authors ) &&
				   	( ProgramUsed == ( ( DocumentInfo )d ).ProgramUsed ) &&
				   	( Date == ( ( DocumentInfo )d ).Date ) &&
				   	( SrcUrls == ( ( DocumentInfo )d ).SrcUrls ) &&
				   	( SrcOcr == ( ( DocumentInfo )d ).SrcOcr ) &&
				   	( ID == ( ( DocumentInfo )d ).ID ) &&
				   	( Version == ( ( DocumentInfo )d ).Version ) &&
				   	( History == ( ( DocumentInfo )d ).History ) ) {
					return true;
				} else {
					return false;
				}
        	} else {
        		return false;
        	}
        }
		#endregion
        
        #region Открытые свойства класса - fb2-элементы
        public virtual IList<Author> Authors {
            get { return m_Authors; }
            set { m_Authors = value; }
        }

        public virtual ProgramUsed ProgramUsed {
            get { return m_ProgramUsed; }
            set { m_ProgramUsed = value; }
        }

        public virtual Date Date {
            get { return m_Date; }
            set { m_Date = value; }
        }

        public virtual IList<string> SrcUrls {
            get { return m_SrcUrls; }
            set { m_SrcUrls = value; }
        }

        public virtual SrcOCR SrcOcr {
            get { return m_sSrcOCR; }
            set { m_sSrcOCR = value; }
        }

        public virtual string ID
        {
            get { return m_sID; }
            set { m_sID = value; }
        }

        public virtual string Version
        {
            get { return m_sVersion; }
            set { m_sVersion = value; }
        }

        public virtual History History
        {
            get { return m_History; }
            set { m_History = value; }
        }
        
        public virtual void SetNewID()
        {
            m_sID = Guid.NewGuid().ToString();
        }
        #endregion
	}
}
