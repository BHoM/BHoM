using System;
using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class VennDiagram<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Tuple<T,T>> Intersection { get; set; } = new List<Tuple<T,T>>();

        public List<T> OnlySet1 { get; set; } = new List<T>();

        public List<T> OnlySet2 { get; set; } = new List<T>();


        /***************************************************/
    }
}
