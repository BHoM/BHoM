using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    public abstract class Curve : BHoMGeometry
    {
        internal double[] m_ControlPoints;
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
            m_Dimensions = points[0].Length - 1;
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

        internal Curve(double[] points, int dimensions)
        {
            m_Dimensions = dimensions;
            m_ControlPoints = points;
        }

        public override GeometryType GeometryType
        {
            get;
        }

        public bool IsNurbForm { get { return m_Knots != null && m_Weights != null; } }

        /// <summary>Start point as BHoM point</summary>
        /// 
        public virtual Point StartPoint
        {
            get
            {
                return new Point(m_ControlPoints, 0);
            }
        }

        /// <summary>End point as BHoM point</summary>
        public virtual Point EndPoint
        {
            get
            {
                return new Point(m_ControlPoints, m_ControlPoints.Length - m_Dimensions - 1);
            }
        }

        public virtual Point Max
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = Utils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
                }
                return new Point(m_ControlPoints[m_MaxMin[0]], m_ControlPoints[m_MaxMin[1]], m_ControlPoints[m_MaxMin[2]]);
            }
        }

        public virtual Point Min
        {
            get
            {
                if (m_MaxMin == null)
                {
                    m_MaxMin = Utils.MaxMinIndices(m_ControlPoints, m_Dimensions + 1);
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
                if (!IsNurbForm) return new double[] { 0, 0 };
                return m_Knots.Length > 0 ? new double[] { m_Knots[0], m_Knots[m_Knots.Length - 1] } : new double[] { 0, 0 };
            }
        }

        public double[] ControlPointVector
        {
            get
            {
                return m_ControlPoints;
            }
        }

        public Point this[int i]
        {
            get
            {
                return new Point(m_ControlPoints, (m_Dimensions + 1) * i);
            }
        }

        public List<Point> ControlPoints
        {
            get
            {
                List<Point> cPnts = new List<Point>();
                for (int i = 0; i < PointCount; i++)
                {
                    cPnts.Add(new Point(m_ControlPoints, (m_Dimensions + 1) * i));
                }
                return cPnts;
            }
        }

        public double[] Knots
        {
            get
            {
                return m_Knots;
            }
        }

        public double[] Weights
        {
            get
            {
                return m_Weights;
            }
        }

        public int Degree
        {
            get
            {
                return m_Order - 1;
            }
        }

        public int Order
        {
            get
            {
                return m_Order;
            }
        }

        public int Dimensions
        {
            get
            {
                return m_Dimensions;
            }
        }


        //public virtual double Length
        //{
        //    get // TODO - better default than zero but need proper implementation in all children classes
        //    {
        //        double length = 0;
        //        for (int i = 0; i < m_ControlPoints.Length / (m_Dimensions + 1) - (m_Dimensions + 1); i++)
        //        {
        //            length += VectorUtils.Length(VectorUtils.Sub(m_ControlPoints, i, i + m_Dimensions + 1, m_Dimensions + 1));
        //        }
        //        return length;
        //    }
        //}


        public virtual int PointCount
        {
            get
            {
                return m_ControlPoints.Length / (m_Dimensions + 1);
            }
        }

        /// <summary>
        /// Set the control point vector of the curve.
        /// </summary>
        /// <remarks>
        /// WARNING: ADVANCED USERS ONLY SETTING THIS INCORRECTLY WILL BREAK CURVE
        /// </remarks>
        /// <param name="pts">Points As Vector</param>
        public void SetControlPoints(double[] pts)
        {
            m_ControlPoints = pts;
        }
        /// <summary>
        /// Set the knot vector of the curve.
        /// </summary>
        /// <remarks>
        /// WARNING: ADVANCED USERS ONLY SETTING THIS INCORRECTLY WILL BREAK CURVE
        /// </remarks>
        /// <param name="knots">Knot vector</param>
        public void SetKnots(double[] knots)
        {
            m_Knots = knots;
        }
        /// <summary>
        /// Set the control point weights of the curve.
        /// </summary>
        /// <remarks>
        /// WARNING: ADVANCED USERS ONLY SETTING THIS INCORRECTLY WILL BREAK CURVE
        /// </remarks>
        /// <param name="weights"></param>
        public void SetWeights(double[] weights)
        {
            m_Weights = weights;
        }

        /// <summary>
        /// Set the order of the curve.
        /// </summary>
        /// <remarks>
        /// WARNING: ADVANCED USERS ONLY SETTING THIS INCORRECTLY WILL BREAK CURVE
        /// </remarks>
        /// <param name="weights"></param>
        public void SetDegree(int degree)
        {
            m_Order = degree + 1;
        }

        public bool IsClosed() { return StartPoint == EndPoint; }

        public override BHoMGeometry Duplicate()
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
            c.m_ControlPoints = Utils.Copy<double>(m_ControlPoints);
            c.m_Dimensions = m_Dimensions;
            c.m_Weights =Utils.Copy<double>(m_Weights);
            c.m_Knots = Utils.Copy<double>(m_Knots);
            c.m_Order = m_Order;
            return c;
        }

     
        public virtual List<Curve> Explode()
        {
            return new List<Curve> { this };
        }

        public override void Update()
        {
            m_MaxMin = null;
        }
    }

}
