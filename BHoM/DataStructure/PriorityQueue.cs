using System;
using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class PriorityQueue<T> : IDataStructure where T : IComparable<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<T> Data { get; set; } = new List<T>();

        /***************************************************/
    }

}

