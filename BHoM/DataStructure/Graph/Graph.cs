using System.Collections.Generic;

namespace BH.oM.DataStructure
{
    public class Graph<T> : IDataStructure
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<GraphNode<T>> Nodes = new List<GraphNode<T>>();

        public List<GraphLink<T>> Links = new List<GraphLink<T>>();


        /***************************************************/
    }
}
