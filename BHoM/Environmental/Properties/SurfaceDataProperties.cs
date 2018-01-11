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
    
    public class SurfaceDataProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        // surface properies of each invidual Building Element

        //Detail Surface Results
        public double ApertureFlowIn { get; set; } = 0.0;
        public double ApertureFlowOut { get; set; } = 0.0;
        public double ApertureOpening { get; set; } = 0.0;
        public double ExternalCondensation { get; set; } = 0.0;
        public double ExternalConduction { get; set; } = 0.0;
        public double ExternalConvection { get; set; } = 0.0;
        public double ExternalLongWave { get; set; } = 0.0;
        public double ExternalSolar { get; set; } = 0.0;
        public double ExternalTemperature { get; set; } = 0.0;
        public double InternalCondensation { get; set; } = 0.0;
        public double InternalConduction { get; set; } = 0.0;
        public double InternalConvection { get; set; } = 0.0;
        public double InternalLongWave { get; set; } = 0.0;
        public double InternalSolar { get; set; } = 0.0;
        public double InternalTemperature { get; set; } = 0.0;
        public double InterstitialCondensation { get; set; } = 0.0;

        //boolean to toggle detail surface output
        public bool SurfaceOutput { get; set; } = true;
        

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SurfaceDataProperties() { }
    }
}