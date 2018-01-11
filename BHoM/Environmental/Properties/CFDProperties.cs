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

    public class CFDProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        // surface properies of each invidual Building Element

        //CFD parameters
        public bool BoundaryInlet { get; set; } = true;
        public double BoundaryInletTemperature { get; set; } = 0.0;
        public double BoundaryInletVelocityVec { get; set; } = 0.0;
        public double BoundaryInletVolFlowRate { get; set; } = 0.0;
        public bool BoundaryOutlet { get; set; } = true;
        public double BoundaryOutletPressure { get; set; } = 0.0;
        public double BoundaryOutletTemperature { get; set; } = 0.0;
        public bool BoundaryWall { get; set; } = true;
        public double BoundaryWallTemperature { get; set; } = 0.0;

    }
}