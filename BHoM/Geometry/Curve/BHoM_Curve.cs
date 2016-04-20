using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public abstract class Curve : IGeometry
    {
        protected bool IsNurbForm = false;
        protected double[] m_ControlPoints;
        protected double[] m_Knots;
        protected double[] m_Weights;
        protected int[] m_MaxMin;
        protected int m_Order;
        protected int m_Dimensions;

        protected Curve() { }


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

        public virtual BoundingBox Bounds()
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

        internal double[] ControlPoints
        {
            get
            {
                return m_ControlPoints;
            }
        }

        public virtual Point ControlPoint(int i)
        {
            return i < (int)(m_ControlPoints.Length / (m_Dimensions + 1)) ? 
                new Point(Common.Utils.SubArray<double>(m_ControlPoints, i * (m_Dimensions + 1), m_Dimensions + 1)) : null;
        }

        public virtual double Length
        {
            get
            {
                return 0;
            }
        }


        public virtual int NumControlPoints
        {
            get
            {
                return m_ControlPoints.Length / (m_Dimensions + 1);
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private double BasisFunction(int i, int n, double t)
        {
            if (n > 0 && t >= m_Knots[i] && t < m_Knots[i + n + 1])
            {
                double result = 0;
                if (m_Knots[i + n] - m_Knots[i] > 0 )
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
                    result += BasisFunction(i, n - 1, t) * n / (m_Knots[i + n] - m_Knots[i]) ;
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
            double[] sumNwP = new double[m_Dimensions];
            double sumNw = 0;
            for (int i = 0; i < m_ControlPoints.Length / (m_Dimensions + 1); i++)
            {
                double Nt = BasisFunction(i, m_Order - 1, t);                
                sumNwP = VectorUtils.Add(sumNwP, VectorUtils.Multiply(m_ControlPoints, Nt * m_Weights[i], i * (m_Dimensions + 1), m_Dimensions));
                sumNw += Nt * m_Weights[i];
            }
            return new Point(VectorUtils.Divide(sumNwP, sumNw));
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
            return Plane.SamePlane(m_ControlPoints, m_Dimensions + 1);
        }

        public bool IsClosed()
        {
            return EndPoint == StartPoint;
        }

        public virtual void Transform(Transform t)
        {
            m_ControlPoints = VectorUtils.MultiplyMany(t, m_ControlPoints);
            Update();
        }

        public virtual void Translate(Vector v)
        {
            m_ControlPoints = VectorUtils.Add(m_ControlPoints, v);
        }

        public virtual void Mirror(Plane p)
        {
            m_ControlPoints = VectorUtils.Add(VectorUtils.Multiply(p.ProjectionVectors(m_ControlPoints), 2), m_ControlPoints);
            Update();
        }

        public virtual void Project(Plane p)
        {
            m_ControlPoints = VectorUtils.Add(p.ProjectionVectors(m_ControlPoints), m_ControlPoints);
            Update();
        }

        public virtual void Update()
        {
            m_MaxMin = null;
        }

        #region Static Functions

        public static List<Curve> Join(List<Curve> curves)
        {
            List<Curve> result = new List<Curve>();
            for (int i = 0; i < curves.Count;i++)
            {
                result.Add(curves[i]);
            }
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (VectorUtils.Equal(result[i].StartPoint,result[j].StartPoint,0.0001))
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
        public virtual IGeometry Duplicate()
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
    }
}
