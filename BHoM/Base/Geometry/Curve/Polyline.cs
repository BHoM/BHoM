using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    public class Polyline : Curve
    {
        internal Polyline() { }

        public Polyline(List<Point> points) : base(points) { }

        public Polyline(List<double[]> pnts) : base(pnts) { }

        public Polyline(double[] pnts, int dimensions) : base(pnts, dimensions) { }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Polyline;
            }
        }

        public new double[] ControlPointVector
        {
            get
            {
                return base.ControlPointVector;
            }
            set
            {
                m_ControlPoints = value;
            }
        }


        public override List<Curve> Explode()
        {
            List<Curve> lineSegments = new List<Curve>();
            lineSegments.Add(new Line(this[0], this[1]));
            for (int i = 1; i < PointCount - 1; i++)
            {
                lineSegments.Add(new Line(lineSegments[i - 1].EndPoint, this[i + 1]));
            }
            return lineSegments;
        }
    }
}
