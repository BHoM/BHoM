using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class Graph<T> : IDataStructure
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<GraphNode<T>> Nodes { get; set; } = new List<GraphNode<T>>();

        public List<GraphLink<T>> Links { get; set; } = new List<GraphLink<T>>();


        /***************************************************/
    }
}
