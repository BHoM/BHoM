using System;
using BH.oM.Geometry;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Graphics
{
    public class SVGObject : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMGeometry> Geometry { get; set; } = null;

        public SVGStyle Style { get; set; } = new SVGStyle();
        
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGObject() { }

        /***************************************************/

        public SVGObject(List<IBHoMGeometry> geometry, SVGStyle style = null)
        {
            Geometry = geometry;
            Style = style;
        }
    }
}
