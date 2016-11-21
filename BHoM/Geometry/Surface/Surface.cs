using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Surface object
    /// </summary>
    [Serializable]
    public class Surface : Brep
    {
        private double[] m_ControlPoints;
        private double[] m_Weights;
        private double[][] m_Knots;
        private int m_Order;
        private int m_Dimensions;
        private int m_Columns;
        protected int[] m_MaxMin;

        public override BoundingBox Bounds()
        {
            return new BoundingBox(Max, Min);          
        }

        internal Surface() { }

        private void CreateFrom4Points(Point p1, Point p2, Point p3, Point p4)
        {
            List<Curve> edges = new List<Curve>();
            edges.Add(new Line(p1, p2));
            edges.Add(new Line(p2, p3));
            edges.Add(new Line(p3, p4));
            edges.Add(new Line(p4, p1));
            m_NakedEdges = new Group<Curve>(Curve.Join(edges));
            m_Dimensions = 3;

            Curve c = m_NakedEdges[0];

            m_Columns = 2;
            m_ControlPoints = new double[4 * (m_Dimensions + 1)];

            double[] row1 = Common.Utils.SubArray<double>(c.ControlPointVector, 0, (m_Dimensions + 1) * 2);
            double[] row2 = Common.Utils.Reverse<double>(Common.Utils.SubArray<double>(c.ControlPointVector, (m_Dimensions + 1) * 2, (m_Dimensions + 1) * 2), m_Dimensions + 1);

            m_ControlPoints = Common.Utils.Merge<double>(row1, row2);

            m_Weights = new double[] { 1, 1, 1, 1 };

            m_Knots = new double[2][];
            m_Knots[0] = new double[] { 0, 0, 1, 1 };
            m_Knots[1] = new double[] { 0, 0, 1, 1 };
        }


        internal virtual Point Max
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = VectorUtils.MaxMin(m_ControlPoints, m_Dimensions + 1);
                }
                return new Point(m_ControlPoints[m_MaxMin[0]], m_ControlPoints[m_MaxMin[1]], m_ControlPoints[m_MaxMin[2]]);
            }
        }

        internal virtual Point Min
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = VectorUtils.MaxMin(m_ControlPoints, m_Dimensions + 1);
                }
                return new Point(m_ControlPoints[m_MaxMin[3]], m_ControlPoints[m_MaxMin[4]], m_ControlPoints[m_MaxMin[5]]);
            }
        }

        public override void Transform(Transform t)
        {
            base.Transform(t);
            m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            Update();
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            m_ControlPoints = VectorUtils.Add(m_ControlPoints, v);
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            m_ControlPoints = VectorUtils.Add(VectorUtils.Multiply(p.ProjectionVectors(m_ControlPoints), 2), m_ControlPoints);
            Update();
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            Update();
            m_ControlPoints = VectorUtils.Add(p.ProjectionVectors(m_ControlPoints), m_ControlPoints);
        }

        public override void Update()
        {
            m_MaxMin = null;
        }

        public Surface DuplicateSurface()
        {
            Surface s = (Surface)Activator.CreateInstance(this.GetType(), true);
            s.m_ControlPoints = Common.Utils.Copy<double>(m_ControlPoints);
            s.m_Columns = m_Columns;
            s.m_Dimensions = m_Dimensions;
            s.m_Weights = Common.Utils.Copy<double>(m_Weights);
            s.m_Knots = new double[m_Knots.Length][];

            for (int i =0; i < m_Knots.Length; i++)
            {
                s.m_Knots[i] = Common.Utils.Copy<double>(m_Knots[i]);
            }
            s.m_Order = m_Order;

            s.m_NakedEdges = m_NakedEdges.DuplicateGroup();
            return s;
        }


        public override GeometryBase Duplicate()
        {
            return DuplicateSurface();
        }

        #region Static Functions

        public static Surface CreateFromPoints(Point p1, Point p2, Point p3, Point p4)
        {
            Surface s = new Surface();
            s.CreateFrom4Points(p1, p2, p3, p4);
            return s;
        }

        public static Surface CreateFromBoundary(Curve boundary)
        {
            if (boundary.IsPlanar() && boundary.IsClosed())
            {
                Surface surface = new Surface();
                surface.m_NakedEdges = new Group<Curve>(new List<Curve>() { boundary });

                Curve xY = boundary.DuplicateCurve();
                Plane plane = null;
                xY.TryGetPlane(out plane);

                Point centre = xY.Bounds().Centre;
                Vector axis = plane.Normal;
                double angle = Vector.VectorAngle(Vector.ZAxis(), axis);

                Transform t1 = Geometry.Transform.Rotation(centre, axis, angle);
                Transform t2 = Geometry.Transform.Translation(Point.Origin - centre) * t1;

                xY.Transform(t2);
                Vector extents = xY.Bounds().Extents;

                Point p1 = new Point(extents.X, -extents.Y, 0);
                Point p2 = new Point(extents.X, extents.Y, 0);
                Point p3 = new Point(-extents.X, -extents.Y, 0);
                Point p4 = new Point(-extents.X, extents.Y, 0);

                surface.CreateFrom4Points(p1, p2, p3, p4);

                surface.Transform(t2.Inverse());
                surface.m_TrimCurves.Add(boundary);
                return surface;
            }
            return null;
        }

        public override string ToJSON()
        {
            string points = "\"Points\": [[ ";
            for (int i = 0; i < m_ControlPoints.Length - 1; i++)
            {
                if (i > 0 && (i + 1) % 4 == 0)
                {
                    points = points.Trim(',') + "],[";
                }
                else
                {
                    points += m_ControlPoints[i] + ",";
                }
            }
            points = points.Trim(',') + "]]";
            string uknots = "\"uknots\": " + Common.Utils.CollectionToString(m_Knots[0]);
            string vknots = "\"vknots\": " + Common.Utils.CollectionToString(m_Knots[1]);
            string weights = VectorUtils.MinValue(m_Weights) < 1 ? "\"Weights\": " + Common.Utils.CollectionToString(m_Weights) : "";
            string degree = "\"Degree\": " + (m_Order - 1);
            string trimmingCurves = "\"TrimmingCurves\": " + m_TrimCurves.ToJSON();
            return "{\"Primitive\": \"" + this.GetType().Name + "\"," + degree + "," + uknots + "," + vknots + (weights != "" ? "," : "") + weights + "," + trimmingCurves + "}";
        }
    
        #endregion
    }
}