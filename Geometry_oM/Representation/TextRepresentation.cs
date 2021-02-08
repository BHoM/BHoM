using BH.oM.Base;
using BH.oM.Geometry.CoordinateSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class TextRepresentation : IRepresentation
    {
        public virtual string Text { get; set; } = "";

        public virtual Cartesian Cartesian { get; set; } = new Cartesian();

        public virtual double Height { get; set; } = 1;

        public virtual string Font { get; set; } = "Arial";

        public virtual Color Colour { get; set; } = Color.FromArgb(80, 255, 41, 105);
    }
}
