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
        public double SurfaceApertureFlowIn { get; set; } = 0.0;
        public double SurfaceApertureFlowOut { get; set; } = 0.0;
        public double SurfaceApertureOpening { get; set; } = 0.0;
        public double SurfaceExternalCondensation { get; set; } = 0.0;
        public double SurfaceExternalConduction { get; set; } = 0.0;
        public double SurfaceExternalConvection { get; set; } = 0.0;
        public double SurfaceExternalLongWave { get; set; } = 0.0;
        public double SurfaceExternalSolar { get; set; } = 0.0;
        public double SurfaceExternalTemperature { get; set; } = 0.0;
        public double SurfaceInternalCondensation { get; set; } = 0.0;
        public double SurfaceInternalConduction { get; set; } = 0.0;
        public double SurfaceInternalConvection { get; set; } = 0.0;
        public double SurfaceInternalLongWave { get; set; } = 0.0;
        public double SurfaceInternalSolar { get; set; } = 0.0;
        public double SurfaceInternalTemperature { get; set; } = 0.0;
        public double SurfaceInterstitialCondensation { get; set; } = 0.0;

        //boolean to toggle detail surface output
        public bool SurfaceOutput { get; set; } = true;
        

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SurfaceDataProperties() { }
    }
}