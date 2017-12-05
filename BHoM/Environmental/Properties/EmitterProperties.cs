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
        public double Emitter_circuitTemp { get; set; } = 0.0;
        public double Emitter_dh { get; set; } = 0.0;
        public double Emitter_dT { get; set; } = 0.0;
        public double Emitter_supplyT { get; set; } = 0.0;
        public string EmitterComments { get; set; } = "";

        //controls for emitters
        public double EmitterMaxOutsideTemperature { get; set; } = 0.0;
        public double EmitterOffOutsideTemperature { get; set; } = 0.0;

        //heat outoput properties
        public double EmitterRadiantProportion { get; set; } = 0.0;
        public double EmitterViewCoefficient { get; set; } = 0.0;

        public string EmitterType { get; set; } = "";
        public string EmitterTypeDIN { get; set; } = "";


                
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EmitterProperties() { }
    }
}
