using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Dimensional;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;
using BH.oM.Spatial.Layouts;

namespace BH.oM.Structure.Elements
{
    [Description("A composite object representing a pile foundation. This object contains a pile cap and list of piles which can be used for structural analysis.")]
    public class PileFoundation : BHoMObject, IFoundation, IElementM
    {
        [Description("The pile cap with an outline containing all of the Piles.")]
        public virtual PadFoundation PileCap { get; set; }

        [Description("A list of Piles contained within the extents of the PileCap.")]
        public virtual List<Pile> Piles { get; set; }
    }
}
