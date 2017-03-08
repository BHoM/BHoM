using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BHoM.Base;
using System.Reflection;

namespace BHoM.Base.Data
{ 
    /// <summary>
    /// enums with name/index matching the columns in the section databases
    /// </summary>


    public class SQLAccessor<T> : IDataAdapter where T : IDataRow, new()
    {
        DatabaseType m_Database;
        string m_ConnectionString;
        string m_TableName;
        SqlDataAdapter m_DataAdapter;

        public SQLAccessor(DatabaseType db, string tableName)
        {
            m_TableName = tableName;
            m_Database = db;
            m_ConnectionString = ConnectionString();
        }

        public SQLAccessor(string serverName, string databaseName, string tableName)
        {
            m_ConnectionString = "Data Source=" + serverName + "; AttachDbFilename = " + databaseName + "; Integrated Security = True; Connect Timeout = 30"; // TODO - Need to handle more than file connection
            m_TableName = tableName;
            m_Database = DatabaseType.Custom;
        }

        public SQLAccessor(string connectionString, string tableName)
        {
            m_ConnectionString = connectionString;
            m_TableName = tableName;
            m_Database = DatabaseType.Custom;
        }

        public List<IDataRow> Query(string query)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter(query, connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();

            List<string> properties = new List<string>();
            foreach (DataColumn d in set.Tables[0].Columns)
                properties.Add(d.ColumnName);

            List<IDataRow> result = new List<IDataRow>();
            //result.Add(properties);

            foreach (DataRow d in set.Tables[0].Rows)
            {
                result.Add(GetObjectFromDataRow(d));
            }

            return result;
        }


        public List<string> ColumnNames()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
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
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT DISTINCT " + columnName + " FROM " + m_TableName + " Order By Type ASC", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set.Tables[0].Columns[0];
        }

        public List<string> Names()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
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

        public DataSet GetRawDataSet(string columnName, string matches)
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
            connection.Open();
            m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_TableName + " Where " + columnName + " = '" + matches + "'", connection);
            DataSet set = new DataSet();

            m_DataAdapter.Fill(set);
            connection.Close();
            return set;
        }

        public List<IDataRow> GetDataSet(string columnName, string matches)
        {
            List<IDataRow> data = new List<IDataRow>();
            foreach (DataRow row in GetRawDataSet(columnName, matches).Tables[0].Rows)
            {
                data.Add(GetObjectFromDataRow(row));
            }
            return data;
        }


        public IDataRow GetDataRow(string columnName, string matches)
        {
            return GetDataRow(new string[] { columnName }, new string[] { matches });
        }

        public IDataRow GetDataRow(string[] columnNames, string[] matches, bool AND = false)
        {
            try
            {
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);

                connection.Open();
                string matchString = "";
                for (int i = 0; i < columnNames.Length; i++)
                {
                    string match = Regex.Replace(matches[i % matches.Length], "(^[A-Z]+)([0-9]+)", "$1%$2");
                    match = Regex.Replace(match, "\\s+", "%");
                    matchString += columnNames[i] + " like '" + match + "%" + (AND ? "' AND " : "' Or ");
                }

                matchString = matchString.Substring(0, matchString.Length - (AND ? 4 : 3));

                m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + m_TableName + " Where " + matchString, connection);
                DataSet set = new DataSet();

                m_DataAdapter.Fill(set);
                connection.Close();

              


                return set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 ? GetObjectFromDataRow(set.Tables[0].Rows[0]) : default(T);
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }

        private T GetObjectFromDataRow(DataRow data)
        {
            List<string> properties = new List<string>();
            foreach (PropertyInfo d in typeof(T).GetProperties())
                properties.Add(d.Name);

            List<T> result = new List<T>();
            //result.Add(properties);
            T item = new T();
            foreach (string prop in properties)
            {
                if (data[prop] != null && !string.IsNullOrEmpty(data[prop].ToString()))
                {
                    if (data[prop] is string)
                    {
                        typeof(T).GetProperty(prop).SetValue(item, data[prop].ToString().Trim());
                    }
                    else
                    {
                        typeof(T).GetProperty(prop).SetValue(item, data[prop]);
                    }
                }
            }
            return item;        
        }

        private string ConnectionString()
        {
            string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            switch (m_Database)
            {
                case DatabaseType.SteelSection:
                    return string.Format(Properties.Settings.Default.SteelSectionConnectionsString, appData);
                case DatabaseType.Material:
                    return string.Format(Properties.Settings.Default.MaterialConnectionString, appData);
                case DatabaseType.Cables:
                    return string.Format(Properties.Settings.Default.CableSectionConnectionStrin, appData);
                default:
                    return m_ConnectionString;
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
        public List<string> TableNames()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
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

        public List<object> GetDataColumn(string name, string arg = "")
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
            connection.Open();

            m_DataAdapter = new SqlDataAdapter("SELECT " +name+ " FROM " + m_TableName + " " + arg, connection);
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

        public List<string> GetDataColumn(string name)
        {      
            List<string> col = new List<string>();

            foreach (object row in GetDataColumn(name))
            {
                col.Add(row.ToString());
            }

            return col;
        }

        public T1 GetDataRow<T1>(string column, string matches) where T1 : IDataRow
        {
            return (T1)GetDataRow(column, matches);
        }

        public List<string> GetDataColumn(string columnName, string column, string matches)
        {
            throw new NotImplementedException();
        }
    }
}
