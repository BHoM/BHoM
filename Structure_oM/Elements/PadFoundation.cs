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
    [Description("2D element representing a pad foundation for structural analysis. The PadFoundation is a planar surface object defined by edges and an ISurfaceProperty.")]
    public class PadFoundation : BHoMObject, IFoundation, IAreaElement, IElement2D
    {
        [Description("The edges used to define the outline of the pad at the top of the foundation.")]
        public virtual List<Edge> TopOutline { get; set; }

        [Description("Defines the thickness property and material of the PadFoundation.")]
        public virtual ISurfaceProperty Property { get; set; } = null;

        [Angle]
        [Description("Defines the angle that the local x and y axes are rotated around the normal (i.e. local z) of the Panel.\n" +
             "The normal of the Panel is determined by the right hand curl rule dictated by the order of the edge list.\n" +
             "Local x is found by projecting the global X to the plane of the Panel and is then rotated with the OrientationAngle, " +
             "except for the case when the Normal is parallel with the global X. " +
             "For this case the local y is instead found by projecting global Y to the plane of the Panel and is then rotated with the OrientationAngle.\n" +
             "The remaining local axis is determined by the right hand rule.")]
        public virtual double OrientationAngle { get; set; } = 0;

    }
}
