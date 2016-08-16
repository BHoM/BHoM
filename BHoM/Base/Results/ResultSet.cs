using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
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

        internal IEnumerable<object[]> RawData { get { return m_Results.Values; } }

        public List<T> ToList()
        {
            List<T> listResults = new List<T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (object[] row in ToListData())
            {
                T result = new T();
                result.Data = row;
                listResults.Add(result);
            }
            return listResults;
        }

        public List<object[]> ToListData()
        {
            //List<object[]> data = m_Results.Values.ToList();
            //data.Sort(delegate (object[] o1, object[] o2)
            //{
            //    int v1 = (int)o1[1] * 1000000000 + (int)o1[2] * 100000 + (int)o1[3];
            //    int v2 = (int)o2[1] * 1000000000 + (int)o2[2] * 100000 + (int)o2[3];
            //    return v1.CompareTo(v2);
            //});

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
                for (int i = 0; i < m_NumberIndices.Count; i++)
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
