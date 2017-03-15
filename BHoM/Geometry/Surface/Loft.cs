using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public partial class Loft : Brep
    {
        public Group<Curve> Curves { get; set; }

        public Loft() { }
        public Loft(Group<Curve> curves)
        {
            Curves = curves;
        }
        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Loft;
            }
        }

        public override BHoMGeometry Duplicate()
        {
            Loft dup = base.Duplicate() as Loft;
            dup.Curves = Curves.DuplicateGroup();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            return Curves.Bounds();
        }
    }
}
