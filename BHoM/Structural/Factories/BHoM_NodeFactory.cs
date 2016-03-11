using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class NodeFactory : ObjectFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public NodeFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="nodes"></param>
        public NodeFactory(Project p, List<BHoM.Global.BHoMObject> nodes) : base(p, nodes) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Node Create()
        {
            return new Node();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Node Create(int number, double x, double y, double z)
        {
            if (m_UniqueByNumber && this.ContainsNumber(number))
            {
                return this[number] as Node;
            }
            else
            {
                Node node = new Node(x, y, z, number);
                this.Add(node);
                return node;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Node Create(string name, double x, double y, double z)
        {
            if (!m_UniqueByNumber && this.ContainsName(name))
            {
                return this[name] as Node;
            }
            else
            {
                Node node = new Node(x, y, z, FreeNumber());
                node.Name = name;
                this.Add(node);
                return node;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public Node Create(double x, double y, double z)
        {
            Node node = new Node(x, y, z, FreeNumber());
            this.Add(node);
            return node;
        }
    }
}