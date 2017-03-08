using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Pipe : Brep
    {
        public double Radius { get; set; }
        public Curve Centreline { get; set; }
        public bool Capped { get; set; }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Pipe;
            }
        }

        public Pipe() { }
        public Pipe(Curve centreline, double radius)
        {
            Radius = radius;
            Centreline = centreline;
        }

        public override GeometryBase Duplicate()
        {
            Pipe dup = base.Duplicate() as Pipe;
            dup.Centreline = Centreline.DuplicateCurve();
            return dup;
        }

        public override BoundingBox Bounds()
        {
            BoundingBox box = Centreline.Bounds(); //Add bounds of curves at the base
            //return box.Add(new List<GeometryBase>() { box.Max + Direction, box.Min + Direction });
            return box;
        }
    }
}
