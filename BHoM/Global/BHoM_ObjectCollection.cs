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
            Default,
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
            foreach (BHoMObject obj in m_Project.Objects)
            {
                if (obj.GetType() == typeof(T))
                {
                    m_Data.Add(obj.Name, obj as T);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        internal ObjectCollection(Project project, IEnumerable<T> data)
        {
            m_Project = project;
            m_Data = new Dictionary<string, T>();
            foreach (T obj in data)
            {
                m_Data.Add(obj.Name, obj);
            }
        }

        /// <summary>
        ///  sets the unique identifier to the default which is the name of the object
        /// </summary>
        /// <returns></returns>
        public ObjectCollection<T> SetUniqueDefault()
        {
            ObjectCollection<T> newCollection = new ObjectCollection<T>();
            newCollection.m_Option = Option.Default;
            foreach (T value in m_Data.Values)
            {
                newCollection.Add(value);
            }

            return newCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObjectCollection<T> SetUniqueByUserData(string name)
        {
            ObjectCollection<T> newCollection = new ObjectCollection<T>();
            newCollection.m_Name = name;
            newCollection.m_Option = Option.UserData;
            foreach (T value in m_Data.Values)
            {
                newCollection.Add(value);
            }

            return newCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ObjectCollection<T> SetUniqueByProperty(string name)
        {
            ObjectCollection<T> newCollection = new ObjectCollection<T>();
            newCollection.m_Name = name;
            newCollection.m_Option = Option.Property;
            foreach (T value in m_Data.Values)
            {
                newCollection.Add(value);
            }

            return newCollection;
        }
        

        //public ObjectCollection<T> GetAll()
        //{
        //    ObjectCollection<T> newCollection = new ObjectCollection<T>();
        //    newCollection.m_Name = this.m_Name;
        //    newCollection.m_Option = this.m_Option;
        //    foreach (BHoMObject obj in m_Project.Objects)
        //    {
        //        if (obj.GetType() == typeof(T))
        //        {
        //            newCollection.m_Data.Add(obj.Name, obj as T);
        //        }
        //    }
        //    return newCollection;
        //}

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

        /// <summary>
        /// Returns all the unique identifiers of the collection
        /// </summary>
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
        /// Adds an object to the collection using a data key based on the specified option. Note: key must be unique or object won't be added.
        /// </summary>
        /// <param name="obj">BHoMObject to add</param>
        /// <returns>True if the object was added to collection, false otherwise</returns>
        public bool Add(T obj)
        {
            bool result = false;
            switch (m_Option)
            {
                case Option.Default:
                     result = Add(obj.Name, obj);
                    break;
                case Option.Property:
                    System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(m_Name);
                    if (pInfo != null)
                    {
                        result = Add(pInfo.GetValue(obj).ToString(), obj);
                    }
                    break;
                case Option.UserData:
                    result = Add(obj.UserData[m_Name].DataString(), obj);
                    break;
            }
            if (result)
            {
                m_Project.AddObject(obj);
                m_UniqueNumber = m_UniqueNumber > 0 ? m_UniqueNumber + 1 : 0;
            }
            return result;
        }

        private bool Add(string key, T obj)
        {
            T value;
            if (!m_Data.TryGetValue(key, out value))
            {
                m_Data.Add(key, obj);
                return true;
            }
            return false;
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
                    switch (m_Option)
                    {
                        case Option.Default:
                            value = obj.Name;
                            break;
                        case Option.Property:
                            System.Reflection.PropertyInfo pInfo = obj.GetType().GetProperty(m_Name);
                            if (pInfo != null)
                            {
                                value = pInfo.GetValue(obj).ToString();
                            }
                            break;
                        case Option.UserData:
                            value = obj.UserData[m_Name].Value.ToString();
                            break;
                    }

                    int currentValue = 0;
                    if (int.TryParse(value, out currentValue))
                    {
                        m_UniqueNumber = Math.Max(currentValue, m_UniqueNumber);
                    }
                }
            }
            return ++m_UniqueNumber;
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
