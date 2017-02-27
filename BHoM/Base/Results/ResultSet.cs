using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base.Results
{
    public interface IResultSet
    {
        void AddData(IEnumerable<object[]> rows);
        void AddData(object[] rows);
        List<object[]> ToListData();
        List<T> AsList<T>() where T : IResult, new();
        Envelope MaxEnvelope();
        Envelope MinEnvelope();
        Envelope AbsoluteEnvelope();
    }


    public class ResultSet<T> : IResultSet where T : IResult, new()
    {
        private List<object[]> m_Results;       
        private List<string> m_ValueNames;
        private List<int> m_NumberIndices;
        int CaseIndex;
        int NameIndex;
        int TimeStepIndex;

        public ResultSet()
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
            NameIndex = columns.IndexOf("Name");
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
            m_Results = new List<object[]>();
        }

        public ResultSet(List<object[]> rows) : this()
        {
            m_Results = rows;
        }

        public void AddData(IEnumerable<object[]> rows)
        {
            foreach (object[] dataRow in rows)
            {
                m_Results.Add(dataRow);
            }
        }

        public void AddData(IEnumerable<T> rows)
        {
            foreach (T dataRow in rows)
            {
                m_Results.Add(dataRow.GetData());
            }
        }

        public void AddData(object[] row)
        {
            m_Results.Add(row);
        }

        public void AddData(T row)
        {
            m_Results.Add(row.GetData());
        }

        public void Clear()
        {
            m_Results.Clear();
        }

        public int Count { get { return m_Results.Count; } }
       
        public List<T> ToList()
        {
            List<T> listResults = new List<T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (object[] row in ToListData())
            {
                T result = new T();
                result.SetData(row);
                listResults.Add(result);
            }
            return listResults;
        }

        public List<object[]> ToListData()
        {
            return m_Results.ToList();
        }        

        public Dictionary<string, T> ToDictionary()
        {
            Dictionary<string, T> dictionaryResults = new Dictionary<string, T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (object[] row in m_Results)
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

        public T this[int idx]
        {
            get
            {
                T result = new T();
                result.SetData(m_Results[idx]);
                return result;
            }
        }


        public int CriticalResultIndex()
        {
            double max = double.MinValue;
            int resultIndex = 0;
            object[] row = null;
            for (int i = 0; i < m_Results.Count; i++)
            {
                row = m_Results[i];
                for (int j = 0; j < m_NumberIndices.Count; j++)
                {
                    double currentValue = row[m_NumberIndices[j]] != null ? (double)row[m_NumberIndices[j]] : 0;
                    if (currentValue > max)
                    {
                        max = currentValue;
                        resultIndex = i;
                    }
                }
            }
            return resultIndex;
        }

        public Envelope MaxEnvelope()
        {
            Envelope envelope = new MaxEnvelope(m_ValueNames);
            for (int i = 0; i < m_Results.Count; i++)
            {
                object[] row = m_Results[i];
                for (int j = 0; j < m_NumberIndices.Count; j++)
                {
                    double currentValue = (double)row[m_NumberIndices[j]];
                    if (currentValue > envelope.Values[j])
                    {
                        envelope.Values[j] = currentValue;
                        envelope.Keys[j] = row[NameIndex].ToString();
                        envelope.Cases[j] = row[CaseIndex].ToString();
                    }
                }
            }
            return envelope;
        }

        public Envelope MinEnvelope()
        {
            Envelope envelope = new MinEnvelope(m_ValueNames);
            for (int i = 0; i < m_Results.Count; i++)
            {
                object[] row = m_Results[i];
                for (int j = 0; j < m_NumberIndices.Count; j++)
                {
                    double currentValue = (double)row[m_NumberIndices[j]];
                    if (currentValue < envelope.Values[j])
                    {
                        envelope.Values[j] = currentValue;
                        envelope.Keys[j] = row[NameIndex].ToString();
                        envelope.Cases[j] = row[CaseIndex].ToString();
                    }
                }
            }
            return envelope;
        }


        public Envelope AbsoluteEnvelope()
        {
            Envelope envelope = new MaxEnvelope(m_ValueNames);
            for (int i = 0; i < m_Results.Count; i++)
            {
                object[] row = m_Results[i];
                for (int j = 0; j < m_NumberIndices.Count; j++)
                {
                    double currentValue = Math.Abs((double)row[m_NumberIndices[j]]);
                    if (currentValue > envelope.Values[j])
                    {
                        envelope.Values[j] = currentValue;
                        envelope.Keys[j] = row[NameIndex].ToString();
                        envelope.Cases[j] = row[CaseIndex].ToString();
                    }
                }
            }
            return envelope;
        }

        public List<T1> AsList<T1>()  where T1 : IResult, new()
        {
            List<T1> listResults = new List<T1>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T1));
            foreach (object[] row in ToListData())
            {
                T1 result = new T1();
                result.SetData(row);
                listResults.Add(result);
            }
            return listResults;
        }
    }
}
