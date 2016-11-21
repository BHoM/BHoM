using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using BHoM.Structural.Loads;

namespace BHoM.Base.Results
{
    public enum ResultOrder
    {
        Name = 0,
        Loadcase,
        TimeStep,
        None
    }

    public class ResultServer<T> where T : IResult, new()
    {
        Dictionary<string, IResultSet> m_Results;
        
        string m_TableName;
        string m_ConnectionString;
        List<string> m_ColumnNames;
        Dictionary<string, int> m_LoadcaseKey;
        private ResultOrder m_ResultOrder;

        /// <summary>
        /// Sets the Names of the results to load, if left blank all bar names will be loaded
        /// </summary>
        public List<string> NameSelection { get; set; }

        /// <summary>
        /// Sets the names of the loadcases to load, if left blank all loadcases will be loaded
        /// </summary>
        public List<string> LoadcaseSelection { get; set; }

        /// <summary>
        /// Sets the names of the time steps to load, if left blank all bar names will be loaded
        /// </summary>
        public List<string> TimeStepSelection { get; set; }

        /// <summary>
        /// Check if the result server can store results to file
        /// </summary>
        public bool CanStore {  get { return !string.IsNullOrEmpty(m_TableName); } }

        public ResultOrder OrderBy
        {
            get
            {
                return m_ResultOrder;
            }
            set
            {
                if (value != m_ResultOrder)
                {
                    m_ResultOrder = value;
                    Dictionary<string, IResultSet> results = new Dictionary<string, IResultSet>();

                    int orderCol = m_ColumnNames.IndexOf(m_ResultOrder.ToString());
                    IResultSet rSet = null;
                    foreach (ResultSet<T> set in m_Results.Values)
                    {
                        foreach (object[] row in set.ToListData())
                        {
                            string key = row[orderCol].ToString();
                            if (!results.TryGetValue(key, out rSet))
                            {
                                rSet = new ResultSet<T>();
                                results.Add(key, rSet);
                            }
                            rSet.AddData(row);
                        }                     
                    }
                    m_Results = results;
                }
            }
        }

        public ResultServer(string fileName) : this()
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                string extension = Path.GetExtension(fileName);
                if (string.IsNullOrEmpty(extension))
                {
                    fileName = fileName + ".mdf";
                }
                else
                {
                    fileName = fileName.Replace(extension, ".mdf");
                }

                if (!File.Exists(fileName))
                {
                    CreateSqlDatabase(fileName);
                }

                m_ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + fileName + "; Integrated Security = True; Connect Timeout = 30";
                InitialiseTable();
            }
        }
        public ResultServer(string fileName, bool append) : this(fileName)
        {
            if (!append) ClearData();
        }

        public ResultServer()
        {        
            m_Results = new Dictionary<string, IResultSet>();
            m_ColumnNames = new T().ColumnHeaders.ToList();
        }

        public static void CreateSqlDatabase(string filename)
        {
            string databaseName = "ResultServer";// System.IO.Path.GetFileNameWithoutExtension(filename);
            filename = filename.Replace("'", "''");
            using (var connection = new System.Data.SqlClient.SqlConnection(
                "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30")) 
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, filename);
                    command.ExecuteNonQuery();

                    command.CommandText =
                        String.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InitialiseTable()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
            connection.Open();
            m_TableName = typeof(T).Name.Split('`')[0];
            CreateTable(connection);
            connection.Close();
        }

        public void ClearData()
        {
            if (!string.IsNullOrEmpty(m_TableName))
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("TRUNCATE TABLE " + m_TableName, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            m_Results.Clear();
        }

        public void StoreData(List<T> values)
        {
            if (!string.IsNullOrEmpty(m_TableName))
            {
                using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.DestinationTableName = m_TableName;
                        bulkCopy.BatchSize = 10000;
                        try
                        {
                            bulkCopy.WriteToServer(CreateDataSet(values));
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                values.Sort();
                int orderCol = m_ColumnNames.IndexOf(m_ResultOrder.ToString());
                IResultSet rSet = null;// new ResultSet<T>();
                for (int i = 0; i < values.Count; i++)
                {
                    string key = values[i].Data[orderCol].ToString();
                    if (!m_Results.TryGetValue(key, out rSet))
                    {
                        rSet = new ResultSet<T>();
                        m_Results.Add(key, rSet);
                    }
                    rSet.AddData(values[i].Data);
                }
            }
        }
        
        public Dictionary<string, IResultSet> LoadData()
        {
            if (!string.IsNullOrEmpty(m_TableName))
            {
                string lookupString = "";

                if (NameSelection != null && NameSelection.Count > 0)
                {
                    lookupString = " WHERE NAME IN (";
                    for (int i = 0; i < NameSelection.Count; i++)
                    {
                        lookupString += "'" + NameSelection[i] + "',";
                    }
                    lookupString = lookupString.Trim(',') + ")";
                }

                if (LoadcaseSelection != null && LoadcaseSelection.Count > 0)
                {
                    lookupString += (lookupString != "" ? " AND " : " WHERE ") + "LOADCASE IN (";
                    for (int i = 0; i < LoadcaseSelection.Count; i++)
                    {
                        lookupString += "'" + LoadcaseSelection[i] + "',";
                    }
                    lookupString = lookupString.Trim(',') + ")";
                }

                if (TimeStepSelection != null && TimeStepSelection.Count > 0)
                {
                    lookupString += (lookupString != "" ? " AND " : " WHERE ") + "LOADCASE IN (";
                    for (int i = 0; i < TimeStepSelection.Count; i++)
                    {
                        lookupString += "'" + TimeStepSelection[i] + "',";
                    }
                    lookupString = lookupString.Trim(',') + ")";
                }


                if (m_Results.Count == 0)
                {
                    System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString);
                    connection.Open();

                    string query = "SELECT * FROM " + m_TableName + lookupString;// + ";";
                    string sort = " ORDER BY NAME ASC, LOADCASE ASC, TIMESTEP ASC;";

                    SqlCommand command = new SqlCommand(query + sort, connection);
                    command.CommandTimeout = 0;

                    SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(command);
          
                    DataSet set = new DataSet();
                    dataAdapter.Fill(set);
                    connection.Close();

                    DataRowCollection rows = set.Tables[0].Rows;

                    int orderCol = m_ColumnNames.IndexOf(m_ResultOrder.ToString());
                    IResultSet rSet = null;// new ResultSet<T>();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        string key = rows[i][orderCol].ToString();
                        if (!m_Results.TryGetValue(key, out rSet))
                        {
                            rSet = new ResultSet<T>();
                            m_Results.Add(key, rSet);
                        }
                        rSet.AddData(rows[i].ItemArray);
                    }
                }
            }

            return m_Results;
        }

        //public int GetLoadcaseKey(string loadcaseName)
        //{
        //    int key = 0;
        //    if (int.TryParse(loadcaseName, out key))
        //    {
        //        return key;
        //    }
        //    if (string.IsNullOrEmpty(m_TableName))
        //    {

        //    }
        //}

        private DataTable CreateDataSet(List<T> values)
        {
            #region Property Descriptor Method
            //PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            //var table = new DataTable();
            //foreach (PropertyDescriptor prop in properties)
            //{
            //    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            //}
            //for (int i = 0; i < values.Count; i++)
            //{
            //    DataRow row = table.NewRow();
            //    foreach (PropertyDescriptor prop in properties)
            //        row[prop.Name] = prop.GetValue(values[i]) ?? DBNull.Value;
            //    table.Rows.Add(row);
            //}
            //return table;
            #endregion
            var table = new DataTable();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (string column in m_ColumnNames)
            {
                PropertyDescriptor prop = properties[column];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
         
            for (int i = 0; i < values.Count; i++)
            {
                DataRow row = table.NewRow();
                row.ItemArray = values[i].Data;
               
                table.Rows.Add(row);
            }
            return table;

        }
        private string Properties(string prefix = "")
        {
            string properties = "";
            foreach (var prop in typeof(T).GetProperties())
            {
                properties += prefix + prop.Name + ", ";
            }
            return properties.Trim(' ',',');
        }

        private bool TableExists(SqlConnection con)
        {
            string sqlStatement = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='" + m_TableName +"') SELECT 1 ELSE SELECT 0";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    int x = Convert.ToInt32(cmd.ExecuteScalar());
                    if (x == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CreateTable(SqlConnection con)
        {          
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            string tableColumns = m_TableName + "(";

            foreach (string column in m_ColumnNames)
            {
                PropertyDescriptor prop = properties[column];
                tableColumns += prop.Name + " " + GetDBType(prop.PropertyType, prop.Name) + ",";
            }
            if (!TableExists(con))
            {
                //tableColumns = tableColumns.Trim(',') +");";
                tableColumns += "PRIMARY KEY CLUSTERED ([Id]));";
                using (SqlCommand command = new SqlCommand("CREATE TABLE " + tableColumns, con)) command.ExecuteNonQuery();
            }
            return true;
        }

        private string GetDBType(Type type, string name)
        {
            if (type == typeof(double))
            {
                return "float(53)";
            }
            else if (type == typeof(float))
            {
                return "float(24)";
            }
            else if (type == typeof(string))
            {
                if (name == "Name" || name == "TimeStep")
                {
                    return "varchar(10)";
                }
                else if (name == "Loadcase")
                {
                    return "varchar(30)";
                }               
                return "varchar(50)";
            }
            else if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(Guid))
            {
                return "char(38)";
            }
            else if (type == typeof(DateTime))
            {
                return "date";
            }
            else return "";
        }

        public Envelope MaxEnvelope()
        {
            //LoadData(resultNames);
            Envelope envelope = null;
            foreach (ResultSet<T> set in m_Results.Values)
            {                                
                if (set != null && envelope == null)
                {
                    envelope = set.MaxEnvelope();
                }
                else if (set != null)
                {
                    envelope.Merge(set.MaxEnvelope());
                }
            }
            return envelope;
        }

        public ResultSet<T> this[string name]
        {
            get
            {
                IResultSet result = null;
                if (m_Results.TryGetValue(name, out result))
                {
                    return result as ResultSet<T>;
                }
                else
                {
                    switch (OrderBy)
                    {
                        case ResultOrder.Name:
                            NameSelection = new List<string>() { name };
                            break;
                        case ResultOrder.Loadcase:
                            LoadcaseSelection = new List<string>() { name };
                            break;
                        case ResultOrder.TimeStep:
                            TimeStepSelection = new List<string>() { name };
                            break;
                    }
                    return LoadData().Values.First() as ResultSet<T>;

                }
            }
        }

        public int ResultCount
        {
            get
            {
                int count = 0;
                foreach (ResultSet<T> set in m_Results.Values)
                {
                    count += set.Count;
                }
                return count;
            }
        }

        public List<T> ToList()
        {
            List<T> result = new List<T>();
            foreach (ResultSet<T> set in m_Results.Values)
            {
                result.AddRange(set.ToList());
            }
            return result;
        }

        public List<object[]> ToListData()
        {
            List<object[]> result = new List<object[]>();
            foreach (ResultSet<T> set in m_Results.Values)
            {
                result.AddRange(set.ToListData());
            }
            return result;
        }

        public Dictionary<string, T> ToDictionary()
        {
            Dictionary<string, T> result = new Dictionary<string, T>();
            foreach (T value in ToList())
            {
                result.Add(value.Id, value);
            }
            return result;
        }
    }

}
