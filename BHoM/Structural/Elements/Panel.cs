using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BHoM.Base;
using BHoM.Geometry;
using BHoM.Structural.Properties;

namespace BHoM.Structural.Elements
{
    /// <summary>
    /// Panel Class
    /// </summary>
    public class Panel : BHoMObject
    {

        /////////////////
        ////Properties///
        /////////////////

        private BHoM.Geometry.Group<Curve> m_ExteriorEdges;
        private BHoM.Geometry.Group<Curve> m_InteriorEdges;

        private List<Face> m_Faces;
        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        //public Group<Curve> Edges
        //{
        //    private get
        //    {
        //        Group<Curve> edges = new Group<Curve>();
        //        edges.AddRange(m_ExteriorEdges);
        //        edges.AddRange(m_InteriorEdges);
        //        return edges;
        //    }
        //    set
        //    {
        //        SetEdges(value);
        //    }
        //}

        public List<Face> GetMeshFaces { get { return m_Faces; } }

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

        private void SetEdges(BHoM.Geometry.Group<Curve> curves)
        {
            m_InteriorEdges = new BHoM.Geometry.Group<Curve>();
            m_ExteriorEdges = new BHoM.Geometry.Group<Curve>();
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

        public BHoM.Geometry.Group<Curve> External_Contours
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

        [DefaultValue(null)]
        public BHoM.Geometry.Group<Curve> Internal_Contours
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
        public PanelProperty PanelProperty { get; set; }

        [DefaultValue(null)]
        public Materials.Material Material
        {
            get
            {
                if (PanelProperty != null)
                    return PanelProperty.Material;

                return null;
            }
        }

        [DefaultValue(null)]
        public SurfaceConstraint PlanarSpring { get; set; }

        public bool IsValid() { return m_ExteriorEdges != null; }


        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        internal Panel()
        {
            m_Faces = new List<Face>();
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(BHoM.Geometry.Group<Curve> edges)
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
            SetEdges(new BHoM.Geometry.Group<Curve>(edges));
        }

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary></summary>
        public override BHoM.Geometry.GeometryBase GetGeometry()
        {
            BHoM.Geometry.Group<Curve> edges = new BHoM.Geometry.Group<Curve>();
            edges.AddRange(m_ExteriorEdges);
            edges.AddRange(m_InteriorEdges);
            return edges;
        }

        /// <summary></summary>
        public override void SetGeometry(GeometryBase geometry)
        {
            if (geometry is Curve)
            {
                Curve curve = geometry as Curve;
                BHoM.Geometry.Group<Curve> group = new BHoM.Geometry.Group<Curve>();
                group.Add(curve);
                SetEdges(group);
            }
            else if (geometry is BHoM.Geometry.Group<Curve>)
            {
                SetEdges(geometry as BHoM.Geometry.Group<Curve>);
            }
        }


        /// <summary>
        /// assumes ordered 3 or 4 sided panel
        /// </summary>
        /// <returns></returns>
        public bool MeshAsSingleFace()
        {
            List<Node> nodes = new List<Node>();
            Face face;
            foreach (Curve edge in m_ExteriorEdges)
                nodes.Add(new Node(edge.StartPoint));

            switch (nodes.Count)
            {
                case 3:
                    face = new Face(nodes[0], nodes[1], nodes[2]);
                    break;
                case 4:
                    face = new Face(nodes[0], nodes[1], nodes[2], nodes[3]);
                    break;
                default:
                    return false;
            }

            m_Faces.Add(face);

            return true;
        }
    }
}
