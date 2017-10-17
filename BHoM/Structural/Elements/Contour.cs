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
    public class Contour : BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ISurface Surface { get; set; } = null;

        public PanelProperty PanelProperty { get; set; } = null;

        public SurfaceConstraint PlanarSpring { get; set; } = null;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Contour() { }

        /***************************************************/

        public Contour(ISurface surface)
        {
            Surface = surface;
        }

    }
}

        ///***************************************************/
        ///**** Override BHoMObject                       ****/
        ///***************************************************/


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

