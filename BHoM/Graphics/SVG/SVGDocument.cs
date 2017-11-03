using BH.oM.Base;
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class SVGDocument : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<SVGObject> SVGObjects { get; set; } = new List<SVGObject>();

        public BoundingBox Canvas { get; set; } = new BoundingBox();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGDocument() { }

        /***************************************************/

        public SVGDocument(List<SVGObject> svgObjects, BoundingBox canvas)
        {
            SVGObjects = svgObjects;
            Canvas = canvas;
        }
    }
}
