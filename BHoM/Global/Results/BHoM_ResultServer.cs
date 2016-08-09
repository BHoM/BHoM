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

namespace BHoM.Global
{
    public abstract class Envelope
    {
        public double[] Values { get; set; }
        public string[] Cases { get; set; }
        public string[] Keys { get; set; }
        public string[] Names { get; set; }
        public Envelope(List<string> valueNames)
        {
            Names = valueNames.ToArray();
            Values = new double[Names.Length];
            Cases = new string[Names.Length];
            Keys = new string[Names.Length];
        }

        public abstract Envelope Merge(Envelope e2);
    }

    public class MaxEnvelope : Envelope
    {
        public MaxEnvelope(List<string> valueNames) : base (valueNames)
        {
            for (int i = 0; i < Values.Length;i++)
            {
                Values[i] = double.MinValue;
            }
        }

        public override Envelope Merge(Envelope e2)
        {
            if (Values.Length == e2.Values.Length)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Values[i] < e2.Values[i])
                    {
                        Values[i] = e2.Values[i];
                        Cases[i] = e2.Cases[i];
                        Keys[i] = e2.Keys[i];
                    }
                }
            }
            return this;
        }
    }

    public class MinEnvelope : Envelope
    {
        public MinEnvelope(List<string> valueNames) : base(valueNames)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = double.MaxValue;
            }
        }
        public override Envelope Merge(Envelope e2)
        {
            if (Values.Length == e2.Values.Length)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Values[i] > e2.Values[i])
                    {
                        Values[i] = e2.Values[i];
                        Cases[i] = e2.Cases[i];
                        Keys[i] = e2.Keys[i];
                    }
                }
            }
            return this;
        }
    }

    public class AbsoluteEnvelope : Envelope
    {
        public AbsoluteEnvelope(List<string> valueNames) : base(valueNames)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = double.MinValue;
            }
        }
        public override Envelope Merge(Envelope e2)
        {
            if (Values.Length == e2.Values.Length)
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Math.Abs(Values[i]) < Math.Abs(e2.Values[i]))
                    {
                        Values[i] = Math.Abs(e2.Values[i]);
                        Cases[i] = e2.Cases[i];
                        Keys[i] = e2.Keys[i];
                    }
                }
            }
            return this;
        }
    }

    public abstract class Result
    {
        internal object[] Data { get; set; }

        public string Id
        {
            get
            {
                return (string)Data[0];
            }
            set
            {
                Data[0] = value;
            }
        }

        public int Name
        {
            get
            {
                return (int)Data[1];
            }
            set
            {
                Data[1] = value;
            }
        }

        public int Loadcase
        {
            get
            {
                return (int)Data[2];
            }
            set
            {
                Data[2] = value;
            }
        }

        public int TimeStep
        {
            get
            {
                return (int)Data[3];
            }
            set
            {
                Data[3] = value;
            }
        }

        public Result() { }

        public abstract string[] ColumnHeaders { get; }
    }

    public class TestResult : Result
    {
        public override string[] ColumnHeaders
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Value
        {
            get; set;
        }
       // public TestResult(string name, double value) { Value = value; Name = name; }
    }

    public enum ResultOrder
    {
        Name,
        Loadcase,
        TimeStep,
        None
    }

    public class ResultServer<T> where T : Result, new()
    {
        Dictionary<string,ResultSet<T>> m_Results;
        
        string m_TableName;
        string m_ConnectionString;
        List<string> m_ColumnNames;
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
                    Dictionary<string, ResultSet<T>> results = new Dictionary<string, ResultSet<T>>();

                    int orderCol = m_ColumnNames.IndexOf(m_ResultOrder.ToString());
                    ResultSet<T> rSet = null;// new ResultSet<T>();
                    foreach (ResultSet<T> set in m_Results.Values)
                    {
                        foreach (object[] row in set.RawData)
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

        public ResultServer(string fileName)
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
            m_Results = new Dictionary<string, ResultSet<T>>();
            InitialiseTable();
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
            m_TableName = typeof(T).Name;
            CreateTable(connection);
        }

        public void ClearData()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(m_ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE " + m_TableName, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void StoreData(List<T> values)
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

        public void LoadData()
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

                string query = "SELECT * FROM " + m_TableName + lookupString + ";";

                SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(query, connection);
                DataSet set = new DataSet();

                dataAdapter.Fill(set);
                connection.Close();

                DataRowCollection rows = set.Tables[0].Rows;

                int orderCol = m_ColumnNames.IndexOf(m_ResultOrder.ToString());
                ResultSet<T> rSet = null;// new ResultSet<T>();
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

            //for (int i = 0; i < m_ColumnNames.Count; i++)
            //{
            //    table.Columns.Add();
            //}

            for (int i = 0; i < values.Count; i++)
            {
                DataRow row = table.NewRow();
                row.ItemArray = values[i].Data;
                //for (int j = 0; j < m_ColumnNames.Count; j++)
                //{
                //    row[m_ColumnNames[j]] = values[i].Data[j] ?? DBNull.Value;
                //}
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
            string sqlStatement = @"SELECT COUNT(*) FROM " + m_TableName;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool CreateTable(SqlConnection con)
        {
            //string tableColumns = typeof(T).Name + "(";
            //m_ColumnNames = new T().ColumnHeaders.ToList();

            //foreach (var prop in typeof(T).GetProperties())
            //{
            //    m_ColumnNames.Add(prop.Name);
            //    tableColumns += prop.Name + " " + GetDBType(prop.PropertyType, prop.Name) + ",";
            //}
            //if (!TableExists(con))
            //{
            //    //tableColumns = tableColumns.Trim(',') +");";
            //    tableColumns += "PRIMARY KEY CLUSTERED ([Id] ASC));";
            //    using (SqlCommand command = new SqlCommand("CREATE TABLE " + tableColumns, con)) command.ExecuteNonQuery();
            //}

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            string tableColumns = typeof(T).Name + "(";
            m_ColumnNames = new T().ColumnHeaders.ToList();

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
                return "varchar(16)";
            }
            else if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(Guid))
            {
                return "char(38)";
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
                ResultSet<T> result = null;
                m_Results.TryGetValue(name, out result);
                return result;
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

    public class ResultSet<T> where T : Result, new()
    {
        private Dictionary<string, object[]> m_Results;
        
        //private List<string> m_ColumnNames;
        private List<string> m_ValueNames;
        private List<int> m_NumberIndices;
        int CaseIndex;
        int KeyIndex;
        int TimeStepIndex;

        internal ResultSet()
        {
            #region Old Method
            //m_ColumnNames = new List<string>();
            //m_ValueNames = new List<string>();
            //m_NumberIndices = new List<int>();
            //int index = 0;
            //foreach (var prop in typeof(T).GetProperties())
            //{
            //    m_ColumnNames.Add(prop.Name);
            //    if (prop.Name == "Case") CaseIndex = index;
            //    if (prop.Name == "Id") KeyIndex = index;
            //    if (prop.Name == "TimeStep") TimeStepIndex = index;
            //    if (Type.GetTypeCode(prop.PropertyType) == TypeCode.Single || Type.GetTypeCode(prop.PropertyType) == TypeCode.Double)
            //    {
            //        m_ValueNames.Add(prop.Name);
            //        m_NumberIndices.Add(index);
            //    }
            //    index++;
            //}
            //m_Results = new Dictionary<string, object[]>();
            #endregion
            List<string> columns = new T().ColumnHeaders.ToList();
            m_ValueNames = new List<string>();
            m_NumberIndices = new List<int>();
            int index = 0;

            CaseIndex = columns.IndexOf("Loadcase");
            KeyIndex = columns.IndexOf("Id");
            TimeStepIndex = columns.IndexOf("TimeStep");

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (var col in columns)
            {
                PropertyDescriptor prop = properties[col];
                if (Type.GetTypeCode(prop.PropertyType) == TypeCode.Single || Type.GetTypeCode(prop.PropertyType) == TypeCode.Double)
                {
                    m_ValueNames.Add(prop.Name);
                    m_NumberIndices.Add(index);
                }
                index++;
            }
            m_Results = new Dictionary<string, object[]>();
        }

        public ResultSet(List<object[]> rows) : this()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                m_Results.Add(rows[i][KeyIndex].ToString(), rows[i]);
            }
        }

        internal void AddData(IEnumerable<object[]> rows)
        {
            foreach (object[] dataRow in rows)
            {
                m_Results.Add(dataRow[KeyIndex].ToString(), dataRow);
            }
        }

        internal void AddData(object[] row)
        {        
            m_Results.Add(row[KeyIndex].ToString(), row);          
        }

        public int Count { get { return m_Results.Count; } }

        internal IEnumerable<object[]> RawData {  get { return m_Results.Values; } }

        public List<T> ToList()
        {
            List<T> listResults = new List<T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (object[] row in m_Results.Values)
            {
                T result = new T();
                result.Data = row;
                //for(int i = 0; i < properties.Count; i++)
                //{
                //    properties[i].SetValue(result, row[i]);
                //}
                listResults.Add(result);
            }
            return listResults;
        }

        public List<object[]> ToListData()
        {
            return m_Results.Values.ToList();
        }

        public Dictionary<string, T> ToDictionary()
        {
            Dictionary<string, T> dictionaryResults = new Dictionary<string, T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (object[] row in m_Results.Values)
            {
                T result = new T(); //T result = Activator.CreateInstance(typeof(T), true) as T;

                for (int i = 0; i < properties.Count; i++)
                {
                    properties[i].SetValue(result, row[i]);
                }
                dictionaryResults.Add(result.Id, result);
            }
            return dictionaryResults;
        }


        public bool IsEmpty { get { return m_Results.Count == 0; } }

        public Envelope MaxEnvelope()
        {
            Envelope envelope = new MaxEnvelope(m_ValueNames);
            foreach (object[] row in m_Results.Values)
            {
                for (int i = 0; i < m_NumberIndices.Count;i++)
                {
                    float currentValue = (float)row[m_NumberIndices[i]];
                    if (currentValue > envelope.Values[i])
                    {
                        envelope.Values[i] = currentValue;
                        envelope.Keys[i] = row[KeyIndex].ToString();
                        envelope.Cases[i] = row[CaseIndex].ToString();
                    }
                }
            }
            return envelope;
        }

        public Envelope MinEnvelope()
        {
            Envelope envelope = new MinEnvelope(m_ValueNames);
            foreach (object[] row in m_Results.Values)
            {
                for (int i = 0; i < m_NumberIndices.Count; i++)
                {
                    double currentValue = (double)row[m_NumberIndices[i]];
                    if (currentValue < envelope.Values[i])
                    {
                        envelope.Values[i] = currentValue;
                        envelope.Keys[i] = row[KeyIndex].ToString();
                        envelope.Cases[i] = row[CaseIndex].ToString();
                    }
                }
            }
            return envelope;
        }

    }
}
