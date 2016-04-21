using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Group : IGeometry
    {
        private List<IGeometry> m_Geometry;
        private BoundingBox m_Bounds;

        public Group()
        {
            m_Geometry = new List<IGeometry>();
        }

        public Group(List<IGeometry> geometry)
        {
            m_Geometry = geometry;
        }

        public void Add(IGeometry geometry)
        {
            m_Geometry.Add(geometry);
        }

        public BoundingBox Bounds()
        {
            if (m_Bounds == null)
            {
                m_Bounds = m_Geometry[0].Bounds();
                for (int i = 1; i < m_Geometry.Count; i++)
                {
                    m_Bounds = BoundingBox.Merge(m_Bounds, m_Geometry[i].Bounds());
                }
            }
            return m_Bounds;           
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGeometry Duplicate()
        {
            Group group = new Group();
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                group.m_Geometry.Add(m_Geometry[i].Duplicate());
            }
            return group;
        }

        public void Mirror(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Mirror(p);
            }
            Update();
        }

        public void Project(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Project(p);
            }
            Update();
        }

        public void Transform(Transform t)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Transform(t);
            }
            Update();
        }

        public void Translate(Vector v)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Translate(v);
            }
            Update();
        }

        public void Update()
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Update();
            }
            m_Bounds = null;
        }
    }
}
