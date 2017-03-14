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
    public class Panel : BHoMObject, IAreaElement
    {

        /////////////////
        ////Properties///
        /////////////////

        private BHoM.Geometry.Brep m_Geometry;

        private List<Face> m_Faces;
        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        public BHoM.Geometry.Group<Curve> GetEdges()
        {
            return m_Geometry.GetExternalEdges();
        }

        public Brep Geometry
        {
            get
            {
                return m_Geometry;
            }
            set
            {
                m_Geometry = value;
            }
        }


        public List<Face> GetMeshFaces { get { return m_Faces; } }

       
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

        public AreaElementType ElementType
        {
            get
            {
                return AreaElementType.Panel;
            }
        }

        public bool IsValid() { return m_Geometry != null; }


        ////////////////////
        ////CONSTRUCTORS////
        ////////////////////

        public Panel()
        {
            m_Faces = new List<Face>();
        }

        /// <summary>
        /// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="number"></param>
        public Panel(Brep boundary)
        {
            m_Geometry = boundary;
        }

        ///////////////
        ////METHODS////
        ///////////////

        /// <summary></summary>
        public override BHoM.Geometry.BHoMGeometry GetGeometry()
        {
            return m_Geometry;
        }

        /// <summary></summary>
        public override void SetGeometry(BHoMGeometry geometry)
        {
            if (typeof(Brep).IsAssignableFrom(geometry.GetType()))
            {
                m_Geometry = geometry as Brep;
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
            foreach (Curve edge in m_Geometry.GetExternalEdges())
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
