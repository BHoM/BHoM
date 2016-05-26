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

        public Graph()
        {
            nodes = new List<GraphNode<T>>();
        }


        /**********************************/
        /**** Manipulation using Nodes ****/
        /**********************************/

        public GraphNode<T> ClosestNode(T value, Func<T,T,double> nodeDist)
        {
            double minDist = 1e10;
            GraphNode<T> bestNode = null;

            foreach (GraphNode<T> node in nodes)
            {
                double dist = nodeDist(value, node.Value);
                if (dist < minDist)
                {
                    minDist = dist;
                    bestNode = node;
                }
            }

            return bestNode;
        }

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

        public bool AddDirectedLink(T from, T to, double weight = 0)
        {
            GraphNode<T> n1 = nodes.Find(x => x.Value.Equals(from));
            GraphNode<T> n2 = nodes.Find(x => x.Value.Equals(to));
            if (n1 != null && n2 != null)
            {
                AddDirectedLink(n1, n2, weight);
                return true;
            }
            else
                return false;  
        }

        public bool AddUndirectedLink(T node1, T node2, double weight = 0)
        {
            GraphNode<T> n1 = nodes.Find(x => x.Value.Equals(node1));
            GraphNode<T> n2 = nodes.Find(x => x.Value.Equals(node2));
            if (n1 != null && n2 != null)
            { 
                AddDirectedLink(n1, n2, weight);
                return true;
            }
            else
                return false;
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> node = nodes.Find(x => x.Value.Equals(value));
            if (node != null)
                return RemoveNode(node);
            else
                return false;
        }

        public bool RemoveDirectedLink(T from, T to)
        {
            GraphNode<T> n1 = nodes.Find(x => x.Value.Equals(from));
            GraphNode<T> n2 = nodes.Find(x => x.Value.Equals(to));
            if (n1 != null && n2 != null)
                return RemoveDirectedLink(n1, n2);
            else
                return false;
        }

        public bool RemoveUndirectedLink(T node1, T node2)
        {
            GraphNode<T> n1 = nodes.Find(x => x.Value.Equals(node1));
            GraphNode<T> n2 = nodes.Find(x => x.Value.Equals(node2));
            if (n1 != null && n2 != null)
                return RemoveUndirectedLink(n1, n2);
            else
                return false;
        }

    }
}
