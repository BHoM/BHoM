using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BHoM.Base;


namespace BHoM.Base
{ 
    /// <summary>
    /// enums with name/index matching the columns in the section databases
    /// </summary>

    public enum Database
    {
        Material,
        SteelSection,
        Cables,
    }

    public class SQLAccessor
    {
        Database m_Database;
        string m_TableName;
        SqlDataAdapter m_DataAdapter;

        public SQLAccessor(Database db, string tableName)
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
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());

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
            string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            switch (m_Database)
            {
                case Database.SteelSection:
                    return string.Format(Properties.Settings.Default.SteelSectionConnectionsString, appData);
                case Database.Material:
                    return string.Format(Properties.Settings.Default.MaterialConnectionString, appData);
                case Database.Cables:
                    return string.Format(Properties.Settings.Default.CableSectionConnectionStrin, appData);
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

        public List<object> GetDataColumn(string name)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString());
            connection.Open();

            m_DataAdapter = new SqlDataAdapter("SELECT " +name+ " FROM " + m_TableName, connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();

            List<object> col = new List<object>();

            foreach (DataRow row in set.Tables[0].Rows)
            {
                col.Add(row[name]);
            }

            return col;
        }

    }
}
