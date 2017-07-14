using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public class BHoMGroup : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<BHoMObject> Elements { get; set; } = new List<BHoMObject>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BHoMGroup() { }

        /***************************************************/

        public BHoMGroup(IEnumerable<BHoMObject> elements)
        {
            Elements = elements.ToList();
        }
    }
}



//        IEnumerable<BHoMObject> Objects { get; }
//        Type ObjectType { get; }

//        BHoMList<T> Cast<T>() where T : IObject;
//        int Count { get; }
//    }

//    public class BHoMList<T>: BHoMObject, IEnumerable<T>, IBHoMList where T : IObject
//    {
//        public BHoMList()
//        {
//            Data = new List<T>();
//        }

//        public BHoMList(List<T> list)
//        {
//            Data = list;
//        }

//        public BHoMList(string name, List<T> list)
//        {
//            Name = name;
//            Data = list;
//        }

//        public List<T> Data { get; set; }


//        public IEnumerable<BHoMObject> Objects
//        {
//            get
//            {
//                return Data.Cast<BHoMObject>();
//            }
//        }

//        public Type ObjectType
//        {
//            get
//            {
//                return typeof(T);
//            }
//        }

//        public T this[int i]
//        {
//            get
//            {
//                return Data[i];
//            }
//        }


//        public int Count
//        {
//            get
//            {
//                return Data.Count;
//            }
//        }

//        public IEnumerator<T> GetEnumerator()
//        {
//            return Data.GetEnumerator();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

//        public static implicit operator List<T>(BHoMList<T> group)
//        {
//            return group.Data;
//        }

//        public static implicit operator BHoMList<T>(List<T> list)
//        {
//            return new BHoMList<T>(list);
//        }

//        public override string ToString()
//        {
//            return Name + " Group of " + ObjectType + ". Containing " +Data.Count+ " items"; 
//        }

//        public BHoMList<T1> Cast<T1>() where T1 : IObject
//        {
//            return new BHoMList<T1>(Data.Cast<T1>().ToList());            
//        }
//    }
//}
