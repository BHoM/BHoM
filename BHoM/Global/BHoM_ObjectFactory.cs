using BHoM.Structural;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Global
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ObjectFactory : System.Collections.IEnumerable
    {
        protected bool m_UniqueByNumber;
        private Project m_Project;
        private Dictionary<string, BHoMObject> m_Data;
        private int m_FreeNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        public ObjectFactory(Project project)
        {
            m_Project = project;
            m_Data = new Dictionary<string, BHoMObject>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="items"></param>
        public ObjectFactory(Project project, List<BHoMObject> items)
        {
            m_Project = project;
            m_Data = new Dictionary<string, BHoMObject>();
            m_UniqueByNumber = true;
            for (int i = 0; i < items.Count; i++)
            {
                m_Data.Add(items[i].Number.ToString(), items[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObjectFactory ForceUniqueByNumber()
        {
            if (!m_UniqueByNumber)
            {
                Dictionary<string, BHoMObject> newDictionary = new Dictionary<string, BHoMObject>();
                foreach (BHoMObject value in m_Data.Values)
                {
                    newDictionary.Add(value.Number.ToString(), value);
                }

                m_Data = newDictionary;
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObjectFactory ForceUniqueByName()
        {
            if (m_UniqueByNumber)
            {
                Dictionary<string, BHoMObject> newDictionary = new Dictionary<string, BHoMObject>();
                foreach (BHoMObject value in m_Data.Values)
                {
                    newDictionary.Add(value.Name, value);
                }

                m_Data = newDictionary;
            }
            return this;
        }
        //public void Clear()
        //{
        //    foreach (int i = 0; i < m_Data.Count; i++)
        //    {               
        //        m_Project.RemoveObject(m_Data[i].BHoM_Guid);              
        //    }
        //    m_Data.Clear();
        //}

        //public BHoMObject Get(int number)
        //{
        //    return m_Data.First(o => o.Number == number);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BHoMObject this[int key]
        {
            get
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BHoMObject this[string key]
        {
            get
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                return result;
            }
            set
            {
                BHoMObject result = null;
                m_Data.TryGetValue(key.ToString(), out result);
                result = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsName(string name)
        {
            BHoMObject obj = null;
            return m_Data.Count == 0 ? false : m_Data.TryGetValue(name.ToString(), out obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool ContainsNumber(int number)
        {
            BHoMObject obj = null;
            return m_Data.Count == 0 ? false : m_Data.TryGetValue(number.ToString(), out obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected void Add(BHoMObject obj)
        {
            m_Data.Add(obj.Number.ToString(), obj);
            m_Project.AddObject(obj);
            m_FreeNumber = Math.Max(obj.Number, m_FreeNumber) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int FreeNumber()
        {
            if (m_FreeNumber == 0)
            {
                m_FreeNumber = m_Data.Count == 0 ? 1 : m_Data.Values.Max(o => o.Number) + 1;
            }
            return m_FreeNumber;
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
