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

        public IBHoMGeometry Geometry { get; set; } = default(IBHoMGeometry);

        public string Style { get; set; } = "";

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGObject() { }

        /***************************************************/

        public SVGObject(IBHoMGeometry geometry, string style)
        {
            Geometry = geometry;
            Style = style;
        }
    }
}
