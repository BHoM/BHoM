using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Generic
{
    public class GraphLink<T>
    {
        public double Weight { get; set; }
        public GraphNode<T> StartNode { get; private set; }
        public GraphNode<T> EndNode { get; private set; }
    
        public GraphLink(GraphNode<T> from, GraphNode<T> to, double weight) 
        {
            StartNode = from;
            EndNode = to;
            Weight = weight;
        }

        public GraphNode<T> OppositeNode(GraphNode<T> node)
        {
            if (node == StartNode)
                return EndNode;
            else if (node == EndNode)
                return StartNode;
            else
                return null;
        }

    }
}
