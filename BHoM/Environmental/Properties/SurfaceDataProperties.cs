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
    
    class SurfaceDataProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        // surface properies of each invidual Building Element

        //CFD
        public bool CFDBoundaryInlet { get; set; } = true;
        public double CFDBoundaryInletTemperature { get; set; } = 0.0;
        public double CFDBoundaryInletVelocityVec { get; set; } = 0.0;
        public double CFDBoundaryInletVolFlowRate { get; set; } = 0.0;
        public bool CFDBoundaryOutlet { get; set; } = true;
        public double CFDBoundaryOutletPressure { get; set; } = 0.0;
        public double CFDBoundaryOutletTemperature { get; set; } = 0.0;
        public bool CFDBoundaryWall { get; set; } = true;
        public double CFDBoundaryWallTemperature { get; set; } = 0.0;

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