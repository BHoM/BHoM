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
    [Description("PileFoundation is a composite object consisting of a pile cap and a group of piles.")]
    public class PileFoundation : BHoMObject, IFoundation, IElementM
    {
        [Description("The pile cap defined as a PadFoundation.")]
        public virtual PadFoundation PileCap { get; set; }

        [Description("Pile Layout")]
        public virtual List<PileGroup> PileGroups { get; set; }
    }
}
