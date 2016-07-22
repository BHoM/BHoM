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
        internal double[] m_ControlPoints;
        protected bool IsNurbForm = false;
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


        public bool ContainsCurve(Curve c)
        {
            Plane p = null;
            if (this.IsClosed() && TryGetPlane(out p))
            {
                if (p.InPlane(c.ControlPointVector, c.m_Dimensions + 1, 0.001))
                {
                    for (int i = 0; i < c.ControlPointVector.Length; i += c.m_Dimensions + 1)
                    {
                        double[] pointArray = Common.Utils.SubArray(c.ControlPointVector, i, c.m_Dimensions + 1);
                        double[] direction = VectorUtils.Add(VectorUtils.Sub(pointArray, p.Origin), pointArray);
                        double[] up = VectorUtils.Add(pointArray, p.Normal);
                        Plane cuttingPlane = new Plane(Common.Utils.Merge(pointArray, direction, up), m_Dimensions + 1);
                        Point point = new Point(pointArray);
                        List<Point> intersects = Intersect.PlaneCurve(cuttingPlane, this, 0.001);
                        intersects.Add(point);
                        intersects = Point.RemoveDuplicates(intersects, 3);

                        intersects.Sort(delegate (Point p1, Point p2)
                        {
                            return VectorUtils.DotProduct(p1, direction).CompareTo(VectorUtils.DotProduct(p2, direction));
                        });

                        for (int j = 0; j < intersects.Count; j++)
                        {
                            if (j % 2 == 0 && intersects[j] == point) return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool ContainsPoints(List<Point> points)
        {
            Plane p = null;
            if (this.IsClosed() && TryGetPlane(out p))
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (p.InPlane(points[i], 0.001))
                    {
                        Vector direction = points[i] - p.Origin;
                        Vector up = p.Normal;
                        Plane cuttingPlane = new Plane(points[i], points[i] + direction, points[i] + up);
                        List<Point> intersects = Intersect.PlaneCurve(cuttingPlane, this, 0.001);
                        intersects.Add(points[i]);
                        intersects = Point.RemoveDuplicates(intersects, 3);

                        intersects.Sort(delegate (Point p1, Point p2)
                        {
                            return VectorUtils.DotProduct(p1, direction).CompareTo(VectorUtils.DotProduct(p2, direction));
                        });

                        for (int j = 0; j < intersects.Count; j++)
                        {
                            if (j % 2 == 0 && intersects[j] == points[i]) return false;
                        }
                    }
                    else return false;
                }
                return true;
            }
            return false;
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
        protected double[] LeftControlPoints(double t)
        {
            int index = 0;
            while (t >= m_Knots[index]) { index++; }
            index -= Degree;

            return BHoM.Common.Utils.SubArray<double>(m_ControlPoints, 0, index * (m_Dimensions + 1));
        }


        protected double[] RightControlPoints(double t)
        {
            int index = 0;
            while (t > m_Knots[index]) { index++; }
            index -= (Degree - 1);

            if (index < PointCount)
            {
                return BHoM.Common.Utils.SubArray<double>(m_ControlPoints, index * (m_Dimensions + 1), (PointCount - index) * (m_Dimensions + 1));
            }
            else
            {
                return new double[0];
            }
        }

        public void ChangeDegree(int newDegree)
        {
            while (newDegree > Degree)
            {
                int size = m_Dimensions + 1;

                List<double> knots = new List<double>();
                List<double> newPoints = new List<double>();
                List<double> weights = new List<double>();
                knots.Add(m_Knots[0]);
                for (int i = 1; i < m_Knots.Length; i++)
                {
                    if (m_Knots[i] != m_Knots[i - 1])
                    {
                        knots.Add(m_Knots[i - 1]);

                        double[] pnts = Common.Utils.SubArray<double>(m_ControlPoints, (i - m_Order) * size, size * m_Order);
                        double[] weightResults = Common.Utils.SubArray<double>(m_Weights, i - m_Order, m_Order);

                        for (int j = 0; j < m_Order; j++)
                        {
                            double lhs = (double)j / m_Order;
                            double rhs = (1 - lhs);
                            double weight = lhs > 0 ? rhs > 0 ? lhs * weightResults[j - 1] + weightResults[j] * rhs : lhs * weightResults[j - 1] : weightResults[j] * rhs;
                            weights.Add(weight);
                            if (lhs > 0)
                            {
                                for (int k = 0; k < size; k++)
                                {
                                    newPoints.Add((lhs * pnts[(j - 1) * size + k] * weightResults[j - 1] + rhs * pnts[j * size + k] * weightResults[j]) / weight);
                                }
                            }
                            else
                            {
                                for (int k = 0; k < size; k++)
                                {
                                    newPoints.Add((rhs * pnts[j * size + k] * weightResults[j]) / weight);
                                }
                            }
                        }
                    }
                    knots.Add(m_Knots[i]);
                }

                weights.Add(m_Weights[m_Weights.Length - 1]);
                newPoints.AddRange(Common.Utils.SubArray<double>(m_ControlPoints, m_ControlPoints.Length - size, size));

                knots.Add(m_Knots[m_Knots.Length - 1]);
                m_Order++;
                m_ControlPoints = newPoints.ToArray();
                m_Weights = weights.ToArray();
                m_Knots = knots.ToArray();
            }
        }

        public int InsertKnot(double value)
        {
            if (!IsNurbForm) CreateNurbForm();
            int controlPointIndex = 0;
            double lowerKnot = 0;
            double upperKnot = 0;
            int size = m_Dimensions + 1;
            for (int i = 0; i < m_Knots.Length; i++)
            {
                if (m_Knots[i] > value)
                {
                    lowerKnot = m_Knots[i - 1];
                    upperKnot = m_Knots[i];

                    controlPointIndex = i - Degree;
                    break;
                }
            }

            double[] points = new double[Degree * (size)];
            double[] weightResults = new double[Degree];

            int i1 = 0;
            int j1 = 0;
            for (int i = 0; i < Degree; i++)
            {
                i1 = i + controlPointIndex;
                double t = (value - m_Knots[i1]) / (m_Knots[i1 + Degree] - m_Knots[i1]);
                weightResults[i] = m_Weights[i1 - 1] * (1 - t) + t * m_Weights[i1];
                for (int j = 0; j < size; j++)
                {
                    j1 = j + i1 * size;
                    points[j + i * size] = (m_Weights[i1 - 1] * m_ControlPoints[j1 - size] * (1 - t) + t * m_Weights[i1] * m_ControlPoints[j1]) / weightResults[i];
                }
            }

            double[] newControlPnts = Common.Utils.Merge<double>(LeftControlPoints(lowerKnot), points, RightControlPoints(upperKnot));

            double[] newWeight = new double[m_Weights.Length + 1];
            Array.Copy(m_Weights, newWeight, controlPointIndex);
            Array.Copy(weightResults, 0, newWeight, controlPointIndex, Degree);
            Array.Copy(m_Weights, controlPointIndex + 1, newWeight, controlPointIndex + Degree, newWeight.Length - Degree - controlPointIndex);

            double[] knots = new double[m_Knots.Length + 1];

            Array.Copy(m_Knots, knots, controlPointIndex + Degree);
            knots[controlPointIndex + Degree] = value;
            Array.Copy(m_Knots, controlPointIndex + Degree, knots, controlPointIndex + Degree + 1, m_Knots.Length - controlPointIndex - Degree);
            m_Knots = knots;
            m_ControlPoints = newControlPnts;
            m_Weights = newWeight;
            return controlPointIndex;
        }


        public virtual List<Curve> Split(double t)
        {
            if (!IsNurbForm) CreateNurbForm();

            int insertedIndex = InsertKnot(t);
            int startIndex = insertedIndex;

            while (insertedIndex + 1 < Degree || PointCount - (startIndex + Degree - 1) < Degree)
            {
                insertedIndex = InsertKnot(t);
            }

            double[] midPoint = Common.Utils.Merge<double>(UnsafePointAt(t), new double[] { 1 });
            double[] lhsPnts = Common.Utils.Merge<double>(LeftControlPoints(t), midPoint);
            double[] rhsPnts = Common.Utils.Merge<double>(midPoint, RightControlPoints(t));

            double[] lhsWeights = new double[lhsPnts.Length / (m_Dimensions + 1)];
            double[] rhsWeights = new double[rhsPnts.Length / (m_Dimensions + 1)];

            double[] lhsKnots = new double[lhsWeights.Length + m_Order];
            double[] rhsKnots = new double[rhsWeights.Length + m_Order];

            Array.Copy(m_Weights, lhsWeights, lhsWeights.Length - 1);
            Array.Copy(m_Weights, insertedIndex + 1, rhsWeights, 1, rhsWeights.Length - 1);

            double tRatio = (t - m_Knots[insertedIndex + Degree - 1]) / (m_Knots[insertedIndex + Degree + 1] - m_Knots[insertedIndex + Degree - 1]);

            double midWeightValue = (1 - tRatio) * m_Weights[insertedIndex] + tRatio * m_Weights[insertedIndex + 1];

            lhsWeights[lhsWeights.Length - 1] = midWeightValue;
            rhsWeights[0] = midWeightValue;

            Array.Copy(m_Knots, lhsKnots, insertedIndex + m_Order);
            for (int i = lhsKnots.Length - Degree; i < lhsKnots.Length; i++)
            {
                lhsKnots[i] = t;
            }

            Array.Copy(m_Knots, insertedIndex + m_Order, rhsKnots, rhsKnots.Length - m_Order, m_Order);
            for (int i = rhsKnots.Length - Degree - 1; i < rhsKnots.Length; i++)
            {
                rhsKnots[i] -= t;
            }

            Curve lhs = this.ShallowDuplicate();
            Curve rhs = this.ShallowDuplicate();

            lhs.IsNurbForm = true;
            lhs.m_ControlPoints = lhsPnts;
            lhs.m_Knots = lhsKnots;
            lhs.m_Weights = lhsWeights;
            lhs.m_Order = m_Order;

            rhs.IsNurbForm = true;
            rhs.m_ControlPoints = rhsPnts;
            rhs.m_Knots = rhsKnots;
            rhs.m_Weights = rhsWeights;
            rhs.m_Order = m_Order;

            return new List<Curve>() { lhs, rhs };
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

        internal virtual Curve Append(Curve c)
        {
            ChangeDegree(c.Degree);
            c.ChangeDegree(Degree);

            List<double> knots = new List<double>();
            List<double> pnts = new List<double>();
            List<double> weights = new List<double>();

            knots.AddRange(Common.Utils.SubArray<double>(m_Knots, 0, m_Knots.Length - 1));
            pnts.AddRange(m_ControlPoints);
            weights.AddRange(m_Weights);

            for (int i = 0; i < c.m_Knots.Length; i++)
            {
                if (c.m_Knots[i] != 0) knots.Add(c.m_Knots[i] + m_Knots[m_Knots.Length - 1]);
            }

            pnts.AddRange(Common.Utils.SubArray<double>(c.m_ControlPoints, m_Dimensions + 1, c.m_ControlPoints.Length - m_Dimensions - 1));
            weights.AddRange(Common.Utils.SubArray<double>(c.m_Weights, 1, c.m_Weights.Length - 1));

            List<Curve> crvs = new List<Curve>();
            crvs.AddRange(this.Explode());
            crvs.AddRange(c.Explode());

            PolyCurve curve = new PolyCurve(crvs);
            curve.m_ControlPoints = pnts.ToArray();
            curve.m_Dimensions = m_Dimensions;
            curve.m_Order = m_Order;
            curve.m_Weights = weights.ToArray();
            curve.m_Knots = knots.ToArray();

            return curve;
        }

        public static List<Curve> Join(List<Curve> curves)
        {
            List<Curve> result = new List<Curve>();
            for (int i = 0; i < curves.Count; i++)
            {
                result.Add(curves[i]);
            }
            int counter = 0;
            int dimensions = result.Count > 0 ? result[0].m_Dimensions : 0;
            while (counter < result.Count)
            {
                double[] cps1 = result[counter].m_ControlPoints;

                for (int j = counter + 1; j < result.Count; j++)
                {
                    double[] cps2 = result[j].m_ControlPoints;
                    if (VectorUtils.Equal(cps1, cps1.Length - dimensions - 1, cps2, 0, dimensions, 0.0001))
                    {
                        result[j] = result[counter].Append(result[j]);
                        result.RemoveAt(counter--);
                        break;
                    }
                    else if (VectorUtils.Equal(cps1, 0, cps2, cps2.Length - dimensions - 1, dimensions, 0.0001))
                    {
                        result[j] = result[j].Append(result[counter]);
                        result.RemoveAt(counter--);
                        break;
                    }
                    else if (VectorUtils.Equal(cps1, 0, cps2, 0, dimensions, 0.0001))
                    {
                        result[j] = result[counter].Flip().Append(result[j]);
                        result.RemoveAt(counter--);
                        break;
                    }
                    else if (VectorUtils.Equal(cps1, cps1.Length - dimensions - 1, cps2, cps2.Length - dimensions - 1, dimensions, 0.0001))
                    {
                        result[j] = result[counter].Append(result[j].Flip());
                        result.RemoveAt(counter--);
                        break;
                    }
                }
                counter++;
            }
            return result;
        }

        #endregion
        public override GeometryBase Duplicate()
        {
            return DuplicateCurve();
        }

        public Curve ShallowDuplicate()
        {
            return (Curve)this.MemberwiseClone();
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
