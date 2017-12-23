using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.DataStructure
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<T> Data { get; set; } = new List<T>();

        /***************************************************/
    }

}

