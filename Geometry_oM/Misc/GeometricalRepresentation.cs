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
    public class GeometricalRepresentation : IGeometry
    {
        [Description("A geometry (or many geometry objects collected into a single `CompositeGeometry` object) that is the representation of another object.")]
        public virtual IGeometry Geometry { get; set; }
        [Description("Colour information (System.Color, or a Gradient, or anything interpretable as colour) applicable to the Geometry.")]
        public virtual object ColourInfo { get; set; }
    }
}
