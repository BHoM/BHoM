using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class Group : Group<GeometryBase> { }

    public class Group<T> : GeometryBase where T : GeometryBase 
    {
        private List<T> m_Geometry;
        private BoundingBox m_Bounds;

        public Group()
        {
            m_Geometry = new List<T>();
        }

        public Group(List<T> geometry)
        {
            m_Geometry = geometry;
        }

        public void Add(T geometry)
        {
            m_Geometry.Add(geometry);
        }

        public T this[int i]
        {
            get
            {
                return m_Geometry.Count > i ? m_Geometry[i] : default(T);
            }
        }


        public override BoundingBox Bounds()
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

        public Group<T> DuplicateGroup()
        {
            Group<T> group = new Group<T>();
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                group.m_Geometry.Add((T)m_Geometry[i].Duplicate());
            }
            return group;
        }

        public override GeometryBase Duplicate()
        {
            return DuplicateGroup();
        }

        public override void Mirror(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Mirror(p);
            }
            Update();
        }

        public override void Project(Plane p)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Project(p);
            }
            Update();
        }

        public override void Transform(Transform t)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Transform(t);
            }
            Update();
        }

        public override void Translate(Vector v)
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Translate(v);
            }
            Update();
        }

        public override void Update()
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Update();
            }
            m_Bounds = null;
        }

        public override string ToJSON()
        {
            throw new NotImplementedException();
        }

        public GeometryBase FromJSON()
        {
            throw new NotImplementedException();
        }
    }
}
