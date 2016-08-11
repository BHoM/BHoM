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

        private Group<Curve> m_ExteriorEdges;
        private Group<Curve> m_InteriorEdges;

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

        public PanelProperty PanelProperty { get; set; }

        public Materials.Material Material { get; set; }

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

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary></summary>
        public override BHoM.Geometry.GeometryBase GetGeometry()
        {
            Group<Curve> edges = new Group<Curve>();
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
                Group<Curve> group = new Group<Curve>();
                group.Add(curve);
                SetEdges(group);
            }
            else if (geometry is Group<Curve>)
            {
                SetEdges(geometry as Group<Curve>);
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
