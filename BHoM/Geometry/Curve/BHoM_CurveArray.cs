using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class CurveArray : IGeometry
    {
        private List<Curve> m_Curves;

        public BoundingBox Bounds()
        {
            Point max = m_Curves[0].Max;
            Point min = m_Curves[0].Min;
            for (int i = 1; i < m_Curves.Count;i++)
            {
                max = Point.Max(max, m_Curves[i].Max);
                min = Point.Min(min, m_Curves[i].Min);
            }
            return new BoundingBox(min, max);
        }

        public Curve this[int i]
        {
            get
            {
                return m_Curves[i];
            }
        }

        public int Count
        {
            get
            {
                return m_Curves.Count;
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CurveArray(List<Curve> crvs)
        {
            m_Curves = crvs;
        }

        public void Transform(Transform t)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Transform(t);
            }
        }

        public void Translate(Vector v)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Translate(v);
            }
        }

        public void Mirror(Plane p)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Mirror(p);
            }
        }

        public void Project(Plane p)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Project(p);
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public IGeometry Duplicate()
        {
            return Copy();
        }

        public CurveArray Copy()
        {
            List<Curve> crvs = new List<Curve>();
            for (int i = 0; i < m_Curves.Count; i++)
            {
                crvs.Add(m_Curves[i].DuplicateCurve());
            }
            return new CurveArray(crvs);
        }
    }
}
