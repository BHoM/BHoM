using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    public class RigidLink : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Node MasterNode { get; set; } = new Node();

        public List<Node> SlaveNodes { get; set; } = new List<Node>();

        public LinkConstraint Constraint { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RigidLink() {}

        /***************************************************/

        public RigidLink(Node masterNode, IEnumerable<Node> slaveNodes, LinkConstraint constriant = null)
        {
            MasterNode = masterNode;
            SlaveNodes = slaveNodes.ToList();
        }


    }
}
