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
    /// Building Properties
    /// </summary>

    class EmitterProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        //design properties
        public double CircuitTemp { get; set; } = 0.0;
        public double EntalpyDifference { get; set; } = 0.0;
        public double TemperatureDifference { get; set; } = 0.0;
        public double SupplyT { get; set; } = 0.0;
        public string Comments { get; set; } = "";

        //controls for emitters
        public double MaxOutsideTemperature { get; set; } = 0.0;
        public double OffOutsideTemperature { get; set; } = 0.0;

        //heat outoput properties
        public double RadiantProportion { get; set; } = 0.0;
        public double ViewCoefficient { get; set; } = 0.0;

        public string Type { get; set; } = "";
        public string TypeDIN { get; set; } = "";


                
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EmitterProperties() { }
    }
}
