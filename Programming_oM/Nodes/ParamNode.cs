using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class ParamNode : BHoMObject, INode
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; set; } = "";

        public List<ReceiverParam> Inputs { get; set; } = new List<ReceiverParam>();

        public List<DataParam> Outputs { get; set; } = new List<DataParam>();

        public bool IsInline { get; set; } = true;

        public bool IsDeclaration { get; set; } = false;

        /***************************************************/
    }
}
