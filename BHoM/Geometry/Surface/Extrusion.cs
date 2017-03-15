using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Extrusion : Brep
    {
        public bool Capped { get; set; }
        public Curve Curve { get; set; }
        public Vector Direction { get; set; }
        public Extrusion() { }
        public Extrusion(Curve curve, Vector direction, bool capped)
        {
            Curve = curve;
            Direction = direction;
            Capped = curve.IsClosed() && capped;
        }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Extrusion;
            }
        }

     
        public override BHoMGeometry Duplicate()
        {
            Extrusion dup = base.Duplicate() as Extrusion;
            dup.Curve = Curve.DuplicateCurve();
            dup.Direction = Direction.DuplicateVector();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            BoundingBox box = Curve.Bounds();
            return box.Add(new List<BHoMGeometry>() { box.Max + Direction, box.Min + Direction });
        }
    }
}
