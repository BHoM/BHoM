using BHoM.Structural;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public enum FilterOption
    {
        Name,
        Guid,
        Property,
        UserData
    }

    public class ObjectFilter : ObjectFilter<BHoMObject> { }

    /// <summary>
    /// 
    /// </summary>
    public class ObjectFilter<T> : IEnumerable<T> where T : BHoMObject
    {
        private Project m_Project;
        private List<T> m_Data;
        private int m_UniqueNumber;
        private FilterOption m_Option;
        private string m_Name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        public ObjectFilter()
        {
            m_Project = Project.ActiveProject;
            m_Data = FilterClass(m_Project.Objects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        internal ObjectFilter(Project project, List<T> list)
        {
            m_Project = project;
            m_Data = new List<T>();
            for(int i = 0; i < list.Count;i++)
            {
                m_Data.Add(list[i]);
            }
        }

        private List<T> FilterClass(IEnumerable<BHoMObject> list)
        {
            List<T> result = new List<T>();
            foreach (BHoMObject obj in list)
            {
                if (obj.GetType() == typeof(T))
                {
                    result.Add(obj as T);
                }
            }
            return result;
        }

        //public ObjectFilter<T> OfClass(Type t)
        //{
        //    return new ObjectFilter<T>(m_Project, result);
        //}

        public ObjectFilter<T> Implements(Type t)
        {
            List<T> result = new List<T>();
            foreach (BHoMObject obj in m_Data)
            {
                if (t.IsAssignableFrom(obj.GetType()))
                {
                    result.Add(obj as T);
                }
            }
            return new ObjectFilter<T>(m_Project, result);
        }

        /// <summary>
        /// Create a dictionary based on a defined unqiue key, Note: if duplicate keys exists on the first one found will be added
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="option"></param>
        /// <returns>A key, value pair based on the input option</returns>
        public Dictionary<TKey,T> ToDictionary<TKey>(string propertyName, FilterOption option)
        {
            Dictionary<TKey, T> result = new Dictionary<TKey, T>();
            for (int i = 0; i < m_Data.Count; i++)
            {
                TKey key = GetKey<TKey>(m_Data[i], propertyName, option);
                T value = default(T);
                if (key != null && !result.TryGetValue(key, out value))
                {
                    result.Add(key, m_Data[i]);
                }
            }
            return result;
        }
        internal static TKey GetKey<TKey>(T obj, string name, FilterOption option)
        {
            bool result = false;
            switch (option)
            {
                case FilterOption.Name:
                    return (TKey)(object)obj.Name;
                case FilterOption.Guid:
                    return (TKey)(object)obj.BHoM_Guid;
                case FilterOption.Property:
                    System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(name);
                    if (pInfo != null)
                    {
                        return (TKey)(object)pInfo.GetValue(obj);
                    }
                    break;
                case FilterOption.UserData:
                    return (TKey)(object)obj.CustomData[name];
            }
            return default(TKey);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Data.GetEnumerator();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BHoMObjectEnum : IEnumerator
    {
        /// <summary></summary>
        public BHoMObject[] _BHoMOjects;

        int position = -1;

        /// <summary></summary>
        /// <param name="list"></param>
        public BHoMObjectEnum(BHoMObject[] list)
        {
            _BHoMOjects = list;
        }

        /// <summary></summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary></summary>
        public BHoMObject Current
        {
            get
            {
                try
                {
                    return _BHoMOjects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary></summary>
        public bool MoveNext()
        {
            position++;
            return (position < _BHoMOjects.Length);
        }

        /// <summary></summary>
        public void Reset()
        {
            position = -1;
        }
    }
}
