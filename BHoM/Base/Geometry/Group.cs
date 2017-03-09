using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    public class Group : Group<GeometryBase> { }

    public interface IGroup
    {
        IEnumerable<GeometryBase> Objects { get; }
        Type ObjectType { get; }

        Group<T> Cast<T>() where T : GeometryBase;
    }

    public class Group<T> : GeometryBase, IEnumerable<T>, IEnumerable, IGroup where T : GeometryBase 
    {
        private List<T> m_Geometry;
        private BoundingBox m_Bounds;

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Group;
            }
        }

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

        public void AddRange(IEnumerable<T> geometry)
        {
            m_Geometry.AddRange(geometry);
        }

        public List<T> Geometry { get { return m_Geometry; } set { m_Geometry = value; } }

        public T this[int i]
        {
            get
            {
                return m_Geometry.Count > i ? m_Geometry[i] : default(T);
            }
        }

        public int Count
        {
            get
            {
                return m_Geometry.Count;
            }
        }

        public IEnumerable<GeometryBase> Objects
        {
            get
            {
                return m_Geometry.Cast<GeometryBase>();
            }
        }

        public Type ObjectType
        {
            get
            {
                return typeof(T);
            }
        }

        public override BoundingBox Bounds()
        {
            if (m_Bounds == null)
            {
                if (m_Geometry.Count != 0)
                {
                    m_Bounds = m_Geometry[0].Bounds();
                    for (int i = 1; i < m_Geometry.Count; i++)
                    {
                        m_Bounds = BoundingBox.Merge(m_Bounds, m_Geometry[i].Bounds());
                    }
                }
            }
            return m_Bounds;           
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

        public override void Update()
        {
            for (int i = 0; i < m_Geometry.Count; i++)
            {
                m_Geometry[i].Update();
            }
            m_Bounds = null;
        }     

        public IEnumerator<T> GetEnumerator()
        {
            return m_Geometry.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Geometry.GetEnumerator();
        }
        
        public Group<T1> Cast<T1>() where T1 : GeometryBase
        {
            return new Group<T1>(m_Geometry.Cast<T1>().ToList());
        }
    }
}
