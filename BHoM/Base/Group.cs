using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base
{
    public interface IGroup : IBase
    {
        IEnumerable<BHoMObject> Objects { get; }
        Type ObjectType { get; }

        Group<T> Cast<T>() where T : IBase;

    }

    public class Group<T>: BHoMObject, IEnumerable<T>, IGroup where T : IBase
    {
        public Group()
        {
            Data = new List<T>();
        }

        public Group(List<T> list)
        {
            Data = list;
        }

        public Group(string name, List<T> list)
        {
            Name = name;
            Data = list;
        }

        public List<T> Data { get; set; }


        public IEnumerable<BHoMObject> Objects
        {
            get
            {
                return Data.Cast<BHoMObject>();
            }
        }

        public Type ObjectType
        {
            get
            {
                return typeof(T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator List<T>(Group<T> group)
        {
            return group.Data;
        }

        public static implicit operator Group<T>(List<T> list)
        {
            return new Group<T>(list);
        }

        public override string ToString()
        {
            return Name + " Group of " + ObjectType + ". Containing " +Data.Count+ " items"; 
        }

        public Group<T1> Cast<T1>() where T1 : IBase
        {
            return new Group<T1>(Data.Cast<T1>().ToList());            
        }
    }
}
