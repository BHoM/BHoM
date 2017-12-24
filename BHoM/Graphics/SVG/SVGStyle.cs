using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Graphics
{
    public class SVGStyle : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double StrokeWidth { get; set; } = 1; 

        public string StrokeColor { get; set; } = "black";

        public string FillColor { get; set; } = "none";

        public double StrokeOpacity { get; set; } = 1;

        public double FillOpacity { get; set; } = 1;

        public List<double> StrokeDash { get; set; } = new List<double>() {0}; 


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SVGStyle() { }

        /***************************************************/

        public SVGStyle(double strokeWidth, string strokeColor, string fillColor, double strokeOpacity, double fillOpacity, List<double> strokeDash)
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
