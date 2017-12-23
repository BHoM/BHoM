using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.DataStructure
{
    public class Graph<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<GraphNode<T>> Nodes = new List<GraphNode<T>>();

        public List<GraphLink<T>> Links = new List<GraphLink<T>>();


        /***************************************************/
    }
}
