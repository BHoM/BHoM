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

        public Polyline(List<Point> points) : base(points) { }

        internal Polyline(List<double[]> pnts) : base(pnts) { }

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
            for (int i = 1; i < PointCount - 1;i++)
            {
                lineSegments.Add(new Line(lineSegments[i - 1].EndPoint, ControlPoint(i + 1)));
            }
            return lineSegments;
        }

        public override string ToJSON()
        {
            string aResult = "{{";
            for (int i = 0; i < m_ControlPoints.Length - 1; i++)
            {
                if (i > 0 && (i + 1) % 4 == 0)
                {
                    aResult = aResult.Trim(',') + "},{";
                }
                else
                { 
                    aResult += m_ControlPoints[i] + ",";
                }
            }
            aResult = aResult.Trim(',') + "}}";
            return "{\"Primitive\": \"polyline\"," + "\"points\": " + aResult + "}";
        }

    }
}
