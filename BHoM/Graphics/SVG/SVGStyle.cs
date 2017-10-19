using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    public class SVGStyle : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Style { get; set; } = "";

        /// <summary>
        /// stroke-width
        /// </summary>
        public double StrokeWidth { get; set; } = 1; 

        /// <summary>
        /// stroke
        /// </summary>
        public string StrokeColor { get; set; } = "";

        /// <summary>
        /// fill
        /// </summary>
        public string FillColor { get; set; } = "";

        /// <summary>
        /// stroke-opacity
        /// </summary>
        public double StrokeOpacity { get; set; } = 1;

        /// <summary>
        /// fill-opacity
        /// </summary>
        public double FillOpacity { get; set; } = 0;

        /// <summary>
        /// stroke-dasharray
        /// </summary>
        public double StrokeDash { get; set; } = 0; 

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGStyle() { }

        /***************************************************/

        public SVGStyle(string style)
        {
            Style = style;
        }
    }
}
