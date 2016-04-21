using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectParameters : IEnumerable
    {
        Dictionary<string, Parameter> m_Parameters;

        internal ObjectParameters()
        {
            m_Parameters = new Dictionary<string, Parameter>();
        }

        internal void AddParameter(Parameter parameter)
        {
            m_Parameters.Add(parameter.Name, parameter);
        }

        private void AddItem(string name, object data)
        {
            AddItem<object>(name, data);
        }

        public void AddItem<T>(string name, T data)
        {
            Parameter p = null;
            if (m_Parameters.TryGetValue(name, out p))
            {
                p.SetValue(data);
            }
            else
            {
                m_Parameters.Add(name, Parameter.CreateData(name, data));
            }
        }

        public void AddList<T>(string name, List<T> data)
        {
            Parameter p = null;
            if (m_Parameters.TryGetValue(name, out p))
            {
                p.SetValue(data);
            }
            else
            {
                m_Parameters.Add(name, Parameter.CreateDataList(name, data));
            }
        }

        public Parameter this[string key]
        {
            get
            {
                Parameter p = null;
                m_Parameters.TryGetValue(key, out p);
                return p;
            }
        }


        public T LookUp<T>(string key)
        {
            Parameter p = null;
            if (m_Parameters.TryGetValue(key, out p))
            {
                return p.GetData<T>();
            }

            return default(T); 
        }

        public IEnumerator GetEnumerator()
        {
            return m_Parameters.Values.GetEnumerator();
        }

      
        //internal void SetObject(string key, object value)
        //{
        //    Parameter p = null;
        //    if (m_Parameters.TryGetValue(key, out p))
        //    {
        //        p.SetValue(value);
        //    }
        //    else
        //    {
        //        AddItem(key, value);
        //    }
        //}
    }
}
