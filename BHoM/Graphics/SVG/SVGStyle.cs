﻿using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics
{
    [Serializable] public class SVGStyle : BHoMObject
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
        public string StrokeColor { get; set; } = "black";

        /// <summary>
        /// fill
        /// </summary>
        public string FillColor { get; set; } = "none";

        /// <summary>
        /// stroke-opacity
        /// </summary>
        public double StrokeOpacity { get; set; } = 1;

        /// <summary>
        /// fill-opacity
        /// </summary>
        public double FillOpacity { get; set; } = 1;

        /// <summary>
        /// stroke-dasharray
        /// </summary>
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
