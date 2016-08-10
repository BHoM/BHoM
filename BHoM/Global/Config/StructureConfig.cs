using BHoM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public partial class Config
    {
        private string m_SectionDB = "UK_Sections";
        private string m_MaterialDB = "Europe";

        public string SectionDatabase
        {
            get
            {
                return m_SectionDB;
            }
            set
            {
                m_SectionDB = value;
            }
        }

        public string MaterialDatabase
        {
            get
            {
                return m_MaterialDB;
            }
            set
            {
                m_MaterialDB = value;
            }
        }
    }
}
