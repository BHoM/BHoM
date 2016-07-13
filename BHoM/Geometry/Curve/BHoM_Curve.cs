using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;

namespace BHoM.Geometry
{
    public abstract class Curve : GeometryBase
    {
        protected bool IsNurbForm = false;
        protected double[] m_ControlPoints;
        protected double[] m_Knots;
        protected double[] m_Weights;
        protected int[] m_MaxMin;
        protected int m_Order;
        protected int m_Dimensions;

        protected Curve() { }

        internal Curve(List<Point> points)
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[points.Count * (m_Dimensions + 1)];
            for (int i = 0; i < points.Count; i++)
            {
                double[] p = points[i];
                for (int j = 0; j < 4; j++)
                {
                    m_ControlPoints[i * 4 + j] = p[j];
                }
            }
        }

        internal Curve(List<double[]> points)
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[points.Count * (m_Dimensions + 1)];
            for (int i = 0; i < points.Count; i++)
            {
                double[] p = points[i];
                for (int j = 0; j < 4; j++)
                {
                    m_ControlPoints[i * 4 + j] = j == 3 && p.Length < 4 ? 1 : p[j];
                }
            }
        }

        /// <summary>Start point as BHoM point</summary>
        /// 
        public virtual Point StartPoint
        {
            get
            {
                return new Point(Common.Utils.SubArray<double>(m_ControlPoints, 0, m_Dimensions));
            }
        }

        /// <summary>End point as BHoM point</summary>
        public virtual Point EndPoint
        {
            get
            {
                return new Point(Common.Utils.SubArray<double>(m_ControlPoints, m_ControlPoints.Length - m_Dimensions - 1, m_Dimensions));
            }
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
                return new Point(m_ControlPoints[m_MaxMin[4]], m_ControlPoints[m_MaxMin[5]], m_ControlPoints[m_MaxMin[6]]);
            }
        }

        public override BoundingBox Bounds()
        {
            return new BoundingBox(Max, Min);
        }

        public virtual double[] Domain
        {
            get
            {
                if (!IsNurbForm) CreateNurbForm();
                return m_Knots.Length > 0 ? new double[] { m_Knots[0], m_Knots[m_Knots.Length - 1] } : new double[] { 0, 0 };
            }
        }

        internal double[] ControlPointVector
        {
            get
            {
                return m_ControlPoints;
            }
        }

        internal virtual double[] ControlPoint(int i)
        {
            return i < (int)(m_ControlPoints.Length / (m_Dimensions + 1)) ?
                new Point(Common.Utils.SubArray<double>(m_ControlPoints, i * (m_Dimensions + 1), m_Dimensions)) : null;
        }

        public Point this[int i]
        {
            get
            {
                return new Point(ControlPoint(i));
            }
        }


        public List<Point> ControlPoints
        {
            get
            {
                List<Point> cPnts = new List<Point>();
                for (int i = 0; i < PointCount; i++)
                {
                    cPnts.Add(new Point(ControlPoint(i)));
                }
                return cPnts;
            }
        }


        public double[] Knots
        {
            get
            {
                if (m_Knots == null)
                {
                    CreateNurbForm();
                }
                return m_Knots;
            }
        }

        public double[] Weights
        {
            get
            {
                if (m_Weights == null)
                {
                    CreateNurbForm();
                }
                return m_Weights;
            }
        }

        public int Degree
        {
            get
            {
                if (m_Order == 0)
                {
                    CreateNurbForm();
                }
                return m_Order - 1;
            }
        }

        public virtual double Length
        {
            get // TODO - better default than zero but need proper implementation in all children classes
            {
                double length = 0;
                for (int i = 0; i < m_ControlPoints.Length / (m_Dimensions + 1) - (m_Dimensions + 1); i++)
                {
                    length += VectorUtils.Length(VectorUtils.Sub(m_ControlPoints, i, i + m_Dimensions + 1, m_Dimensions + 1));
                }
                return length;
            }
        }


        public virtual int PointCount
        {
            get
            {
                return m_ControlPoints.Length / (m_Dimensions + 1);
            }
        }

        private double BasisFunction(int i, int n, double t)
        {
            if (n > 0 && t >= m_Knots[i] && t < m_Knots[i + n + 1])
            {
                double result = 0;
                if (m_Knots[i + n] - m_Knots[i] > 0)
                {
                    result += BasisFunction(i, n - 1, t) * (t - m_Knots[i]) / (m_Knots[i + n] - m_Knots[i]);
                }
                if (m_Knots[i + n + 1] - m_Knots[i + 1] > 0)
                {
                    result += BasisFunction(i + 1, n - 1, t) * (m_Knots[i + n + 1] - t) / (m_Knots[i + n + 1] - m_Knots[i + 1]);
                }

                return result;
            }
            else
            {
                return t >= m_Knots[i] && t < m_Knots[i + 1] ? 1 : 0;
            }
        }

        private double DerivativeFunction(int i, int n, double t)
        {
            if (n > 0)
            {
                double result = 0;
                if (i + n < m_Knots.Length && m_Knots[i + n] - m_Knots[i] > 0)
                {
                    result += BasisFunction(i, n - 1, t) * n / (m_Knots[i + n] - m_Knots[i]);
                }
                if (i + n + 1 < m_Knots.Length && m_Knots[i + n + 1] - m_Knots[i + 1] > 0)
                {
                    result -= BasisFunction(i + 1, n - 1, t) * n / (m_Knots[i + n + 1] - m_Knots[i + 1]);
                }
                return result;
            }

            return 0;
        }

        public virtual Point PointAt(double t)
        {
            if (!IsNurbForm) CreateNurbForm();
            return new Point(UnsafePointAt(t));
        }

        internal double[] UnsafePointAt(double t)
        {
            double[] sumNwP = new double[m_Dimensions];
            double sumNw = 0;
            if (t == 0) return Common.Utils.SubArray<double>(m_ControlPoints, 0, 3);
            else if (t >= m_Knots[m_Knots.Length - 1]) return Common.Utils.SubArray<double>(m_ControlPoints, m_ControlPoints.Length - 4, 3);
            for (int i = 0; i < m_ControlPoints.Length / (m_Dimensions + 1); i++)
            {
                double Nt = BasisFunction(i, m_Order - 1, t);
                if (Nt == 0) continue;
                sumNwP = VectorUtils.Add(sumNwP, VectorUtils.Multiply(m_ControlPoints, Nt * m_Weights[i], i * (m_Dimensions + 1), m_Dimensions));
                sumNw += Nt * m_Weights[i];
            }
            return VectorUtils.Divide(sumNwP, sumNw);
        }

        public virtual Vector TangentAt(double t)
        {
            if (!IsNurbForm) CreateNurbForm();
            double[] sumNwP = new double[m_Dimensions];
            double[] sumNwPDer = new double[m_Dimensions];
            double sumNw = 0;
            double sumNwDer = 0;

            for (int i = 0; i < m_ControlPoints.Length / (m_Dimensions + 1); i++)
            {
                double Nt = BasisFunction(i, m_Order - 1, t);
                double Nder = DerivativeFunction(i, m_Order - 1, t);
                double[] P = Common.Utils.SubArray<double>(m_ControlPoints, i * (m_Dimensions + 1), m_Dimensions);
                sumNwP = VectorUtils.Add(sumNwP, VectorUtils.Multiply(P, Nt * m_Weights[i]));
                sumNwPDer = VectorUtils.Add(sumNwPDer, VectorUtils.Multiply(P, Nder * m_Weights[i]));
                sumNw += Nt * m_Weights[i];
                sumNwDer += Nder * m_Weights[i];
            }
            double[] numerator = VectorUtils.Sub(VectorUtils.Multiply(sumNwPDer, sumNw), VectorUtils.Multiply(sumNwP, sumNwDer));
            return new Vector(VectorUtils.Divide(numerator, Math.Pow(sumNw, 2)));
        }

        public virtual List<Curve> Explode()
        {
            return new List<Curve>() { this };
        }

        public virtual Curve Flip()
        {
            m_ControlPoints = Common.Utils.Reverse<double>(m_ControlPoints, m_Dimensions + 1);
            if (IsNurbForm)
            {
                double max = m_Knots.Max();
                m_Knots = VectorUtils.Sub(new double[] { max }, m_Knots);
                m_Weights = m_Weights.Reverse().ToArray();
            }
            return this;
        }

        public abstract void CreateNurbForm();

        public virtual bool IsPlanar()
        {
            return Plane.PointsInSamePlane(m_ControlPoints, m_Dimensions + 1);
        }

        public bool IsClosed()
        {
            return VectorUtils.Equal(EndPoint, StartPoint, 0.0001);
        }

        public virtual bool TryGetPlane(out Plane plane)
        {
            plane = Plane.PlaneFromPoints(m_ControlPoints, m_Dimensions + 1);
            return plane != null;
        }

        public override void Transform(Transform t)
        {
            m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            Update();
        }

        public override void Translate(Vector v)
        {
            m_ControlPoints = VectorUtils.Add(m_ControlPoints, v);
        }

        public override void Mirror(Plane p)
        {
            m_ControlPoints = VectorUtils.Add(VectorUtils.Multiply(p.ProjectionVectors(m_ControlPoints), 2), m_ControlPoints);
            Update();
        }

        public override void Project(Plane p)
        {
            m_ControlPoints = VectorUtils.Add(p.ProjectionVectors(m_ControlPoints), m_ControlPoints);
            Update();
        }

        public override void Update()
        {
            m_MaxMin = null;
        }

        #region Static Functions

        public static List<Curve> Join(Group<Curve> curves)
        {
            return Join(curves.ToList());
        }

        public static List<Curve> Join(List<Curve> curves)
        {
            List<Curve> result = new List<Curve>();
            for (int i = 0; i < curves.Count; i++)
            {
                result.Add(curves[i]);
            }
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (VectorUtils.Equal(result[i].StartPoint, result[j].StartPoint, 0.0001))
                    {
                        result[j] = new PolyCurve(result[i].Flip(), result[j]);
                        result.RemoveAt(i--);
                        break;
                    }
                    else if (VectorUtils.Equal(result[i].StartPoint, result[j].EndPoint, 0.0001))
                    {
                        result[j] = new PolyCurve(result[j], result[i]);
                        result.RemoveAt(i--);
                        break;
                    }
                    else if (VectorUtils.Equal(result[i].EndPoint, result[j].EndPoint, 0.0001))
                    {
                        result[j] = new PolyCurve(result[i], result[j].Flip());
                        result.RemoveAt(i--);
                        break;
                    }
                    else if (VectorUtils.Equal(result[i].EndPoint, result[j].StartPoint, 0.0001))
                    {
                        result[j] = new PolyCurve(result[i], result[j]);
                        result.RemoveAt(i--);
                        break;
                    }
                }
            }
            return result;
        }

        #endregion
        public override GeometryBase Duplicate()
        {
            return DuplicateCurve();
        }

        public virtual Curve DuplicateCurve()
        {
            Curve c = (Curve)Activator.CreateInstance(this.GetType(), true);
            c.m_ControlPoints = Common.Utils.Copy<double>(m_ControlPoints);
            c.m_Dimensions = m_Dimensions;
            c.m_Weights = Common.Utils.Copy<double>(m_Weights);
            c.m_Knots = Common.Utils.Copy<double>(m_Knots);
            c.m_Order = m_Order;
            return c;
        }

        public virtual Point ClosestPoint(Point point) // TODO - This should be virtual and implemented properly in each sub-class
        {
            List<Point> points = ControlPoints;

            double minDist = 1e10;
            Point closest = (points.Count() > 0) ? points[0] : new Point(Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity);
            for (int i = 1; i < points.Count(); i++)
            {
                Vector dir = (points[i] - points[i - 1]) / Length;
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
            string points = "\"points\": [[ ";
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
            string knots = "";
            if (m_Knots != null)
                knots = "\"knots\": " + Common.Utils.CollectionToString(m_Knots);
            string weights = "";
            if (m_Weights != null)
                weights = VectorUtils.MinValue(m_Weights) < 1 ? "\"weights\": " + Common.Utils.CollectionToString(m_Weights) : "";
            string degree = "\"degree\": " + (m_Order - 1);
            return "{\"Primitive\": \"curve\"," + points + "," + degree + (knots != "" ? "," : "") + knots + (weights != "" ? "," : "") + weights + "}";
        }


        public static new Curve FromJSON(string json, Project project)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;

            var typeString = definition["Primitive"].Replace("\"", "").Replace("{", "").Replace("}", "");

            switch (typeString)
            {               
                case "arc":
                    return Arc.FromJSON(json, project);
                case "line":
                    return Line.FromJSON(json, project);
                case "polyline":
                    return Polyline.FromJSON(json, project);
                case "circle":
                    return Circle.FromJSON(json, project);
                default:
                    List<double[]> curvePoints = BHoMJSON.ReadValue(typeof(List<double[]>), definition["points"], project) as List<double[]>;
                    double[] knots = definition.ContainsKey("knots") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["knots"], project) : null;
                    double[] weights = definition.ContainsKey("weights") ? (double[])BHoMJSON.ReadValue(typeof(double[]), definition["weights"], project) : null;
                    int degree = (int)BHoMJSON.ReadValue(typeof(int), definition["degree"], project);
                    return new NurbCurve(curvePoints, degree, knots, weights);
            }      
        }
    }

    public class NurbCurve : Curve
    {
        internal NurbCurve(List<double[]> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights != null ? weights : VectorUtils.Splat(1, points.Count);
        }

        internal NurbCurve(List<Point> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights != null ? weights : VectorUtils.Splat(1, points.Count);
        }

        public override void CreateNurbForm()
        {
            IsNurbForm = true;
        }

        public static NurbCurve Create(List<Point> points, int degree, double[] knots, double[] weights)           
        {
            return new NurbCurve(points, degree, knots, weights);
        }
    }
}
