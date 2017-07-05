using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;
using BHoM.Base;

namespace BHoM.Geometry
{
    public class Polyline : Curve
    {
        public Polyline() { }

        public Polyline(List<Point> points) : base(points) { }

        public Polyline(List<double[]> pnts) : base(pnts) { }

        public override void CreateNurbForm()
        {
            m_Order = 2;
            m_Knots = new double[m_ControlPoints.Length / (m_Dimensions + 1) + m_Order];
            m_Weights = new double[m_ControlPoints.Length / (m_Dimensions + 1)];
            m_Knots[0] = 0;
            m_Knots[m_Knots.Length - 1] = m_Weights.Length - 1;
            for (int i = 0; i < m_Weights.Length; i++)
            {
                m_Knots[i + 1] = i;
                m_Weights[i] = 1;
            }

            IsNurbForm = true;
        }

        public override double Length
        {
            get
            {               
                double length = 0;
                for (int i = 1; i < ControlPoints.Count; i++)
                {
                    length += VectorUtils.Length(VectorUtils.Sub(ControlPoints[i], ControlPoints[i - 1]));
                }
                return length;
            }
        }

        public override List<Curve> Explode()
        {
            List<Curve> lineSegments = new List<Curve>();
            lineSegments.Add(new Line(ControlPoint(0), ControlPoint(1)));
            for (int i = 1; i < PointCount - 1; i++)
            {
                lineSegments.Add(new Line(lineSegments[i - 1].EndPoint, ControlPoint(i + 1)));
            }
            return lineSegments;
        }

        internal override Curve Append(Curve c)
        {
            if (c is Line)
            {
                m_ControlPoints = BHoM.Common.Utils.Merge<double>(m_ControlPoints, c.EndPoint);
                CreateNurbForm();
                Update();
                return this;
            }
            else if (c is Polyline)
            {
                double[] endPoints = Common.Utils.SubArray<double>(c.m_ControlPoints, m_Dimensions + 1, c.m_ControlPoints.Length - m_Dimensions - 1);
                m_ControlPoints = BHoM.Common.Utils.Merge<double>(m_ControlPoints, endPoints);
                CreateNurbForm();
                Update();
                return this;
            }
            else
            {
                return base.Append(c);
            }
        }

        public override Point ClosestPoint(Point point)
        {
            List<Point> points = ControlPoints;

            double minDist = 1e10;
            Point closest = (points.Count() > 0) ? points[0] : new Point(Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity);
            for (int i = 1; i < points.Count(); i++)
            {
                Vector dir = (points[i] - points[i-1]) / Length;
                double t = Math.Min(Math.Max(dir * (point - points[i - 1]), 0), Length);
                Point cp = StartPoint + t * dir;

                double dist = cp.DistanceTo(point);
                if (dist < minDist)
                {
                    closest = cp;
                    minDist = dist;
                }
            }
            return closest;
        }

        public override string ToJSON()
        {
            string aResult = "[[";
            for (int i = 0; i < m_ControlPoints.Length - 1; i++)
            {
                if (i > 0 && (i + 1) % 4 == 0)
                {
                    aResult = aResult.Trim(',') + "],[";
                }
                else
                {
                    aResult += m_ControlPoints[i] + ",";
                }
            }
            aResult = aResult.Trim(',') + "]]";
            return "{\"__Type__\": \"" + this.GetType().FullName + "\"," + "\"Points\": " + aResult + "}";
        }

        public static new Polyline FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            List<double[]> points = BHoMJSON.ReadValue(typeof(List<double[]>), definition["Points"], project) as List<double[]>;
            return new Polyline(points);
        }
    }
}
