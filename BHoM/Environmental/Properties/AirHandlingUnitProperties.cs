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
    /// AHU Properties (before HVAC)
    /// </summary>
    public class AirHandlingUnitProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double AHUAirLeakagePercentage { get; set; } = 0.0;
        public double AHUFrostCoilOffTemp { get; set; } = 0.0;
        public double AHUReheatCoilOffTemp { get; set; } = 0.0;
        public string AHUReference { get; set; } = "";
        public int SystemAHUSpaceSummerTotCoolingPeakHour { get; set; } = 0;
        public double AHUMixCoditionTemp { get; set; } = 0.0;
        public int SystemAHUSpaceWinterHeatingPeakHour { get; set; } = 0;
        public string AHURiserCooling { get; set; } = "";
        public double AHUFrostCoilOnTemp { get; set; } = 0.0;
        public double AHUCoolingCoilFluidTemp { get; set; } = 0.0;
        public double AHUSpecifiedSupplyAirflow { get; set; } = 0.0;
        public string AHUCoolingCoilCalcMethod { get; set; } = "";
        public double AHUSpecifiedReturnAirflow { get; set; } = 0.0;
        public double AHUFrostCoilSensLoad { get; set; } = 0.0;
        public double SystemAHUSpaceLatWinterLoad { get; set; } = 0.0;
        public double AHUCoolingCoilOnTemp { get; set; } = 0.0;
        public double AHUWinterHeatRecoveryOnTemp { get; set; } = 0.0;
        public double AHUHeatRecoverySensEfficiency { get; set; } = 0.0;
        public double AHUNumberOfUnits { get; set; } = 0.0;
        public string AHUCoolingCoilOnEnthalpy { get; set; } = "";
        public double AHUCoolingCoilOnX { get; set; } = 0.0;
        public double SystemAHUSpaceHeatingLoad { get; set; } = 0.0;
        public string AHUDescription { get; set; } = "";
        public double AHUReheatCoilSensLoad { get; set; } = 0.0;
        public double SystemAHUSpaceSensCoolingLoad { get; set; } = 0.0;
        public double AHUCoolingCoilTotalLoad { get; set; } = 0.0;
        public string AHUFreshAirType_OSAorTSA { get; set; } = "";
        public double AHUCoolingCoilSensLoad { get; set; } = 0.0;
        public double AHUCoolingCoilOffRH { get; set; } = 0.0;
        public string AHUPsychrometricURL { get; set; } = "";
        public double AHUSummerDesignTemp { get; set; } = 0.0;
        public double AHUSummerDesignRH { get; set; } = 0.0;
        public double AHUCoolingCoilOffX { get; set; } = 0.0;
        public double AHUWinterSupplyTemp { get; set; } = 0.0;
        public double SystemAHUSpaceTotCoolingLoad { get; set; } = 0.0;
        public string AHURiserHeating { get; set; } = "";
        public double AHUModified { get; set; } = 0.0;
        public double AHUCoolingCoilOnRH { get; set; } = 0.0;
        public double AHUSummerSupplyTemp { get; set; } = 0.0;
        public double SystemAHUSpaceLatCoolingLoad { get; set; } = 0.0;
        public double AHUCoolingCoilOffTemp { get; set; } = 0.0;
        public string AHUCoolingCoilOffEnthalpy { get; set; } = "";
        public double SystemAHUSpaceWinterSensTotRatio { get; set; } = 0.0;
        public double AHUHeatingCoilFluidTemp { get; set; } = 0.0;
        public double AHUSpecifiedOutsideSupplyAirflow { get; set; } = 0.0;
        public double AHUHeatRecoveryLatEfficiency { get; set; } = 0.0;
        public double AHUWinterDesignTemp { get; set; } = 0.0;
        public double AHUWinterHeatRecoveryOffTemp { get; set; } = 0.0;
        public double AHUReheatCoilOnTemp { get; set; } = 0.0;
        public double AHUCoolingCoilLatLoad { get; set; } = 0.0;
        public double SystemAHUSpaceSummerSensTotRatio { get; set; } = 0.0;
        public double AHUSpecifiedOutsideSupplyAirRatio { get; set; } = 0.0;

                
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AirHandlingUnitProperties() { }
    }

}