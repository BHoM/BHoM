using System;
using BH.oM.Geometry;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class SVGObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string geometry { get; set; } = "";

        public BH.oM.Geometry.BoundingBox boundingBox { get; set; } = new BH.oM.Geometry.BoundingBox();

        public string style { get; set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGObject() { }

        //public BH.oM.Geometry.IBHoMGeometry geometry { get; set; } = new BH.oM.Geometry.IBHoMGeometry();

        /***************************************************/

        //public SVGObject() { }

    }
}
