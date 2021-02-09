using System;
using BH.oM.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    [Description("A geometrical object that is the representation of another object.")]
    public class GeometricalRepresentation : IRepresentation
    {
        [Description("A geometry (or many geometry objects collected into a single `CompositeGeometry` object) that is the representation of another object." +
            "Examples: for a Point, this could be a Sphere. For a Vector, this could be a CompositeGeometry containing multiple lines for arrow head and stem." +
            "For a Beam, this could be an extrusion of the cross section along its centreline.")]
        public virtual IGeometry Geometry { get; set; }

        [Description("Colour information applicable to the Geometry.")]
        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);//BHoM pink!

    }
}
