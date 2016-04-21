using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Polyline : Curve
    {
        internal Polyline() { }

        public Polyline(List<Point> points)
        {
            m_Dimensions = 3;
            m_ControlPoints = new double[points.Count * (m_Dimensions + 1)];
            for (int i = 0; i < points.Count; i++)
            {
                double[] p = points[i];
                for (int j = 0; j < 4; j++)
                {
                    m_ControlPoints[i / 4 + j] = p[j];
                }
            }
        }

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
                for (int i = 0; i < m_ControlPoints.Length/(m_Dimensions +1) - (m_Dimensions + 1);i++)
                {
                    length += VectorUtils.Length(VectorUtils.Sub(m_ControlPoints, i, i + m_Dimensions + 1, m_Dimensions + 1));
                }
                return length;
            }
        }

        public override List<Curve> Explode()
        {
            List<Curve> lineSegments = new List<Curve>();
            lineSegments.Add(new Line(ControlPoint(0), ControlPoint(1)));
            for (int i = 1; i < NumControlPoints - 1;i++)
            {
                lineSegments.Add(new Line(lineSegments[i - 1].EndPoint, ControlPoint(i + 1)));
            }
            return lineSegments;
        }
    }
}
