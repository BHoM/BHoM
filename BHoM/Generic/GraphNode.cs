using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Generic
{
    public class GraphNode<T>
    {
        public T Value { get; set; }
        new public List<GraphLink<T>> Links { get; private set; }

        public GraphNode()
        {
            Links = new List<GraphLink<T>>();
        }

        public GraphNode(T value)
        {
            Value = value;
            Links = new List<GraphLink<T>>();
        }

        public List<GraphNode<T>> Neighbours
        {
            get
            {
                List<GraphNode<T>> neighbours = new List<GraphNode<T>>();
                foreach (GraphLink<T> link in Links)
                    neighbours.Add(link.EndNode);
                return neighbours;
            }
        }
    }
}
