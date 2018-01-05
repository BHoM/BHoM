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
    class Thermostat : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double ThermostatControlRange { get; set; } = 0; //this is Temp 0 degC as default
        public bool ThermostatProportionalControl { get; set; } = false;

        
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Thermostat() { }
    }
}