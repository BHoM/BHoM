using BHoM.Structural;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Global;

namespace BHoM.Base
{
    public enum FilterOption
    {
        Name,
        Guid,
        Property,
        UserData
    }

    public class ObjectFilter : ObjectFilter<BHoMObject>
    {
        public ObjectFilter(Project project) : base(project) { }

        public ObjectFilter() : this(Project.ActiveProject) { }

        public ObjectFilter(List<BHoMObject> objects)
        {
            m_Data = objects;
        }

        public ObjectFilter<BHoMObject> OfClass(Type t)
        {
            List<BHoMObject> result = new List<BHoMObject>();
            foreach (object obj in m_Data)
            {
                if (t.IsAssignableFrom(obj.GetType()))
                {
                    result.Add(obj as BHoMObject);
                }
            }
            return new ObjectFilter(result);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ObjectFilter<T> : IEnumerable<T>, IEnumerable where T : IBase
    {
        private Project m_Project;
        protected List<T> m_Data;
        private int m_UniqueNumber;
        private FilterOption m_Option;
        private string m_Name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        public ObjectFilter(Project project)
        {
            m_Project = project;
            m_Data = FilterClass(m_Project.Objects);
        }

        


        public ObjectFilter() : this(Project.ActiveProject) { }

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
                if (typeof(T).IsAssignableFrom(obj.GetType()))
                {
                    result.Add((T)(object)obj);
                }
            }
            return result;
        }

        public ObjectFilter<T> Implements(Type t)
        {
            List<T> result = new List<T>();
            foreach (IBase obj in m_Data)
            {
                if (t.IsAssignableFrom(obj.GetType()))
                {
                    result.Add((T)(object)obj);
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
                if (key != null  && !result.TryGetValue(key, out value))
                {
                    result.Add(key, m_Data[i]);
                }
            }
            return result;
        }
        internal static TKey GetKey<TKey>(T obj, string name, FilterOption option)
        {
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
                    object keyResult = null;
                    if (obj.CustomData.TryGetValue(name, out keyResult))
                    {
                        if (keyResult.GetType() != typeof(TKey))
                        {
                            System.Reflection.MethodInfo parseMethod = typeof(TKey).GetMethod("Parse", new Type[] { typeof(string) });
                            if (parseMethod != null)
                            {
                                obj.CustomData[name] = (obj.CustomData[name] = parseMethod.Invoke(null, new object[] { keyResult.ToString() }));
                                return (TKey)(object)obj.CustomData[name];
                            }
                        }
                        else
                        {
                            return (TKey)(object)keyResult;
                        }
                       
                    }
                    return default(TKey);
            }
            return default(TKey);
        }
   
        public IEnumerator GetEnumerator()
        {
            return m_Data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
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
