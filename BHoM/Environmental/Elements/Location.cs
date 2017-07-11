using BHG = BH.oM.Geometry;
using BHB = BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Location objects.
    /// </summary>
    public class Location : BHB.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Elevetion { get; set; }

        public double AngleFromTrueNorth { get; set; }

        public string Adress { get; set; }

    }

}