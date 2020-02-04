using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Programming
{
    public class LoopNode : BHoMObject, INode, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<INode> InternalNodes { get; } = new List<INode>();

        public string Description { get; set; } = "";

        public List<DataParam> Outputs { get; set; } = new List<DataParam>();

        public List<ReceiverParam> Inputs { get; set; } = new List<ReceiverParam>();

        public bool IsInline { get; set; } = false;

        public bool IsDeclaration { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LoopNode(List<INode> content, string description = "")
        {
            List<ReceiverParam> receivers = content.SelectMany(n => n.Inputs.Where(x => x.SourceId != Guid.Empty)).ToList();
            List<DataParam> emiters = content.SelectMany(n => n.Outputs.Where(x => x.TargetIds.Count > 0)).ToList();

            List<Guid> receiverIds = receivers.Select(x => x.BHoM_Guid).ToList();
            List<Guid> emiterIds = emiters.Select(x => x.BHoM_Guid).ToList();

            Outputs = emiters.Where(x => x.TargetIds.Intersect(receiverIds).Count() == 0)
                                        .Select(x =>
                                        {
                                            DataParam copy = x.GetShallowClone() as DataParam;
                                            copy.ParentId = this.BHoM_Guid;
                                            return copy;
                                        }).ToList();

            Inputs = receivers.Where(x => !emiterIds.Contains(x.SourceId))
                                        .Select(x =>
                                        {
                                            ReceiverParam copy = x.GetShallowClone() as ReceiverParam;
                                            copy.ParentId = this.BHoM_Guid;
                                            return copy;
                                        }).ToList();

            InternalNodes = content;
            Description = description;
        }

        /***************************************************/
    }
}
