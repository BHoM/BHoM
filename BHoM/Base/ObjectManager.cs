using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Global;
using BHoM.Structural.Loads;

namespace BHoM.Base
{
    /// <summary>
    /// Object manager Class.
    /// Used to add objects to the project where a unique identifier other than a Guid is required. Just inputting the BHoMObject type will default the key to the object name.
    /// </summary>
    /// <typeparam name="TValue">Type of BHoMObject</typeparam>
    public class ObjectManager<TValue> : ObjectManager<string, TValue> where TValue : IBase
    {
        /// <summary>
        /// Initialises a new object manager where the BHoM object name is used as the default key
        /// </summary>
        public ObjectManager(Project project) : base(project, "", FilterOption.Name)
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectManager() : this (Project.ActiveProject) { }         
    }


    /// <summary>
    /// Object manager Class.
    /// Used to add objects to the project where a unique identifier other than a Guid is required
    /// </summary>
    /// <typeparam name="TKey">Type of unique identifier</typeparam>
    /// <typeparam name="TValue">Type of BHoMObject</typeparam>
    public class ObjectManager<TKey, TValue> : IEnumerable<TValue> where TValue : IBase
    {
        Project m_Project;
        Dictionary<TKey, TValue> m_Data;
        FilterOption m_Option;
        string m_Name;
        int m_UniqueNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="option"></param>
        public ObjectManager(string name, FilterOption option) : this (Project.ActiveProject, name, option)  {  }

        /// <summary>
        /// Initialises a new object manager based on the input name and option
        /// </summary>
        /// <param name="project"></param>
        /// <param name="name">Name of the BHoM Property or userdata name</param>
        /// <param name="option">Fliter option defines the type of key to be used</param>
        public ObjectManager(Project project, string name, FilterOption option)
        {
            Initialise(project, name, option);
        }
        
        protected void Initialise(Project project, string name, FilterOption option)
        {
            m_Project = project;      
            m_Data = new ObjectFilter<TValue>(project).ToDictionary<TKey>(name, option);            
            m_Option = option;
            m_Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public TValue Add(TKey key, TValue value)
        {
            TValue result = default(TValue);

            if (!m_Data.TryGetValue(key, out result))
            {
                m_Data.Add(key, value);
                m_Project.AddObject(value as BHoMObject);
                if (m_UniqueNumber > 0) m_UniqueNumber++;
                result = value;

                switch (m_Option)
                {
                    case FilterOption.Guid:
                        break;
                    case FilterOption.Name:
                        value.Name = key.ToString();
                        break;
                    case FilterOption.Property:
                        value.GetType().GetProperty(m_Name).SetValue(value, key);
                        break;
                    case FilterOption.UserData:
                        object objValue = null;
                        if (value.CustomData.TryGetValue(m_Name, out objValue))
                        {
                            value.CustomData[m_Name] = key;
                        }
                        else
                        {
                            value.CustomData.Add(m_Name, key);
                        }

                        break;
                }
            }     
          
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetUniqueNumber()
        {
            if (m_UniqueNumber == 0)
            {
                if (m_Data.Count > 0 && m_Data.Values.First().GetType() == typeof(Int32))
                {
                    foreach (TKey value in m_Data.Keys)
                    {
                        int key = int.Parse(value.ToString());
                        m_UniqueNumber = Math.Max(key, m_UniqueNumber);
                    }
                }
                else
                {
                    foreach (TKey value in m_Data.Keys)
                    {
                        int key = 0;
                        int.TryParse(key.ToString(), out key);                       
                        m_UniqueNumber = Math.Max(key, m_UniqueNumber);
                    }
                }
            }
            return ++m_UniqueNumber;
        }

        /// <summary>
        /// Lookup object which corresponds to the input key. Note: if the key does not exists nothing will be returned
        /// </summary>
        /// <param name="key">object key</param>
        /// <returns>object corresponding to key</returns>
        public TValue this[TKey key]
        {
            get
            {
                return TryLookup(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public List<TValue> GetRange(IEnumerable<TKey> keys)
        {
            List<TValue> values = new List<TValue>();
            foreach (TKey key in keys)
            {
                values.Add(TryLookup(key));
            }
            return values;
        }

        /// <summary>
        /// Safe method for looking up value in dictionary
        /// </summary>
        /// <param name="key">object key</param>
        /// <returns>if key exists it will return the object, null otherwise</returns>
        public TValue TryLookup(TKey key)
        {
            TValue result = default(TValue);
            m_Data.TryGetValue(key, out result);
            return result;
        }

        /// <summary>
        /// Remove and object from the manager with the matching key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            TValue result = default(TValue);
            if (m_Data.TryGetValue(key, out result))
            {
                m_Data.Remove(key);
                m_Project.RemoveObject(result.BHoM_Guid);
            }
        }

        public List<TKey> Keys
        {
            get
            {
                return m_Data.Keys.ToList();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TValue> GetEnumerator()
        {
            return m_Data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Data.Values.GetEnumerator();
        }

        /// <summary>
        /// Number of objects in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return m_Data.Count;
            }
        }       
    }
}
