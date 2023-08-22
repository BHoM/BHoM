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
    [Description("A composite object representing a pile foundation. This object contains a pile cap and a pile group which can be used for structural analysis.")]
    public class PileFoundation : BHoMObject, IFoundation, IElement2D, IElementM
    {
        [Description("The pile cap defined as a PadFoundation.")]
        public virtual PadFoundation PileCap { get; set; }

        [Description("One or more PileGroup objects used to define sets of piles (grouped by matching lengths and section.")]
        public virtual List<PileGroup> PileGroups { get; set; }
    }
}
