using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Geometry
{
    public class Polyline : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Point> ControlPoints { get; set; } = new List<Point>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Polyline() { }

        /***************************************************/

        public Polyline(IEnumerable<Point> points)
        {
            ControlPoints = points.ToList();
        }

        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Polyline;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            if (ControlPoints.Count == 0) return null;

            Point pt = ControlPoints[0];
            double minX = pt.X;
            double minY = pt.Y;
            double minZ = pt.Z;
            double maxX = minX;
            double maxY = minY;
            double maxZ = minZ;

            for (int i = ControlPoints.Count - 1; i > 0; i--)
            {
                pt = ControlPoints[i];
                if (pt.X < minX) minX = pt.X;
                if (pt.Y < minY) minY = pt.Y;
                if (pt.Z < minZ) minZ = pt.Z;
                if (pt.X > maxX) maxX = pt.X;
                if (pt.Y > maxY) maxY = pt.Y;
                if (pt.Z > maxZ) maxZ = pt.Z;
            }

            return new BoundingBox(new Point(minX, minY, minZ), new Point(maxX, maxY, maxZ));
        }

        /***************************************************/

        public object Clone()
        {
            return new Polyline(ControlPoints.Select(x => x.Clone() as Point));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated( Vector t)
        {
            return new Polyline(ControlPoints.Select(x => x + t));
        }


        /***************************************************/
        /**** ICurve Interface                          ****/
        /***************************************************/

        public Point GetStart()
        {
            return ControlPoints.Count > 0 ? ControlPoints.First() : null;
        }

        /***************************************************/

        public Point GetEnd()
        {
            return ControlPoints.Count > 0 ? ControlPoints.Last() : null;
        }

        /***************************************************/

        public Vector GetStartDir()
        {
            if (ControlPoints.Count < 2) return null;

            Point pt1 = ControlPoints[0];
            Point pt2 = ControlPoints[1];

            return new Vector(pt2.X - pt1.X, pt2.Y - pt1.Y, pt2.Z - pt1.Z).Normalise();
        }

        /***************************************************/

        public Vector GetEndDir()
        {
            if (ControlPoints.Count < 2) return null;

            Point pt1 = ControlPoints[ControlPoints.Count - 2];
            Point pt2 = ControlPoints[ControlPoints.Count - 1];

            return new Vector(pt2.X - pt1.X, pt2.Y - pt1.Y, pt2.Z - pt1.Z).Normalise();
        }

        /***************************************************/

        public bool IsClosed()
        {
            return ControlPoints.Count > 0 ? ControlPoints.Last() == ControlPoints.First() : false;
        }



        //public new double[] ControlPointVector
        //{
        //    get
        //    {
        //        return base.ControlPointVector;
        //    }
        //    set
        //    {
        //        m_ControlPoints = value;
        //    }
        //}


        //public override List<Curve> Explode()
        //{
        //    List<Curve> lineSegments = new List<Curve>();
        //    lineSegments.Add(new Line(this[0], this[1]));
        //    for (int i = 1; i < PointCount - 1; i++)
        //    {
        //        lineSegments.Add(new Line(lineSegments[i - 1].EndPoint, this[i + 1]));
        //    }
        //    return lineSegments;
        //}
    }
}
