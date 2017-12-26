using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.Generic;

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
    }
}
