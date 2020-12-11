using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class GeometricRepresentation : IRepresentation
    {
        public virtual IGeometry Geometry { get; set; } = null;

        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);

        public virtual int LineWeight { get; set; } = 2;
    }
}
