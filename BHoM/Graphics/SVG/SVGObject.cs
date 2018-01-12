using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Graphics
{
    public class SVGObject : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMGeometry> Shapes { get; set; } = null;

        public SVGStyle Style { get; set; } = new SVGStyle();
        

        /***************************************************/
    }
}
