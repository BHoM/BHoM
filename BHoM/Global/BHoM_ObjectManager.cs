using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    /// <summary>
    /// Object manager Class.
    /// Used to add objects to the project where a unique identifier other than a Guid is required. Just inputting the BHoMObject type will default the key to the object name.
    /// </summary>
    /// <typeparam name="TValue">Type of BHoMObject</typeparam>
    public class ObjectManager<TValue> : ObjectManager<string, TValue> where TValue : BHoMObject
    {
        /// <summary>
        /// Initialises a new object manager where the BHoM object name is used as the default key
        /// </summary>
        public ObjectManager() : base("", FilterOption.Name) { }
       

    }

    /// <summary>
    /// Object manager Class.
    /// Used to add objects to the project where a unique identifier other than a Guid is required
    /// </summary>
    /// <typeparam name="TKey">Type of unique identifier</typeparam>
    /// <typeparam name="TValue">Type of BHoMObject</typeparam>
    public class ObjectManager<TKey, TValue> : IEnumerable<TValue> where TValue : BHoMObject
    {
        Dictionary<TKey, TValue> m_Data;
        FilterOption m_Option;
        string m_Name;
        int m_UniqueNumber;

        /// <summary>
        /// Initialises a new object manager based on the input name and option
        /// </summary>
        /// <param name="name">Name of the BHoM Property or userdata name</param>
        /// <param name="option">Fliter option defines the type of key to be used</param>
        public ObjectManager(string name, FilterOption option)
        {
            m_Data = new ObjectFilter<TValue>().ToDictionary<TKey>(name, option);
            m_Option = option;
            m_Name = name;
        }
        
        /// <summary>
        /// Adds an object to the collection checking if the defined key is unique
        /// </summary>
        /// <param name="obj">BHoM object to add to the collection</param>
        /// <returns>True is object was added, false otherwise</returns>
        public bool Add(TValue obj)
        {
            TValue value;
            TKey key = ObjectFilter.GetKey<TKey>(obj, m_Name, m_Option);
            if (!m_Data.TryGetValue(key, out value))
            {
                m_Data.Add(key, obj);
                Project.ActiveProject.AddObject(obj);
                if (m_UniqueNumber > 0) m_UniqueNumber++;
                return true;
            }
            return false;
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
        /// Lookup object which corresponds to the input key. Note: if the key does not exists an exception will be thrown. Use TryLookup as a safe alternative
        /// </summary>
        /// <param name="key">object key</param>
        /// <returns>object corresponding to key</returns>
        public TValue this[TKey key]
        {
            get
            {
                return m_Data[key];
            }
        }

        /// <summary>
        /// Safe method for looking up value in dictionary
        /// </summary>
        /// <param name="key">object key</param>
        /// <returns>if key exists it will return the object, null otherwise</returns>
        public TValue TryLookup(TKey key)
        {
            TValue result = null;
            m_Data.TryGetValue(key, out result);
            return result;
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
