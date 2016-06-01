using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.SectionProperties
{
        public enum SectionTableColumn
        {
            Id = 0,
            Type = 1,
            L1 = 2,
            L2 = 3,
            L3 = 4,
            Shape = 5,
            Mass = 6,
            H = 7,
            B = 8,
            T1 = 9,
            T2 = 10,
            r1 = 11,
            r2 = 12
        }

    public class SectionDB
    {
        string m_Database;
        string m_Table;
        string m_Type;
        SqlDataAdapter m_DataAdapter;


        public SectionDB()
        {
            m_Table = "Sections";
            m_Database = "UK_Sections";
            m_Type = "UC";
        }

        public DataColumn SectionTypes()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT DISTINCT Type FROM " + m_Table + " Order By Type ASC", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set.Tables[0].Columns[0];
        }

        public List<string> SectionNames()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT Name FROM " + m_Table, connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            //set.
            List<string> names = new List<string>();
            foreach (DataRow d in set.Tables[0].Rows)
            {
                names.Add(d[0].ToString().Trim());
            }

            return names;
            //return set.Tables[0].Columns[0].
        }

        public DataSet SectionSizes()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_Table + " Where Type = '" + m_Type + "'", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set;
        }

        public object[] SectionProperties(string name)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_Table + " Where Name = '" + name
                                                                    + "' Or Name1 = '" + name
                                                                    + "' Or Name2 = '" + name + "'", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();

            return set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 ? set.Tables[0].Rows[0].ItemArray : null;
        }

        private string ConnectionString()
        {
            switch (m_Database)
            {
                case "UK_Sections":
                default:
                    return Properties.Settings.Default.UK_SectionsConnectionString;

            }
        }

        public string CurrentDatabase
        {
            set
            {
                m_Database = value;
            }
        }

        public string CurrentType
        {
            set
            {
                m_Type = value;
            }
        }
    }
}
