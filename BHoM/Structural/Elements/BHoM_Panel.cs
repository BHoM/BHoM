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

        private Group<Curve> m_Edges;

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


        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        [DefaultValue(null)]
        public Group<Curve> Edges
        {
            get
            {
                return m_Edges;
            }
            set
            {
                if (value != null)
                {
                    List<Curve> curve = Curve.Join(value);
                    m_Edges = new Group<Curve>();
                    for (int i = 0; i < curve.Count; i++)
                    {
                        m_Edges.Add(curve[i]);
                    }
                }
                //m_Edges = value;
            }
        }

        public Curve External_Contour
        {
            get
            {
                if (m_Edges != null)
                    return m_Edges[0];
                else return null;
            }
        }

        public List<Curve> Internal_Contours
        {
            get
            {
                List<Curve> internalCurves = new List<Curve>();
                for (int i = 1; i < m_Edges.Count; i++)
                {
                    internalCurves.Add(m_Edges[i]);
                }
                return internalCurves;
            }
        }

        [DefaultValue(null)]
        public ThicknessProperty ThicknessProperty { get; set; }

        [DefaultValue(null)]
        public Materials.Material Material { get; set; }

        //public bool IsValid() { return Edges != null; }


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
            Edges = edges;
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
                Edges = group;
            }
            else if (geometry is Group<Curve>)
            {
                Edges = geometry as Group<Curve>;
            }
        }
    }
}
