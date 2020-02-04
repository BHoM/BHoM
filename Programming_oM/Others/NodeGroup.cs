using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class NodeGroup : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; set; } = "";

        public List<Guid> NodeIds { get; set; } = new List<Guid>();

        public List<NodeGroup> InternalGroups { get; set; } = new List<NodeGroup>();


        /***************************************************/
    }
}
