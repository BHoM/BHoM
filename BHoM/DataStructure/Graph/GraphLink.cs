using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.DataStructure
{
    public class GraphLink<T>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Weight { get; set; } = 1.0;

        public GraphNode<T> StartNode { get; set; } = new GraphNode<T>();

        public GraphNode<T> EndNode { get; set; } = new GraphNode<T>();


        /***************************************************/
    }
}
