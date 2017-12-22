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
    /// Space Properties
    /// </summary>

    class SpaceProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ElementID { get; set; } = "";
        public double AirMovementGain { get; set; } = 0.0;
        public double Area { get; set; } = 0.0;
        public double AirDistrubution { get; set; } = 0.0;
        public double BuildingHeatTransfer { get; set; } = 0.0;
        public double CFDSpaceDryBulbTemperature { get; set; } = 0.0;
        public double CFDSpaceForStudy { get; set; } = 0.0;
        public double CIBSEZoneOutsideSupplyAirFlow { get; set; } = 0.0;
        public double CLGInfiltrationACH { get; set; } = 0.0;
        public double ComfNoHoursAbv25 { get; set; } = 0.0;
        public double ComfNoHoursAbv25Perc { get; set; } = 0.0;
        public double ComfNoHoursAbv28 { get; set; } = 0.0;
        public double ComfNoHoursAbv28Perc { get; set; } = 0.0;
        public double CoolingCircuitTemperature { get; set; } = 0.0;
        public double CoolingEmmiterCoefficient { get; set; } = 0.0;
        public double CoolingEmmiterRadiantProportion { get; set; } = 0.0;
        public double CoolingLoad { get; set; } = 0.0;

        public string CoolingProfile { get; set; } = "";

        public double CoolingTypePrimary { get; set; } = 0.0;
        public double CoolingTypeSecondary { get; set; } = 0.0;
        public double DaylightLinkingControl { get; set; } = 0.0;
        public double DesignLuxLevel { get; set; } = 0.0;
        public double DesignSensHeatingLoad { get; set; } = 0.0;
        public double DesLatCoolingLoad { get; set; } = 0.0;
        public double DesSensCoolingLoad { get; set; } = 0.0;
        public double DesSpecLatCoolLoad { get; set; } = 0.0;
        public double DesSpecSensCoolLoad { get; set; } = 0.0;
        public double DesSpecSensHeatLoad { get; set; } = 0.0;
        public double EquipmentLatentGain { get; set; } = 0.0;
        public double EquipmentSensibleGain { get; set; } = 0.0;
        public double ExternalConductionGlazing { get; set; } = 0.0;
        public double ExternalConductionOpaque { get; set; } = 0.0;
        public double ExternalZone { get; set; } = 0.0;
        public string FlatReference { get; set; } = "";
        public string GenLightingProfile { get; set; } = "";
        public double HeatingCircuitTemperature { get; set; } = 0.0;
        public double HeatingEmmiterCoefficient { get; set; } = 0.0;
        public double HeatingEmmiterRadiantProportion { get; set; } = 0.0;
        public double HeatingLoad { get; set; } = 0.0;
        public string HeatingPlantProfile { get; set; } = "";
        public string HeatingTypePrimary { get; set; } = "";
        public string HeatingTypeSecondary { get; set; } ="";
        public double Height { get; set; } = 0.0;
        public double HTGInfiltrationACH { get; set; } = 0.0;
        public string IC_Description { get; set; } = "";
        public string IC_ThermalTemplate { get; set; } = "";
                 
        //properties from NCM
        public double NCMLightingConstantIlluminanceControls { get; set; } = 0.0;
        public double NCMLightingDaylightFactorMethod { get; set; } = 0.0;
        public double NCMLightingDaylightFactorMethodBRE { get; set; } = 0.0;
        public string NCMLightingOccupancyControls { get; set; } = "";
        public double NCMLightingOccupancyControlsTimeSwitch { get; set; } = 0.0;
        public double NCMLightingOccupancyParasiticPowerW_m2 { get; set; } = 0.0;
        public double NCMLightingPhotoelectricBackSpaceSensor { get; set; } = 0.0;
        public string NCMLightingPhotoelectricControls { get; set; } = "";
        public double NCMLightingPhotoelectricControlsTimeSwitch { get; set; } = 0.0;
        public double NCMLightingPhotoelectricParasiticPowerW_m2 { get; set; } = 0.0;
        public string NCMSpaceType { get; set; } = "";
        public string NCMSystemType { get; set; } = "";
        public double NCMTaskLightingEfficacy { get; set; } = 0.0;

        public double NoPeople { get; set; } = 0.0;
        public double NV_EqvFreeArea { get; set; } = 0.0;
        public string NV_Strategy { get; set; } = "";
        public string OccupacyProfile { get; set; } = "";
        public double OccupancyLatentGain { get; set; } = 0.0;
        public double OccupancyNoHoursYearly { get; set; } = 0.0;
        public double OccupancySensibleGain { get; set; } = 0.0;
        public double OccupantDensity { get; set; } = 0.0;
        public double OccupantLatGain { get; set; } = 0.0;
        public double OccupantSensGain { get; set; } = 0.0;
        public string PeakDate { get; set; } = "";
        public string PeakTime { get; set; } = "";
        public double PMVCumFreqMax0_5v { get; set; } = 0.0;
        public double PMVCumFreqMax1_0 { get; set; } = 0.0;
        public double PMVCumFreqMax1_5 { get; set; } = 0.0;
        public double PollutantGeneration_ghrm2 { get; set; } = 0.0;
        public double PollutantGeneration_ghrperson { get; set; } = 0.0;
        public double PollutantProfile { get; set; } = 0.0;
        public double PPDCumFreqMax10 { get; set; } = 0.0;
        public double PPDCumFreqMax20 { get; set; } = 0.0;
        public double PPDCumFreqMax30 { get; set; } = 0.0;
        public double ProcessLoad { get; set; } = 0.0;
        public string RefCombinedVentUnit { get; set; } = "";
        public string ReferenceRiserCooling { get; set; } = "";
        public string ReferenceRiserHeating { get; set; } = "";
        public string ReferenceRiserRiser { get; set; } = "";
        public string ReferenceRiserVentilation { get; set; } = "";
        public string RefExhaustUnit { get; set; } = "";
        public string RefSupplyUnit { get; set; } = "";
        public string ResultsImportTime { get; set; } = "";
        public string RoomDescription { get; set; } = "";
        public string RoomName { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string RoomUseComments { get; set; } = "";
        public string SizingMethod { get; set; } = "";
        public double SmallPowerLat { get; set; } = 0.0;
        public double SmallPowerLatProfile { get; set; } = 0.0;
        public double SmallPowerProfile { get; set; } = 0.0;
        public double SmallPowerSens { get; set; } = 0.0;
        public double SmallPowerSensProfile { get; set; } = 0.0;
        public double SolarGain { get; set; } = 0.0;
        public double SpaceAHUCoolingCoilOffTemp { get; set; } = 0.0;

        public double AperutreFlowIn { get; set; } = 0.0;
        public double AperutreFlowOut { get; set; } = 0.0;
        public string DehumidificationProfile { get; set; } = "";
        public string Description { get; set; } = "";
        public double DryBulbTemperature { get; set; } = 0.0;
        public string HeatingProfile { get; set; } = "";
        public string HumidificationProfile { get; set; } = "";
        public double HumidityRatio { get; set; } = 0.0;
        public double MaxTemperature { get; set; } = 0.0;
        public double MinTemperature { get; set; } = 0.0;
        public double Modified { get; set; } = 0.0;
        public double OutsideAirVentilation { get; set; } = 0.0;
        public double Pollutant { get; set; } = 0.0;
        public double RelativeHumidity { get; set; } = 0.0; //output
        public double ResultantTemperature { get; set; } = 0.0;

        public double SpecBuildingHeatTransferGain { get; set; } = 0.0;
        public double SpecExternal { get; set; } = 0.0;
        public double SpecFeatureLighting { get; set; } = 0.0;
        public double SpecGenLightAt100lux { get; set; } = 0.0;
        public double SpecGenLighting { get; set; } = 0.0;
        public double SpecifiedExtractAirflow { get; set; } = 0.0;
        public double SpecifiedSupplyAirflow { get; set; } = 0.0;
        public double SpecOccupancyLat { get; set; } = 0.0;
        public double SpecOccupancySens { get; set; } = 0.0;
        public double SpecSmallPowerLat { get; set; } = 0.0;
        public double SpecSmallPowerSens { get; set; } = 0.0;
        public double SpecTaskLighting { get; set; } = 0.0;
        public double SummerDesignRH { get; set; } = 0.0;
        public double SummerDesignTemperature { get; set; } = 0.0;
        public double SummerDesignTemperatureRange { get; set; } = 0.0;
        public double TaskDesignLuxLevel { get; set; } = 0.0;
        public double TaskLightingProfile { get; set; } = 0.0;
        public double TerminalReference { get; set; } = 0.0;
        public double TotalZoneExtractAirFlow { get; set; } = 0.0;
        public double TotalZoneOutsideSupplyAirFlow { get; set; } = 0.0;
        public double TotalZoneSupplyAirFlow { get; set; } = 0.0;
        public double TrickleVent { get; set; } = 0.0;
        public string VentType { get; set; } = "";
        public double Volume { get; set; } = 0.0;
        public double WinterDesignRH { get; set; } = 0.0;
        public double WinterDesignTemperature { get; set; } = 0.0;
        public double WinterDesignTemperatureRange { get; set; } = 0.0;
        public double ZoneFreshAirACH { get; set; } = 0.0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SpaceProperties() { }

    }
}
