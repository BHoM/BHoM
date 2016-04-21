using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolyCurve : Curve
    {
        private CurveArray m_CurveArray;

        internal PolyCurve() { }
        internal PolyCurve(Curve c1, Curve c2)
        {
            m_CurveArray = new CurveArray(new List<Curve>() { c1, c2 });
            m_Dimensions = 3;
        }

        public override void CreateNurbForm()
        {
            m_Knots = new double[m_CurveArray.Count];

            double accum = 0;
            for (int i = 1; i < m_CurveArray.Count; i++)
            {
                accum += m_CurveArray[i].Domain[1];
                m_Knots[i] = accum;
            }
            IsNurbForm = true;
        }

        public override Point StartPoint
        {
            get
            {
                return m_CurveArray.Count > 0 ? m_CurveArray[0].StartPoint : null;
            }
        }

        public override Point EndPoint
        {
            get
            {
                return m_CurveArray.Count > 0 ? m_CurveArray[m_CurveArray.Count - 1].EndPoint : null;
            }
        }

        public override Point PointAt(double t)
        {
            int i = 0;
            while (t > m_Knots[i] && i < m_Knots.Length) i++;

            return m_CurveArray[i].PointAt(t - m_Knots[i]);
        }

        public override Vector TangentAt(double t)
        {
            int i = 0;
            while (t > m_Knots[i] && i < m_Knots.Length) i++;

            return m_CurveArray[i].TangentAt(t - m_Knots[i]);
        }

        public override BoundingBox Bounds()
        {
            return m_CurveArray.Bounds();            
        }

        public override List<Curve> Explode()
        {
            List<Curve> exploded = new List<Curve>();
            for (int i = 0; i < m_CurveArray.Count; i++)
            {
                exploded.AddRange(m_CurveArray[i].Explode());
            }
            return exploded;
        }

        public override Curve DuplicateCurve()
        {
            PolyCurve c = base.DuplicateCurve() as PolyCurve;
            c.m_CurveArray = m_CurveArray.Duplicate() as CurveArray;
            return c;       
        }

        public override Point ControlPoint(int i)
        {
            int currentIndex = i;

            for (int j = 0; j < m_CurveArray.Count; j++)
            {
                if (currentIndex < m_CurveArray[j].NumControlPoints)
                {
                    return m_CurveArray[j].ControlPoint(currentIndex);
                }
                currentIndex = currentIndex -m_CurveArray[j].NumControlPoints + 1;
            }
            return null;
        }

        public override int NumControlPoints
        {
            get
            {
                int count = 0;
                for (int i = 0; i < m_CurveArray.Count; i++)
                {
                    count += m_CurveArray[i].NumControlPoints - 1;
                }
                return count;
            }
        }

        public override bool IsPlanar()
        {
            double[] controlPoint = new double[NumControlPoints * ( m_Dimensions)];
            for (int i = 0; i < controlPoint.Length; i += m_Dimensions)
            {
                Point p = ControlPoint(i / m_Dimensions);
                controlPoint[i] = p.X;
                controlPoint[i + 1] = p.Y;
                controlPoint[i + 2] = p.Z;
            }
            return Plane.SamePlane(controlPoint, m_Dimensions);
        }

        public override void Project(Plane p)
        {
            base.Project(p);
            m_CurveArray.Project(p);
        }

        public override void Mirror(Plane p)
        {
            base.Mirror(p);
            m_CurveArray.Mirror(p);
        }

        public override void Transform(Transform t)
        {
            base.Transform(t);
            m_CurveArray.Transform(t);
        }

        public override void Translate(Vector v)
        {
            base.Translate(v);
            m_CurveArray.Translate(v);
        }

        public override void Update()
        {
            base.Update();
            m_CurveArray.Update();
        }

        public override Curve Flip()
        {
            for (int i = 0; i < m_CurveArray.Count; i++)
            {
                m_CurveArray[i].Flip();
            }
            return base.Flip();
        }
    }
}
