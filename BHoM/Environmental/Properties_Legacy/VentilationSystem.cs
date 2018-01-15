using BH.oM.Geometry;
using BH.oM.Base;
using BHE = BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Properties_Legacy
{
    /// <summary>
    /// Ventilation System Properties
    /// </summary>
  
    class VentilationSystem : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double VentSystem_dh { get; set; } = 0.0;
        public double VentSystem_dT { get; set; } = 0.0;
        public double VentSystem_supplyT { get; set; } = 0.0;
        public string VentSystemComments { get; set; } = "";
        public double VentSystemOSA_TSA { get; set; } = 0.0;
        public string VentSystemType { get; set; } = "";
        public string VentSystemTypeDIN { get; set; } = "";


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public VentilationSystem() { }
 
    }
}
