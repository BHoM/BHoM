using BH.oM.Geometry;
using BH.oM.Graphics.Fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Fragments
{
    public class GroupRepresentation : IRepresentationFragment
    {
        public virtual ICurve Boundary { get; set; }

        public virtual string Text { get; set; } = "";

        public virtual Point TextPosition { get; set; } = new Point();

        public virtual Vector TextDirection { get; set; } = new Vector();

        public virtual System.Drawing.Color Colour { get; set; } = new System.Drawing.Color();
    }
}
