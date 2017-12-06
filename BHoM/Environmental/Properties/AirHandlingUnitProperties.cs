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
        
        /// Properties of Air Handling Units
        public double AirLeakagePercentage { get; set; } = 0.0;
        public double FrostCoilOffTemp { get; set; } = 0.0;
        public double ReheatCoilOffTemp { get; set; } = 0.0;
       
        // Peak Hour
        public int SystemAHUSpaceSummerTotCoolingPeakHour { get; set; } = 0;

        public double MixCoditionTemp { get; set; } = 0.0;
        public int SystemAHUSpaceWinterHeatingPeakHour { get; set; } = 0;
        public string RiserCooling { get; set; } = "";
        public double FrostCoilOnTemp { get; set; } = 0.0;
        public double CoolingCoilFluidTemp { get; set; } = 0.0;
        public double SpecifiedSupplyAirflow { get; set; } = 0.0;
        public string CoolingCoilCalcMethod { get; set; } = "";
        public double SpecifiedReturnAirflow { get; set; } = 0.0;
        public double FrostCoilSensLoad { get; set; } = 0.0;
        public double SystemAHUSpaceLatWinterLoad { get; set; } = 0.0;
        public double CoolingCoilOnTemp { get; set; } = 0.0;
        public double WinterHeatRecoveryOnTemp { get; set; } = 0.0;
        public double HeatRecoverySensEfficiency { get; set; } = 0.0;
        public double NumberOfUnits { get; set; } = 0.0;
        public string CoolingCoilOnEnthalpy { get; set; } = "";
        public double CoolingCoilOnX { get; set; } = 0.0;
        public double SystemAHUSpaceHeatingLoad { get; set; } = 0.0;
        public string Description { get; set; } = "";
        public double ReheatCoilSensLoad { get; set; } = 0.0;

        // Total Load sum from spaces assigned to AHU
        public double SystemAHUSpaceSensCoolingLoad { get; set; } = 0.0;
        public double CoolingCoilTotalLoad { get; set; } = 0.0;

        //definition if AHU is 100% OutsideSupplyAir (OSA) or with recirculation TotalSupplyAir (TSA)
        public string FreshAirType_OSAorTSA { get; set; } = "";

        public double CoolingCoilSensLoad { get; set; } = 0.0;
        public double CoolingCoilOffRH { get; set; } = 0.0;

        //public string AHUPsychrometricURL { get; set; } = "";
        public double SummerDesignTemp { get; set; } = 0.0;
        public double SummerDesignRH { get; set; } = 0.0;
        public double CoolingCoilOffX { get; set; } = 0.0;
        public double WinterSupplyTemp { get; set; } = 0.0;
        public double SystemAHUSpaceTotCoolingLoad { get; set; } = 0.0;
        
        //reference of Riser
        public string RiserHeating { get; set; } = "";

        //public double AHUModified { get; set; } = 0.0;
        public double CoolingCoilOnRH { get; set; } = 0.0;
        public double SummerSupplyTemp { get; set; } = 0.0;
        public double SystemAHUSpaceLatCoolingLoad { get; set; } = 0.0;
        public double CoolingCoilOffTemp { get; set; } = 0.0;
        public string CoolingCoilOffEnthalpy { get; set; } = "";
        public double SystemAHUSpaceWinterSensTotRatio { get; set; } = 0.0;
        public double HeatingCoilFluidTemp { get; set; } = 0.0;
        public double SpecifiedOutsideSupplyAirflow { get; set; } = 0.0;
        public double HeatRecoveryLatEfficiency { get; set; } = 0.0;
        public double WinterDesignTemp { get; set; } = 0.0;
        public double WinterHeatRecoveryOffTemp { get; set; } = 0.0;
        public double ReheatCoilOnTemp { get; set; } = 0.0;
        public double CoolingCoilLatLoad { get; set; } = 0.0;
        public double SystemAHUSpaceSummerSensTotRatio { get; set; } = 0.0;
        public double SpecifiedOutsideSupplyAirRatio { get; set; } = 0.0;

                
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AirHandlingUnitProperties() { }
    }

}