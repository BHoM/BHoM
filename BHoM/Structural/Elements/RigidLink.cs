using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Structural.Elements
{
    public class RigidLink : BHoMObject
    {
        Node m_masterNode;
        List<Node> m_slaveNodes;

        public RigidLink()
        {
            m_slaveNodes = new List<Node>();
        }

        public RigidLink(Node masterNode, IEnumerable<Node> slaveNodes)
        {
            m_masterNode = masterNode;
            m_slaveNodes = slaveNodes.ToList();
        }

        public Node MasterNode
        {
            get { return m_masterNode; }
            set { m_masterNode = value; }
        }

        public List<Node> SlaveNodes
        {
            get { return m_slaveNodes; }
            set { m_slaveNodes = value; }
        }
    }
}
