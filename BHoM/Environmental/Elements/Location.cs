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

        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Elevation { get; set; } = 0.0;
       
                
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        
        public Location() { }

        /***************************************************/

        public Location(string placename, double latitude, double longitude, double elevation)
        {
            Name = placename;
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
        }
             
    }

}