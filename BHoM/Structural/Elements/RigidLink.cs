using System.Collections.Generic;
using System.Linq;
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
    }
}
