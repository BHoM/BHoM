using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BHoM.Structural
{

    /// <summary>
    /// enums with name/index matching the columns in the section databases
    /// </summary>
    public enum SectionTableColumn
    {
        /// <summary>
        /// ID
        /// </summary>
        Id = 0,
        /// <summary>
        /// Section type (ie UC, UB)
        /// </summary>
        Type,
        /// <summary>
        /// Shape type 
        /// </summary>
        Shape,
        /// <summary>
        /// Mass
        /// </summary>
        Mass,
        /// <summary>
        /// Total Height
        /// </summary>
        Height,
        /// <summary>
        /// total width
        /// </summary>
        Width,
        /// <summary>
        /// Custom dimension, usually corresponds with top flange width
        /// </summary>
        B1,
        /// <summary>
        /// Custom dimension, usually corresponds with bottom flange width
        /// </summary>
        B2,
        /// <summary>
        /// custom dimension
        /// </summary>
        B3,
        /// <summary>
        /// plate thickness of web
        /// </summary>
        TW,
        /// <summary>
        /// Plate thickness of top flange
        /// </summary>
        TF1,
        /// <summary>
        /// thickness of bot flange
        /// </summary>
        TF2,
        /// <summary>
        /// Radius 1 - web/flange radius in Tee/ISection/angle or outer radius in box/rectangular sections
        /// </summary>
        r1,
        /// <summary>
        /// Radius 2 - toe or inner radius
        /// </summary>
        r2,
        /// <summary>
        /// Spacing between double section members
        /// </summary>
        Spacing
    }

    public enum Database
    {
        Material,
        SteelSection,

    }

    public class DataBaseAdapter
    {
        Database m_Database;
        string m_TableName;
        SqlDataAdapter m_DataAdapter;

        public DataBaseAdapter(Database db, string tableName)
        {
            m_TableName = tableName;
            m_Database = db;
        }

        public List<string> ColumnNames()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("select COLUMN_NAME from information_schema.columns where TABLE_NAME = '" + m_TableName + "'", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            List<string> names = new List<string>();
            foreach (DataRow d in set.Tables[0].Rows)
            {
                names.Add(d[0].ToString().Trim());
            }

            return names;
        }

        public DataColumn SelectUniqueData(string columnName)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT DISTINCT " + columnName + " FROM " + m_TableName + " Order By Type ASC", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set.Tables[0].Columns[0];
        }

        public List<string> Names()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT Name FROM " + m_TableName, connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            List<string> names = new List<string>();
            foreach (DataRow d in set.Tables[0].Rows)
            {
                names.Add(d[0].ToString().Trim());
            }

            return names;
        }

        public DataSet GetDataSet(string columnName, string matches)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_TableName + " Where " + columnName + " = '" + matches + "'", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set;
        }

        public object[] GetDataRow(string columnName, string matches)
        {
            return GetDataRow(new string[] { columnName }, new string[] { matches });
        }

        public object[] GetDataRow(string[] columnNames, string[] matches, bool AND = false)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            try
            {
                connection.Open();
                string matchString = "";
                for (int i = 0; i < columnNames.Length; i++)
                {
                    string match = Regex.Replace(matches[i % matches.Length], "(^[A-Z]+)([0-9]+)", "$1%$2");
                    match = Regex.Replace(match, "\\s+", "%");
                    matchString += columnNames[i] + " like '" + match + (AND ? "' AND " : "' Or ");
                }

                matchString = matchString.Substring(0, matchString.Length - (AND ? 4 : 3));

                m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_TableName + " Where " + matchString, connection);
                DataSet set = new DataSet();

                m_DataAdapter.Fill(set);
                connection.Close();

                return set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 ? set.Tables[0].Rows[0].ItemArray : null;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private string ConnectionString()
        {
            switch (m_Database)
            {
                case Database.SteelSection:
                    return Properties.Settings.Default.SteelSectionConnectionsString;
                case Database.Material:
                    return Properties.Settings.Default.MaterialConnectionString;
                default:
                    return "";
            }
        }

        /// <summary>
        /// Set the default table name
        /// </summary>
        public string TableName
        {
            get
            {
                return m_TableName;
            }
            set
            {
                m_TableName = value;
            }
        }

        /// <summary>
        /// Gets all the tables in the current database
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableNames()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();

            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("select table_name from INFORMATION_SCHEMA.TABLES", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();

            List<string> names = new List<string>();
            foreach (DataRow d in set.Tables[0].Rows)
            {
                names.Add(d[0].ToString().Trim());
            }

            return names;
        }

    }
}
