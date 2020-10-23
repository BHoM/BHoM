using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class Relation : BHoMObject, IRelation
    {
        [Description("Reference Guid to source entity")]
        public virtual Guid Source { get; set; } = Guid.Empty;

        [Description("Reference Guid to target entity")]
        public virtual Guid Target { get; set; } = Guid.Empty;

        [Description("This relation's Subgraph")]
        public virtual Graph Subgraph { get; set; } = new Graph();

        [Description("Weight of the relation")]
        public virtual double Weight { get; set; } = 1.0;

    }
    

}
