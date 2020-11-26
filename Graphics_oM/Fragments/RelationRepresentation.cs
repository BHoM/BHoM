using BH.oM.Geometry;
using BH.oM.Graphics.Fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Fragments
{
    class RelationRepresentation: IRepresentationFragment
    {
        public virtual List<ICurve> Curves { get; set; } = new List<ICurve>();

        public virtual string Text { get; set; } = "";

        public virtual Point TextPosition { get; set; } = new Point();

        public virtual Vector TextDirection { get; set; } = new Vector();
    }
}
