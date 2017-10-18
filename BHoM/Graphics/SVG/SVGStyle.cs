using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class SVGStyle
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string style { get; set; } = "";

        public double strokeWidth { get; set; } = 1; //stroke-width
        public string strokeColor { get; set; } = ""; //stroke
        public string fillColor { get; set; } = ""; //fill
        public double strokeOpacity { get; set; } = 1; //stroke-opacity {0-1} 
        public double fillOpacity { get; set; } = 0; //fill-opacity {0-1}
        public double strokeDash { get; set; } = 0; //stroke-dasharray (takes several inputs)

        // Name
        // Stroke Gap
        // id

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGStyle() { }

        /***************************************************/

        //public SVGStyle() { }

    }
}
