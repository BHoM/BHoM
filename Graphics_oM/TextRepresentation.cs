using BH.oM.Geometry.CoordinateSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class TextRepresentation : IRepresentation
    {
        public virtual string Text { get; set; } = "";

        public virtual Cartesian Cartesian { get; set; } = new Cartesian();

        public virtual FontConfig FontConfig { get; set; } = new FontConfig();
    }
}
