using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Data
{
    public class DatabaseObject
    {
        public string Name { get; set; }
        public List<TableObject> Tables { get; set; }
        public DatabaseObject(string name) { Name = name; Tables = new List<TableObject>(); }
    }

    public class TableObject
    {
        public string Name { get; set; }
        public List<IDataRow> Rows { get; set; }
        public TableObject(string name, List<IDataRow> rows) { Name = name; Rows = rows; }
    }

    public class JsonFileDB<T> : IDataAdapter where T : IDataRow
    {
        public string Filename
        {
            get
            {
                return m_Filename;
            }
            set
            {
                m_Filename = value;

                using (StreamReader fs = new StreamReader(m_Filename))
                {
                    m_JObj = JsonReader.ReadObject(fs.ReadToEnd()) as DatabaseObject;
                    fs.Close();
                }
            }
        }
        private DatabaseObject m_JObj;
        private string m_Filename;
        public string TableName
        {
            get;
            set;
        }

        public JsonFileDB(string filename)
        {
            Filename = filename;
        }

        public JsonFileDB(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.SteelSection:
                    m_JObj = JsonReader.ReadObject(BHoM.Properties.Resources.SteelSectionDB.ToString()) as DatabaseObject; 
                    break;
                case DatabaseType.Material:
                    m_JObj = JsonReader.ReadObject(BHoM.Properties.Resources.MaterialDB.ToString()) as DatabaseObject;
                    break;
            }
            
        }

        public List<string> ColumnNames()
        {
            List<string> result = new List<string>();
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                if (p.CanRead && p.CanWrite)
                {
                    result.Add(p.Name);
                }
            }
            return result;
        }

        public IDataRow GetDataRow(string column, string matches)
        {
            return (T)GetRawDataSet(column, matches).First();
        }

        private IEnumerable<T> GetRawDataSet(string column, string matches)
        {
            return Filter(GetRawDataSet(), column, matches);
        }


        private static IEnumerable<T> Filter(IEnumerable<T> list, string column, string matches)
        {
            PropertyInfo p = typeof(T).GetProperty(column);
            if (p != null)
            {
                return list.Where(c => p.GetValue(c).ToString() == matches);
            }
            else
            {
                return new List<T>();
            }
        }

        private IEnumerable<T> GetRawDataSet()
        {
            TableObject table = m_JObj.Tables.Where(t => t.Name == TableName).First();
            return table != null ? table.Rows.Cast<T>() : new List<T>();
        }

        public List<IDataRow> GetDataSet(string column, string matches)
        {
            return GetRawDataSet(column, matches).Cast<IDataRow>().ToList();
        }

        public IDataRow GetDataRow(string[] column, string[] matches, bool AND = false)
        {
            List<T> result = GetRawDataSet(column[0], matches[0]).ToList();
            for (int i = 1; i < column.Length; i++)
            {
                if (AND)
                {
                    result = Filter(result, column[i], matches[i]).ToList();
                }
                else
                {
                    result.AddRange(GetRawDataSet(column[i], matches[i]));
                }
            }
            return result.First();
        }

        public List<string> Names()
        {
            List<string> result = new List<string>();
            return GetRawDataSet().Select(r => r.Name).ToList();
        }

        public List<IDataRow> Query(string query)
        {
            return null;
        }

        public List<string> TableNames()
        {
            return m_JObj.Tables.Select(t => t.Name).ToList();
        }

        public T1 GetDataRow<T1>(string column, string matches) where T1 : IDataRow
        {
            return (T1)GetDataRow(column, matches);
        }

        public List<string> GetDataColumn(string columnName)
        {
            PropertyInfo p = typeof(T).GetProperty(columnName);
            if (p != null)
            {
                return GetRawDataSet().Select(r => p.GetValue(r).ToString()).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        public List<string> GetDataColumn(string columnName, string column, string matches)
        {
            PropertyInfo matchColumn = typeof(T).GetProperty(column);
            PropertyInfo resultColumn = typeof(T).GetProperty(columnName);
            if (matchColumn != null && resultColumn != null)
            {
                return GetRawDataSet().Where(r=> matchColumn.GetValue(r).ToString() == matches).Select(r => resultColumn.GetValue(r).ToString()).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
