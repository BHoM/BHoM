using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class ClusterContent : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<INode> InternalNodes { get; set; } = new List<INode>();

        public List<NodeGroup> NodeGroups { get; set; } = new List<NodeGroup>();

        public List<DataParam> Inputs { get; set; } = new List<DataParam>();

        public List<ReceiverParam> Outputs { get; set; } = new List<ReceiverParam>();

        /***************************************************/
    }
}
