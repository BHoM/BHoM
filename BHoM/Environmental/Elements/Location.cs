using BH.oM.Geometry;
using BH.oM.Base;
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
    public class Location : BHoMObject
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