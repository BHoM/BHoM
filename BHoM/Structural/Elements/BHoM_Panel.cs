using BHoM.Global;
using BHoM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BHoM.Structural
{
    /// <summary>
    /// Panel Class
    /// </summary>
    public class Panel : BHoMObject
    {

        /////////////////
        ////Properties///
        /////////////////

        private Node m_N1;
        private Node m_N2;
        private Node m_N3;
        private Node m_N4;

        private Node[] m_vertices = new Node[4];


        [DefaultValue(null)]
        public Node N1
        {
            get
            {
                return m_N1;
            }
            set
            {
                if (value != null)
                {
                    m_N1 = value;
                    m_vertices[0] = value;
                }
            }
        }

        [DefaultValue(null)]
        public Node N2
        {
            get
            {
                return m_N2;
            }
            set
            {
                if (value != null)
                {
                    m_N2 = value;
                    m_vertices[1] = value;
                }
            }
        }

        [DefaultValue(null)]
        public Node N3
        {
            get
            {
                return m_N3;
            }
            set
            {
                if (value != null)
                {
                    m_N3 = value;
                    m_vertices[2] = value;
                }
            }
        }

        [DefaultValue(null)]
        public Node N4
        {
            get
            {
                return m_N4;
            }
            set
            {
                if (value != null)
                {
                    m_N4 = value;
                    m_vertices[3] = value;
                }
            }
        }

        public List<Node> Vertices
        {
            get
            {
                return m_vertices.ToList().Where(x => x != null).ToList(); ;
            }
        }



        private Group<Curve> m_ExteriorEdges;
        private Group<Curve> m_InteriorEdges;

        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        [DefaultValue(null)]
        public Group<Curve> Edges
        {
            private get
            {
                Group<Curve> edges = new Group<Curve>();
                edges.AddRange(m_ExteriorEdges);
                edges.AddRange(m_InteriorEdges);
                return edges;
            }
            set
            {
                SetEdges(value);
            }
        }

        private static bool IsInside(Curve c, List<Curve> crvs)
        {
            for (int i = 0; i < crvs.Count; i++)
            {
                if (!crvs[i].Equals(c))
                {
                    if (crvs[i].ContainsCurve(c))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void SetEdges(Group<Curve> curves)
        {
            m_InteriorEdges = new Group<Curve>();
            m_ExteriorEdges = new Group<Curve>();
            List<Curve> crvs = Curve.Join(curves);
            crvs.Sort(delegate (Curve c1, Curve c2)
            {
                return c2.Length.CompareTo(c1.Length);
            });
       
            for (int i = 0; i < crvs.Count; i++)
            {
                if (crvs[i].IsClosed())
                {
                    if (IsInside(crvs[i], crvs))
                    {
                        m_InteriorEdges.Add(crvs[i]);
                    }
                    else
                    {
                        m_ExteriorEdges.Add(crvs[i]);
                    }
                }
            } 
        }

        public Group<Curve> External_Contours
        {
            get
            {
                return m_ExteriorEdges;
            }
            set
            {
                m_ExteriorEdges = value;
            }
        }

        public Group<Curve> Internal_Contours
        {
            get
            {
                return m_InteriorEdges;
            }
            set
            {
                m_InteriorEdges = value;
            }
        }

        [DefaultValue(null)]
        public ThicknessProperty ThicknessProperty { get; set; }

        [DefaultValue(null)]
        public Materials.Material Material { get; set; }


        public bool IsValid() { return m_ExteriorEdges != null; }



        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        internal Panel() { }

        /// <summary>
        /// Creates a panel object from a group of curve objects.Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name = "edges" ></ param >
        /// < param name="number"></param>
        public Panel(Group<Curve> edges)
        {
            SetEdges(edges);
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(List<Curve> edges)
        {
            SetEdges(new Group<Curve>(edges));
        }

        /////////////
        //METHODS////
        /////////////

        /// <summary></summary>
        public override BHoM.Geometry.GeometryBase GetGeometry()
        {
            return Edges;
        }

        /// <summary></summary>
        public override void SetGeometry(GeometryBase geometry)
        {
            if (geometry is Curve)
            {
                Curve curve = geometry as Curve;
                Group<Curve> group = new Group<Curve>();
                group.Add(curve);
                SetEdges(group);
            }
            else if (geometry is Group<Curve>)
            {
                SetEdges(geometry as Group<Curve>);
            }
        }
    }
}
