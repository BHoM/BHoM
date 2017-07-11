using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BH.oM.Geometry
{
    public class GeometryGroup<T> : IBHoMGeometry  where T: IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<T> Elements = new List<T>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeometryGroup() { }

        /***************************************************/

        public GeometryGroup(IEnumerable<T> elements)
        {
            Elements = elements.ToList();
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public GeometryType GetGeometryType()
        {
            return GeometryType.Group;
        }

        /***************************************************/

        public BoundingBox GetBounds()
        {
            if (Elements.Count == 0)
                return null;

            BoundingBox box = Elements[0].GetBounds();
            for (int i = 1; i < Elements.Count; i++)
                box += Elements[i].GetBounds();

            return box;
        }

        /***************************************************/

        public object Clone()
        {
            return new GeometryGroup<T>(Elements.Select(x => (T)x.Clone()));
        }

        /***************************************************/

        public IBHoMGeometry GetTranslated(Vector t)
        {
            return new GeometryGroup<T>(Elements.Select(x =>(T) x.GetTranslated(t)));
        }



        //    public interface IGroup
        //    {
        //        IEnumerable<IBHoMGeometry> Objects { get; }
        //        Type ObjectType { get; }

        //        Group<T> Cast<T>() where T : IBHoMGeometry;
        //    }

        //    public class Group<T> : IBHoMGeometry, IEnumerable<T>, IEnumerable, IGroup where T : IBHoMGeometry 
        //    {
        //        private List<T> m_Geometry;
        //        private BoundingBox m_Bounds;

        //        public override GeometryType GetGeometryType()
        //        {
        //            return GeometryType.Group;
        //        }

        //        public Group()
        //        {
        //            m_Geometry = new List<T>();
        //        }

        //        public Group(List<T> geometry)
        //        {
        //            m_Geometry = geometry;
        //        }

        //        public void Add(T geometry)
        //        {
        //            m_Geometry.Add(geometry);
        //        }

        //        public void AddRange(IEnumerable<T> geometry)
        //        {
        //            m_Geometry.AddRange(geometry);
        //        }

        //        public List<T> Geometry { get { return m_Geometry; } set { m_Geometry = value; } }

        //        public T this[int i]
        //        {
        //            get
        //            {
        //                return m_Geometry.Count > i ? m_Geometry[i] : default(T);
        //            }
        //        }

        //        public int Count
        //        {
        //            get
        //            {
        //                return m_Geometry.Count;
        //            }
        //        }

        //        public IEnumerable<IBHoMGeometry> Objects
        //        {
        //            get
        //            {
        //                return m_Geometry.Cast<IBHoMGeometry>();
        //            }
        //        }

        //        public Type ObjectType
        //        {
        //            get
        //            {
        //                return typeof(T);
        //            }
        //        }

        //        public override BoundingBox GetBounds()
        //        {
        //            if (m_Bounds == null)
        //            {
        //                if (m_Geometry.Count != 0)
        //                {
        //                    m_Bounds = m_Geometry[0].GetBounds();
        //                    for (int i = 1; i < m_Geometry.Count; i++)
        //                    {
        //                        m_Bounds = BoundingBox.Merge(m_Bounds, m_Geometry[i].GetBounds());
        //                    }
        //                }
        //            }
        //            return m_Bounds;           
        //        }

        //        public Group<T> DuplicateGroup()
        //        {
        //            Group<T> group = new Group<T>();
        //            for (int i = 0; i < m_Geometry.Count; i++)
        //            {
        //                group.m_Geometry.Add((T)m_Geometry[i].Duplicate());
        //            }
        //            return group;
        //        }

        //        public override IBHoMGeometry Duplicate()
        //        {
        //            return DuplicateGroup();
        //        }

        //        //public override void Update()
        //        //{
        //        //    for (int i = 0; i < m_Geometry.Count; i++)
        //        //    {
        //        //        m_Geometry[i].Update();
        //        //    }
        //        //    m_Bounds = null;
        //        //}     

        //        public IEnumerator<T> GetEnumerator()
        //        {
        //            return m_Geometry.GetEnumerator();
        //        }

        //        IEnumerator IEnumerable.GetEnumerator()
        //        {
        //            return m_Geometry.GetEnumerator();
        //        }

        //        public Group<T1> Cast<T1>() where T1 : IBHoMGeometry
        //        {
        //            return new Group<T1>(m_Geometry.Cast<T1>().ToList());
        //        }
    }
}
