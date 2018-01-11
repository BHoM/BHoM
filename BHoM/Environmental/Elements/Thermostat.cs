using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Thermostat object for environmental models.
    /// </summary>
    public class Thermostat : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double UpperLimit { get; set; } = 0.0;
        public double LoweLimit { get; set; } = 0.0;
        public double HumidityUpperLimit { get; set; } = 0.0;
        public double HumidityLowerLimit { get; set; } = 0.0;


    }

}
