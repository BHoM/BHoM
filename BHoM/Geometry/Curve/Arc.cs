using System;
using BHoM.Global;
using BHoM.Common;
using System.Collections.Generic;
using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// Arc object
    /// </summary>
    public class Arc : Curve
    {
        double[] m_Centre;
        double m_Radius;

        internal Arc() { }

        /// <summary>
        /// Arc from 3 points
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="internalpoint"></param>
        public Arc(Point startpoint, Point endpoint, Point internalpoint)
        {
            m_ControlPoints = new double[12];
            Array.Copy(startpoint, m_ControlPoints, 4);
            Array.Copy(endpoint, 0, m_ControlPoints, 4 * 2, 4);
            Array.Copy(internalpoint, 0, m_ControlPoints, 4, 4);
            m_Dimensions = 3;
        }

        /// <summary>
        /// Construct an arc using start point, end point and base plane
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="plane"></param>
        public Arc(Point startpoint, Point endpoint, Plane plane)
        {
            double[] v1 = VectorUtils.Sub(startpoint, plane.Origin);
            double[] v2 = VectorUtils.Sub(endpoint, plane.Origin);

            double radius = VectorUtils.Length(v1);

            double[] localXAxis = Math.Abs(plane.Normal.Z) == 1 ? new double[] { plane.Normal.Z, 0, 0, 0 } : VectorUtils.CrossProduct(plane.Normal, new double[] { 0, 0, 1, 0 });
            double[] localYAxis = VectorUtils.CrossProduct(plane.Normal, localXAxis);

            double[] crossProduct = VectorUtils.Normalise(VectorUtils.CrossProduct(v1, v2));
            double multiplier1 = VectorUtils.DotProduct(v1, localYAxis) > 0 ? 1 : -1;
            double multiplier2 = VectorUtils.DotProduct(crossProduct, plane.Normal) > 0 ? 1 : -1;

            double startAngle = VectorUtils.Angle(localXAxis, v1) * multiplier1;
            double arcAngle = VectorUtils.Angle(v1, v2) * multiplier2;

            //double end = (endAngle - startAngle);

            Initialise(startAngle, startAngle + arcAngle, radius, plane);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startAngle"></param>
        /// <param name="endAngle"></param>
        /// <param name="radius"></param>
        /// <param name="plane"></param>
        public Arc(double startAngle, double endAngle, double radius, Plane plane)
        {
            Initialise(startAngle, endAngle, radius, plane);
        }

        private void Initialise(double startAngle, double endAngle, double radius, Plane plane)
        {
            m_ControlPoints = new double[12];
            m_Centre = plane.Origin;
            m_Dimensions = 3;

            double angle = startAngle;
            double increment = (endAngle - startAngle) / 2;
            int offset = 0;
            for (int i = 0; i < 3; i++)
            {
                m_ControlPoints[offset] = radius * Math.Cos(angle);
                m_ControlPoints[1 + offset] = radius * Math.Sin(angle);
                m_ControlPoints[2 + offset] = 0;
                m_ControlPoints[3 + offset] = 1;
                angle += increment;
                offset += m_Dimensions + 1;
            }
            double rotationAngle = Vector.VectorAngle(plane.Normal, Vector.ZAxis());
            if (rotationAngle > 0)
            {
                Vector rotationAxis = Vector.CrossProduct(plane.Normal, Vector.ZAxis());
                Transform t = Geometry.Transform.Rotation(Point.Origin, rotationAxis, rotationAngle);
                m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            }
            m_ControlPoints = VectorUtils.MultiplyMany(Geometry.Transform.Translation(plane.Origin - Point.Origin), m_ControlPoints);
        }

        public override void CreateNurbForm()
        {
            double[] P1 = Common.Utils.SubArray<double>(m_ControlPoints, 0, m_Dimensions + 1);
            double[] P2 = Common.Utils.SubArray<double>(m_ControlPoints, (m_Dimensions + 1) * 2, m_Dimensions + 1);

            double[] V1 = VectorUtils.Sub(P1, Centre);
            double[] V2 = VectorUtils.Sub(P2, Centre);

            double[] Normal = VectorUtils.CrossProduct(V1, V2);

            double[] T1 = VectorUtils.CrossProduct(V1, Normal);
            double[] T2 = VectorUtils.CrossProduct(V2, Normal);

            double[] cP2 = VectorUtils.Intersect(P1, T1, P2, T2);

            double w2 = Radius / VectorUtils.Length(VectorUtils.Sub(cP2, Centre));

            double arcAngle = VectorUtils.Angle(V1, V2);

            m_Weights = new double[] { 1, w2, 1 };
            m_Knots = new double[] { 0, 0, 0, arcAngle, arcAngle, arcAngle };
            m_Order = 3;

            Array.Copy(cP2, 0, m_ControlPoints, m_Dimensions + 1, m_Dimensions + 1);
            IsNurbForm = true;
        }

        public override double Length
        {
            get
            {
                return ArcAngle * Radius;
            }
        }

        public double ArcAngle
        {
            get
            {
                if (!IsNurbForm) CreateNurbForm();
                return m_Knots.Length > 0 ? m_Knots[m_Knots.Length - 1] : 0;
            }
        }

        public Point MiddlePoint
        {
            get
            {
                if (IsNurbForm)
                {
                    return PointAt(Domain[1] / 2);
                }
                else
                {
                    return new Point(BHoM.Common.Utils.SubArray<double>(m_ControlPoints, 4, 4));
                }
            }
        }



        public Point Centre
        {
            get
            {
                if (m_Centre == null)
                {
                    double[] v1 = VectorUtils.Sub(m_ControlPoints, 4, 0, 4);
                    double[] v2 = VectorUtils.Sub(m_ControlPoints, 8, 0, 4);

                    double[] normal = VectorUtils.CrossProduct(v1, v2);

                    double[] m1 = VectorUtils.Average(m_ControlPoints, 4, 0, 4);
                    double[] m2 = VectorUtils.Average(m_ControlPoints, 8, 0, 4);

                    double[] d1 = VectorUtils.CrossProduct(v1, normal);
                    double[] d2 = VectorUtils.CrossProduct(v2, normal);

                    m_Centre = VectorUtils.Intersect(m1, d1, m2, d2);
                }
                return new Point(m_Centre);
            }
        }

        public double Radius
        {
            get
            {
                return m_Radius != 0 ? m_Radius : m_Radius = VectorUtils.Length(VectorUtils.Sub(Centre, BHoM.Common.Utils.SubArray<double>(m_ControlPoints, 0, 4)));
            }
        }

        public override string ToJSON()
        {
            return "{\"__Type__\":\"" + this.GetType() + "\", \"Start\": " + StartPoint + ", \"Middle\": " + MiddlePoint + ", \"End\": " + EndPoint + "}";
        }
        public static new Arc FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            Point start = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["Start"], project) as double[]);
            Point middle = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["Middle"], project) as double[]);
            Point end = new Point(BHoMJSON.ReadValue(typeof(double[]), definition["End"], project) as double[]);
            return new Arc(start, end, middle);
        }
    }
}