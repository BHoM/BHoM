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
    
    public class BuildingProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double AirPermeability { get; set; } = 0.0;
        public string Country { get; set; } = "";
        public bool IsMainsGasAvailable { get; set; } = false;
        public double PowerFactorCorrection { get; set; } = 0;
        public double NorthAngle { get; set; } = 0.0;
        
              

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BuildingProperties() { }
    }
}
