using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHB = BH.oM.Base;
using BH.oM.Structural.Properties;
using BH.oM.Geometry;

namespace BH.oM.Structural.Elements
{
    public class FEMesh : BHB.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PanelProperty PanelProperty { get; set; }

        public List<Node> Nodes { get; set; }

        public List<FEFace> Faces { get; set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public FEMesh()
        {
            Nodes = new List<Node>();
            Faces = new List<FEFace>();
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/



        /***************************************************/
        /**** IBHoMGeometry Interface                   ****/
        /***************************************************/

        public AreaElementType GetElementType()
        {
            return AreaElementType.Mesh;
        }


        /***************************************************/
        /**** Override BHoMObject                       ****/
        /***************************************************/

        public override IBHoMGeometry GetGeometry()
        {
            IEnumerable<Point> points = Nodes.Select(x => x.Point);
            IEnumerable<Geometry.Face> faces = Faces.Select(x => x.GetGeometryFace());

            return new Mesh(points, faces);
        }
    }
}
