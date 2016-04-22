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

        public GraphNode() { }

        public GraphNode(T value)
        {
            Value = value;
        }

        
    }
}
