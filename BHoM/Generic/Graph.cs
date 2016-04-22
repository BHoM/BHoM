using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Generic
{
    public class Graph<T>
    {
        private List<GraphNode<T>> nodes;

        public Graph() { }

        public void CleanLinkWeights(double weight = 0)
        {
            foreach( GraphNode<T> node in nodes)
            {
                foreach (GraphLink<T> link in node.Links)
                    link.Weight = weight;
            }
        }


        /**********************************/
        /**** Manipulation using Nodes ****/
        /**********************************/

        public void AddNode(GraphNode<T> node)
        {
            nodes.Add(node);
        }

        public void AddDirectedLink(GraphNode<T> from, GraphNode<T> to, double weight = 0)
        {
            from.Links.Add(new GraphLink<T>(from, to, weight));
        }

        public void AddUndirectedLink(GraphNode<T> node1, GraphNode<T> node2, double weight = 0)
        {
            node1.Links.Add(new GraphLink<T>(node1, node2, weight));
            node2.Links.Add(new GraphLink<T>(node2, node1, weight));
        }

        public bool RemoveNode(GraphNode<T> node)
        {
            foreach (GraphLink<T> link in node.Links)
                link.EndNode.Links.Remove(link);

            return nodes.Remove(node);
        }

        public bool RemoveDirectedLink(GraphNode<T> from, GraphNode<T> to)
        {
            return from.Links.RemoveAll(x => x.EndNode.Equals(to)) > 0;
        }

        public bool RemoveUndirectedLink(GraphNode<T> node1, GraphNode<T> node2)
        {
            return node1.Links.RemoveAll(x => x.EndNode.Equals(node2)) > 0
                && node2.Links.RemoveAll(x => x.EndNode.Equals(node1)) > 0;
        }


        /**************************************/
        /**** Manipulation using Node Data ****/
        /**************************************/

        public GraphNode<T> AddNode(T value)
        {
            GraphNode<T> newNode = new GraphNode<T>(value);
            nodes.Add(newNode);
            return newNode;
        }

        public void AddDirectedLink(T from, T to, double weight = 0)
        {
            AddDirectedLink(nodes.Find(x => x.Value.Equals(from)), nodes.Find(x => x.Value.Equals(to)), weight);
        }

        public void AddUndirectedLink(T node1, T node2, double weight = 0)
        {
            AddDirectedLink(nodes.Find(x => x.Value.Equals(node1)), nodes.Find(x => x.Value.Equals(node2)), weight);
        }

        public bool RemoveNode(T value)
        {
            return RemoveNode(nodes.Find(x => x.Value.Equals(value)));
        }

        public bool RemoveDirectedLink(T from, T to)
        {
            return RemoveDirectedLink(nodes.Find(x => x.Value.Equals(from)), nodes.Find(x => x.Value.Equals(to)));
        }

        public bool RemoveUndirectedLink(T node1, T node2)
        {
            return RemoveUndirectedLink(nodes.Find(x => x.Value.Equals(node1)), nodes.Find(x => x.Value.Equals(node2)));
        }

    }
}
