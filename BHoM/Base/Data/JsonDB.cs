using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Data
{
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
                    m_JObj = JObject.Parse(fs.ReadToEnd());
                    fs.Close();
                }
            }
        }
        private JObject m_JObj;
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

        public JsonFileDB(Database type)
        {
            switch (type)
            {
                case Database.SteelSection:
                    m_JObj = JObject.Parse(BHoM.Properties.Resources.SteelSectionDB.ToString());
                    break;
                case Database.Material:
                    m_JObj = JObject.Parse(BHoM.Properties.Resources.MaterialDB.ToString());
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
            var row = GetRawDataSet().Where(c => (string)c[column] == matches).First();
            return (T)JsonReader.ReadObject(row.ToString());
        }

        private IEnumerable<JToken> GetRawDataSet(string column, string matches)
        {
            return GetRawDataSet().Where(c => (string)c[column] == matches);
        }

        private IEnumerable<JToken> GetRawDataSet()
        {
            List<IDataRow> result = new List<IDataRow>();
            JToken table = m_JObj.SelectToken("$.Tables[?(@.Name == '" + TableName + "')]");
            return table["Rows"];
        }

        public List<IDataRow> GetDataSet(string column, string matches)
        {
            List<IDataRow> result = new List<IDataRow>();
            foreach (JToken row in GetRawDataSet(column, matches))
            {
                result.Add((T)JsonReader.ReadObject(row.ToString()));
            }
            return result;
        }

        public IDataRow GetDataRow(string[] column, string[] matches, bool AND = false)
        {
            try
            {
                var row = GetRawDataSet().Where(c => (string)c[column[0]] == matches[0] && (string)c[column[1]] == matches[1]).First();
                return ((T)JsonReader.ReadObject(row.ToString()));
            }
            catch
            {
                return null;
            }
        }

        public List<string> Names()
        {
            List<string> result = new List<string>();
            return GetRawDataSet().Select(t => (string)t.SelectToken("Name")).ToList();

            //foreach (JToken token in m_JObj["Rows"])
            //{
            //    result.Add(token["Name"].Value<string>());
            //}
            //return result;
        }

        public List<IDataRow> Query(string query)
        {
            List<IDataRow> objs = new List<IDataRow>();
            foreach (JToken token in m_JObj.SelectTokens(query))
            {
                objs.Add((T)token.ToObject(typeof(T)));
            }
            return objs;
        }

        public List<string> TableNames()
        {
            return m_JObj["Tables"].Select(t => (string)t.SelectToken("Name")).ToList();
        }

        public T1 GetDataRow<T1>(string column, string matches) where T1 : IDataRow
        {
            return (T1)GetDataRow(column, matches);
        }

        public List<string> GetDataColumn(string columnName)
        {
            return GetRawDataSet().Select(t => (string)t.SelectToken(columnName)).ToList();
        }

        public List<string> GetDataColumn(string columnName, string column, string matches)
        {
            return GetRawDataSet(column, matches).Select(r => (string)r.SelectToken(columnName)).ToList();
        }
    }
}
