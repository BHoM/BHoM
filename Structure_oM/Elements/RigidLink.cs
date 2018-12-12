using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Structure.Properties.Constraint;

namespace BH.oM.Structure.Elements
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
    }
}
