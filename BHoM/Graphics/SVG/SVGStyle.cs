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
        public List<double> StrokeDash { get; set; } = new List<double>() {0}; 

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGStyle() { }

        /***************************************************/

        public SVGStyle(double strokeWidth = 0, string strokeColor = "", string fillColor = "", double strokeOpacity = 1, double fillOpacity = 0, List<double> strokeDash = null)
        {
            StrokeWidth = strokeWidth;
            StrokeColor = strokeColor;
            FillColor = fillColor;
            StrokeOpacity = strokeOpacity;
            FillOpacity = fillOpacity;
            StrokeDash = strokeDash;
        }
    }
}
