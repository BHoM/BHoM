using BHoM.Structural;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    public class ObjectCollection : ObjectCollection<BHoMObject> { }

    /// <summary>
    /// 
    /// </summary>
    public class ObjectCollection<T> : System.Collections.IEnumerable where T : BHoMObject
    {
        private enum Option
        {
            Property,
            UserData
        }

        private Project m_Project;
        private Dictionary<string, T> m_Data;
        private int m_UniqueNumber;
        private Option m_Option;
        private string m_Name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        public ObjectCollection()
        {
            m_Project = Project.ActiveProject;
            m_Data = new Dictionary<string, T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        internal ObjectCollection(Project project, IEnumerable<T> data)
        {
            m_Project = project;
            m_Data = new Dictionary<string, T>();
            m_Option = Option.Property;
            m_Name = "Name";
            foreach (T obj in data)
            {
                m_Data.Add(obj.Name, obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObjectCollection<T> SetUniqueByUserData(string name)
        {
            m_Option = Option.UserData;
            m_Name = name;
            Dictionary<string, T> newDictionary = new Dictionary<string, T>();
            foreach (T value in m_Data.Values)
            {
                newDictionary.Add(value.UserData[name].DataString(), value);
            }

            m_Data = newDictionary;
            
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ObjectCollection<T> SetUniqueByProperty(string name)
        {
            m_Option = Option.Property;
            m_Name = name;
            Dictionary<string, T> newDictionary = new Dictionary<string, T>();
            foreach (T obj in m_Data.Values)
            {
                System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(name);
                if (pInfo != null)
                {
                    newDictionary.Add(pInfo.GetValue(obj).ToString(), obj);
                }
            }

            m_Data = newDictionary;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public ObjectCollection<T> OfClass(Type t)
        {
            IEnumerable<T> data = m_Project.Objects.Cast<T>().Where(obj => obj.GetType() == t);
            return new ObjectCollection<T>(m_Project, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[int key]
        {
            get
            {
                T result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                T result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[string key]
        {
            get
            {
                T result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                T result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        public List<string> Keys
        {
            get
            {
                return m_Data.Keys.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameKey"></param>
        /// <returns></returns>
        public bool Contains(string nameKey)
        {
            T obj = null;
            return m_Data.Count == 0 ? false : m_Data.TryGetValue(nameKey.ToString(), out obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void Add(T obj)
        {
            if (m_Option == Option.Property)
            {
                System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(m_Name);
                if (pInfo != null)
                {
                    m_Data.Add(pInfo.GetValue(obj).ToString(), obj);
                }
            }
            else
            {
                m_Data.Add(obj.UserData[m_Name].DataString(), obj);
            }
            m_Project.AddObject(obj);
            m_UniqueNumber = m_UniqueNumber > 0 ? m_UniqueNumber + 1 : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int UniqueNumber()
        {
            if (m_UniqueNumber == 0)
            {
                foreach (T obj in m_Data.Values)
                {
                    string value = "";
                    if (m_Option == Option.Property)
                    {
                        System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(m_Name);
                        if (pInfo != null)
                        {
                            value = pInfo.GetValue(obj).ToString();
                        }
                    }
                    else
                    {
                        value =  obj.UserData[m_Name].Value.ToString();
                    }

                    int currentValue = 0;
                    if (int.TryParse(value, out currentValue))
                    {
                        m_UniqueNumber = Math.Max(currentValue, m_UniqueNumber);
                    }
                }
            }
            return m_UniqueNumber;
        }


        /// <summary></summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        /// <summary></summary>
        public BHoMObjectEnum GetEnumerator()
        {
            return new BHoMObjectEnum(m_Data.Values.ToArray());
        }



        //public T AddUnique(T item, bool checkNumber)
        //{
        //    BHoMObject obj = item as BHoMObject;
        //    if (obj != null)
        //    {
        //        int counter = 0;
        //        foreach (T element in m_Data)
        //        {
        //            BHoMObject currentObj = element as BHoMObject;
        //            if (currentObj.Name == obj.Name)
        //            {
        //                break;
        //            }
        //            counter++;
        //        }
        //        if (counter == 0)
        //        {
        //            m_Data.Add(item);
        //            m_Project.AddObject(obj);
        //        }
        //        else
        //        {
        //            return m_Data[counter];
        //        }
        //    }
        //    return default(T);
        //}

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return m_Data.Count;
            }
        }

        public string ToJSON()
        {
            string aResult = "{";
            aResult += string.Format("\"{0}\": \"{1}\",", "Primitive", "{" + GetType().AssemblyQualifiedName + "}");

            aResult += "\"DataType\": {" + typeof(T).Name + "}";

            // Write all the properties
            aResult += "\"Data\": {";
            foreach (var item in m_Data)
            {
                aResult += string.Format("\"{0}\": \"{1}\",", item.Key, item.Value.BHoM_Guid);            
            }
            if (aResult.Last() == ',')
                aResult = aResult.Substring(0, aResult.Length - 1);
            aResult += "}";

            return aResult;
        }

        public static ObjectCollection FromJSON(string json)
        {
            // Get the top level definition of the json content
            Dictionary<string, string> definition = Utils.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive") || !definition.ContainsKey("Properties")) return null;

            // Try to create an object that correponds the object type stored in "Primitive"
            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");
            var dataTypeString = definition["DataType"].Replace("\"", "").Replace("{", "").Replace("}", "");
            Type type = Type.GetType(typeString);
            Type dataType = Type.GetType(dataTypeString);
            if (type == null) return null;
            ObjectCollection newObject = Activator.CreateInstance(type) as ObjectCollection;

            // Get the definition of the properties
            Dictionary<string, string> data = Utils.GetDefinitionFromJSON(definition["Properties"]);
            foreach (KeyValuePair<string, string> kvp in data)
            {
                Guid guid = new Guid(kvp.Value.Trim().Replace("\"", ""));
                newObject.m_Data.Add(kvp.Key, newObject.m_Project.GetObject(guid));
            }

            return newObject;
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
