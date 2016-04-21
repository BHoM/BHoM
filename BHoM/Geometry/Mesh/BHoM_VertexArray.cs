using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class VertexArray :IGeometry
    {
        List<double[]> m_Array;
        private double[] m_Max;
        private double[] m_Min;

        internal VertexArray()
        {
            m_Array = new List<double[]>();
        }

        public BoundingBox Bounds()
        {
                if (m_Max == null || m_Min == null) Update();
                return new BoundingBox(new Point(m_Min), new Point(m_Max));
            
        }

        public Point this[int i]
        {
            get
            {
                return i < m_Array.Count ? new Point(m_Array[i]) : null;
            }
        }

        internal double[] GetVertex(int i)
        {
            return m_Array[i];
        }

        public int Count
        {
            get
            {
                return m_Array.Count;
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Point p)
        {
            m_Array.Add(p);
        }

        public void Add(List<Point> p)
        {
            for (int i = 0; i < p.Count; i++)
            {
                m_Array.Add(p[i]);
            }
        }

        public IGeometry Duplicate()
        {
            return Copy();
        }

        public VertexArray Copy()
        {
            VertexArray array = new VertexArray();

            for (int i = 0; i < m_Array.Count; i++)
            {
                array.m_Array.Add(Common.Utils.Copy<double>(m_Array[i]));
            }
            array.m_Max = Common.Utils.Copy<double>(m_Max);
            array.m_Min = Common.Utils.Copy<double>(m_Min);
            return array;
        }

        public void Mirror(Plane p)
        {
            for (int i = 0; i < m_Array.Count; i++)
            {
                double[] projVec = p.ProjectionVectors(m_Array[i], 2);
                m_Array[i] = VectorUtils.Add(m_Array[i], projVec);
            }
        }

        public void Project(Plane p)
        {
            for (int i = 0; i < m_Array.Count; i++)
            {
                double[] projVec = p.ProjectionVectors(m_Array[i]);
                m_Array[i] = VectorUtils.Add(m_Array[i], projVec);
            }
        }

        public void Transform(Transform t)
        {
            for (int i = 0; i < m_Array.Count; i++)
            {
                m_Array[i] = VectorUtils.Multiply(t, m_Array[i]);
            }
        }

        public void Translate(Vector v)
        {
            for (int i = 0; i < m_Array.Count; i++)
            {
                m_Array[i] = VectorUtils.Add(v, m_Array[i]);
            }
        }

        public void Update()
        {
            for (int i = 0; i < m_Array.Count; i++)
            {
                m_Max = VectorUtils.Max(m_Max, m_Array[i]);
                m_Min = VectorUtils.Max(m_Min, m_Array[i]);
            }
        }
    }
}
