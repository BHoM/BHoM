using System;
using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class Building : BHoMObject, IBuilding
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Elevation { get; set; } = 0.0;

        public Point Location { get; set; } = new Point();

        /***************************************************/
    }
}
