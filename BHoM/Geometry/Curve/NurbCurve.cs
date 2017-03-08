using BHoM.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class NurbCurve : Curve
    {
        internal NurbCurve()
        {

        }

        public NurbCurve(List<double[]> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights;
        }

        public NurbCurve(List<Point> points, int degree, double[] knots, double[] weights) : base(points)
        {
            m_Dimensions = 3;
            m_Order = degree + 1;
            m_Knots = knots;
            m_Weights = weights;
        }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.NurbCurve;
            }
        }

        public new double[] Knots
        {
            get
            {
                return base.Knots;
            }
            set
            {
                m_Knots = value;
            }
        }

        public new double[] Weights
        {
            get
            {
                return base.Weights;
            }
            set
            {
                m_Weights = value;
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

        public new int Degree
        {
            get
            {
                return base.Degree;
            }
            set
            {
                m_Order = value + 1;
            }
        }

        public static NurbCurve Create(List<Point> points, int degree, double[] knots, double[] weights)
        {
            return new NurbCurve(points, degree, knots, weights);
        }
    }
}
