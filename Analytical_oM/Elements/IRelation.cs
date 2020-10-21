using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public interface IRelation : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Reference Guid to source entity")]
        Guid Source { get; set; }

        [Description("Reference Guid to target entity")]
        Guid Target { get; set; }

        Graph Subgraph { get; set; }

        double Weight { get; set; }
        /***************************************************/
    }


}
