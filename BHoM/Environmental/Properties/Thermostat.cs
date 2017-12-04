using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Properties
{
    /// <summary>
    /// Thermostat Properties
    /// </summary>
    class Thermostat
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public bool ThermostatControlRange { get; set; } = true; //Or false as default?;
        public bool ThermostatProportionalControl { get; set; } = true; //Or false as default?;

        
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Thermostat() { }
    }
}