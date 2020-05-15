using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using System.ComponentModel;

namespace BH.oM.Structure.Elements
{
    public class SteelConnection : BHoMObject
    {
        [Description("Framing Elements Connected Together by Connection")]
        public virtual List<FramingElement> ConnectingElementIds { get; set; } = null;

        [Description("Plates in Connection")]
        public virtual List<Panel> Plates { get; set; } = null;

        [Description("Bolts in Connection")]
        public virtual List<Bolt> Bolts { get; set; } = null;

        [Description("Welds in Connection")]
        public virtual List<Weld> Welds { get; set; } = null;

        [Description("Cuts in Connection")]
        public virtual List<Cut> Cuts { get; set; } = null;

    }

}