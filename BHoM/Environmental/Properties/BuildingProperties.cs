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
    
    class BuildingProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double AirPermeability { get; set; } = 0.0;
        public string NCM_Country { get; set; } = "";
        public bool NCM_IsMainsGasAvailable { get; set; } = false; //Or false as default?
        public double NCMPowerFactorCorrection { get; set; } = 0;
        public string NCMWeatherFile { get; set; } = "";
        public double NorthAngle { get; set; } = 0.0;
        public string WeatherFile { get; set; } = "";

        //public string gbXMLFilePath { get; set; } = "";
        //public string iesFilePath { get; set; } = "";
        //public string MEPBridgeFilePath { get; set; } = "";
        //public string PowerBIFilePath { get; set; } = "";
        //public string RDSFilePath { get; set; } = "";
        //public string SAMDirectory { get; set; } = "";
        //public string T3DFilePath { get; set; } = "";
        //public string TBDFilePath { get; set; } = "";
        //public string TPDFilePath { get; set; } = "";
        //public string TSDFilePath { get; set; } = "";



        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingProperties() { }
    }
}
