using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Base
{
    public class Group<T> : BHoMObject
    {

        public Group()
        {
            Data = new List<T>();
        }

        public Group(List<T> list)
        {
            Data = list;
        }

        public List<T> Data { get; set; }

        public static implicit operator List<T>(Group<T> group)
        {
            return group.Data;
        }

        public static implicit operator Group<T>(List<T> list)
        {
            return new Group<T>(list);
        }
    }
}
