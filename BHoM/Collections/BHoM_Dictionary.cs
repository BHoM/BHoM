using System.Collections.Generic;
using System;

namespace BHoM.Collections
{
    /// <summary>
    /// BHoM dictionary using system dictionary with additional functionality. 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>

    public class Dictionary<TKey, TValue> 
    {
        private System.Collections.Generic.Dictionary<TKey, TValue> internalDict = new System.Collections.Generic.Dictionary<TKey, TValue>();

        /// <summary></summary>
        public string Name { get; set; }

        /// <summary></summary>
        public void Add(TKey key, TValue value)
        {
            internalDict.Add(key, value);
        }

        /// <summary></summary>
        public bool ContainsKey(TKey key)
        {
            return internalDict.ContainsKey(key);
        }

        /// <summary></summary>
        public ICollection<TKey> Keys
        {
            get { return internalDict.Keys; }
        }

        /// <summary></summary>
        public bool Remove(TKey key)
        {
            return internalDict.Remove(key);
        }

        /// <summary></summary>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return internalDict.TryGetValue(key, out value);
        }

        /// <summary></summary>
        public ICollection<TValue> Values
        {
            get { return internalDict.Values; }
        }

        /// <summary></summary>
        public TValue this[TKey key]
        {
            get
            {
                return internalDict[key];
            }
            set
            {
                internalDict[key] = value;
            }
        }


        #region ICollection<KeyValuePair<int,T>> Members

        /// <summary></summary>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            internalDict.Add(item.Key, item.Value);
        }

        /// <summary></summary>
        public void Clear()
        {
            internalDict.Clear();
        }

        /// <summary></summary>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (internalDict.ContainsKey(item.Key) && internalDict.ContainsValue(item.Value));
        }

        private void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            //Could be done but you prolly could figure this out yourself;
            throw new Exception("do not use");
        }

        /// <summary></summary>
        public int Count
        {
            get { return internalDict.Count; }
        }


        private bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary></summary>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary></summary>
        public List<TKey> KeyList()
        {
            List<TKey> keyList = new List<TKey>();
            foreach(TKey key in this.Keys)
            {
                keyList.Add(key);
            }
            return keyList;
        }


        #region IEnumerable<KeyValuePair<int,T>> Members

        /// <summary></summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return internalDict.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dictionary"></param>
        public static explicit operator Dictionary<TKey, TValue>(System.Collections.Generic.Dictionary<TKey, TValue> Dictionary)
        {
            Dictionary<TKey, TValue> userDictionary = new Dictionary<TKey, TValue>();
            foreach (TKey tKey in Dictionary.Keys)
            {
                userDictionary.Add(tKey, Dictionary[tKey]);
            }
            return userDictionary;
        }
    }
}