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
using BH.oM.Spatial.ShapeProfiles;

namespace BH.oM.Structure.Elements
{
    [Description("2D element for structural analysis. The PadFoundation is a planar surface object defined by an IProfile and a ISurfaceProperty.")]
    public class PadFoundation : BHoMObject, IFoundation, IAreaElement, IElement2D
    {
        [Description("The profile used to define the outline of the pad.")]
        public virtual IProfile TopSurface { get; set; }

        [Description("Defines the thickness property and material of the PadFoundation.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        [Description("Local x, y, and z axes of the PadFoundation as a vector Basis. Defaults to null which is interpretated to defaults when pushed to software and world axes in BHoM.")]
        public virtual Basis Orientation { get; set; } = null;

    }
}
