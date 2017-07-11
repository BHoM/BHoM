using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;


namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Panel Class
    /// </summary>
    public class Panel : BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Face> MeshFaces { get; set; } = new List<Face>();

        public ISurface Surface { get; set; } = null;

        public Materials.Material Material { get; set; } = null;

        public PanelProperty PanelProperty { get; set; } = null;

        public SurfaceConstraint PlanarSpring { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Panel() { }

        /***************************************************/

        public Panel (ISurface surface)
        {
            Surface = surface;
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        /// <summary>
        /// A group of curves which define the perimeter of panel object
        /// </summary>
        public List<ICurve> GetEdges()
        {
            if (Surface != null)
                return Surface.GetExternalEdges();
            else
                return new List<ICurve>();
        }


        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public AreaElementType GetElementType()
        {
            return AreaElementType.Panel;
        }


        /***************************************************/
        /**** Override BHoMObject                       ****/
        /***************************************************/

        public override IBHoMGeometry GetGeometry()
        {
            return Surface;
        }

        /// <summary></summary>
        public override void SetGeometry(IBHoMGeometry geometry)
        {
            if (typeof(ISurface).IsAssignableFrom(geometry.GetType()))
            {
                Surface = geometry as ISurface;
            }
        }




        //public bool IsValid() { return m_Geometry != null; }


        //////////////////////
        //////CONSTRUCTORS////
        //////////////////////

        //public Panel()
        //{
        //    m_Faces = new List<Face>();
        //}

        ///// <summary>
        ///// Creates a panel object from a group of curve objects. Note: Curves must be able to join together to form a single closed curve or panel will be invalid
        ///// </summary>
        ///// <param name="edges"></param>
        ///// <param name="number"></param>
        //public Panel(Brep boundary)
        //{
        //    m_Geometry = boundary;
        //}

        /////////////////
        //////METHODS////
        /////////////////

        ///// <summary></summary>
       


        ///// <summary>
        ///// assumes ordered 3 or 4 sided panel
        ///// </summary>
        ///// <returns></returns>
        //public bool MeshAsSingleFace()
        //{
        //    List<Node> nodes = new List<Node>();
        //    Face face;
        //    foreach (Curve edge in m_Geometry.GetExternalEdges())
        //        nodes.Add(new Node(edge.StartPoint));

        //    switch (nodes.Count)
        //    {
        //        case 3:
        //            face = new Face(nodes[0], nodes[1], nodes[2]);
        //            break;
        //        case 4:
        //            face = new Face(nodes[0], nodes[1], nodes[2], nodes[3]);
        //            break;
        //        default:
        //            return false;
        //    }

        //    m_Faces.Add(face);

        //    return true;
        //}
    }
}
