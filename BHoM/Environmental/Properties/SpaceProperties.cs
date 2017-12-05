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
        public double CoolingProfile { get; set; } = 0.0;
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
        public double FlatReference { get; set; } = 0.0;
        public double GenLightingProfile { get; set; } = 0.0;
        public double HeatingCircuitTemperature { get; set; } = 0.0;
        public double HeatingEmmiterCoefficient { get; set; } = 0.0;
        public double HeatingEmmiterRadiantProportion { get; set; } = 0.0;
        public double HeatingLoad { get; set; } = 0.0;
        public double HeatingPlantProfile { get; set; } = 0.0;
        public double HeatingTypePrimary { get; set; } = 0.0;
        public double HeatingTypeSecondary { get; set; } = 0.0;
        public double Height { get; set; } = 0.0;
        public double HTGInfiltrationACH { get; set; } = 0.0;
        public double IC_Description { get; set; } = 0.0;
        public double IC_ThermalTemplate { get; set; } = 0.0;
        public double IES_ID { get; set; } = 0.0;
        public double InfiltrationProfileIES_ID { get; set; } = 0.0;
        public double InfVentGainIES_ID { get; set; } = 0.0;
        public double LightingGainIES_ID { get; set; } = 0.0;
        public double MEPStrategyIES_ID { get; set; } = 0.0;
        public double NCMBuildingAreaTypeIES_ID { get; set; } = 0.0;
        public double NCMCalcAverageLuxLevelIES_ID { get; set; } = 0.0;
        public double NCMLightingConstantIlluminanceControls { get; set; } = 0.0;
        public double NCMLightingDaylightFactorMethod { get; set; } = 0.0;
        public double NCMLightingDaylightFactorMethodBRE { get; set; } = 0.0;
        public double NCMLightingOccupancyControls { get; set; } = 0.0;
        public double NCMLightingOccupancyControlsTimeSwitch { get; set; } = 0.0;
        public double NCMLightingOccupancyParasiticPowerW_m2 { get; set; } = 0.0;
        public double NCMLightingPhotoelectricBackSpaceSensor { get; set; } = 0.0;
        public double NCMLightingPhotoelectricControls { get; set; } = 0.0;
        public double NCMLightingPhotoelectricControlsTimeSwitch { get; set; } = 0.0;
        public double NCMLightingPhotoelectricParasiticPowerW_m2 { get; set; } = 0.0;
        public double NCMSpaceType { get; set; } = 0.0;
        public double NCMSystemType { get; set; } = 0.0;
        public double NCMTaskLightingEfficacy { get; set; } = 0.0;
        public double NoPeople { get; set; } = 0.0;
        public double NV_EqvFreeArea { get; set; } = 0.0;
        public double NV_Strategy { get; set; } = 0.0;
        public double OccupacyProfile { get; set; } = 0.0;
        public double OccupancyLatentGain { get; set; } = 0.0;
        public double OccupancyNoHoursYearly { get; set; } = 0.0;
        public double OccupancySensibleGain { get; set; } = 0.0;
        public double OccupantDensity { get; set; } = 0.0;
        public double OccupantLatGain { get; set; } = 0.0;
        public double OccupantSensGain { get; set; } = 0.0;
        public double PeakDate { get; set; } = 0.0;
        public double PeakTime { get; set; } = 0.0;
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
        public double RefCombinedVentUnit { get; set; } = 0.0;
        public double ReferenceRiserCooling { get; set; } = 0.0;
        public double ReferenceRiserHeating { get; set; } = 0.0;
        public double ReferenceRiserRiser { get; set; } = 0.0;
        public double ReferenceRiserVentilation { get; set; } = 0.0;
        public double RefExhaustUnit { get; set; } = 0.0;
        public double RefSupplyUnit { get; set; } = 0.0;
        public double ResultsImportTime { get; set; } = 0.0;
        public double RoomDescription { get; set; } = 0.0;
        public double RoomName { get; set; } = 0.0;
        public double RoomNumber { get; set; } = 0.0;
        public double RoomUseComments { get; set; } = 0.0;
        public double SizingMethod { get; set; } = 0.0;
        public double SmallPowerLat { get; set; } = 0.0;
        public double SmallPowerLatProfile { get; set; } = 0.0;
        public double SmallPowerProfile { get; set; } = 0.0;
        public double SmallPowerSens { get; set; } = 0.0;
        public double SmallPowerSensProfile { get; set; } = 0.0;
        public double SolarGain { get; set; } = 0.0;
        public double SpaceAHUCoolingCoilOffTemp { get; set; } = 0.0;
        public double SpaceAperutreFlowIn { get; set; } = 0.0;
        public double SpaceAperutreFlowOut { get; set; } = 0.0;
        public double SpaceCoolingProfile { get; set; } = 0.0;
        public double SpaceDehumidificationProfile { get; set; } = 0.0;
        public double SpaceDescription { get; set; } = 0.0;
        public double SpaceDryBulbTemperature { get; set; } = 0.0;
        public double SpaceGUID { get; set; } = 0.0;
        public double SpaceHeatingProfile { get; set; } = 0.0;
        public double SpaceHumidificationProfile { get; set; } = 0.0;
        public double SpaceHumidityRatio { get; set; } = 0.0;
        public double Spaceies_GUID { get; set; } = 0.0;
        public double SpaceMaxTemperature { get; set; } = 0.0;
        public double SpaceMinTemperature { get; set; } = 0.0;
        public double SpaceModified { get; set; } = 0.0;
        public string SpaceName { get; set; } = "";
        public double SpaceOutsideAirVentilation { get; set; } = 0.0;
        public double SpacePollutant { get; set; } = 0.0;
        public double SpaceRelativeHumidity { get; set; } = 0.0;
        public double SpaceResultantTemperature { get; set; } = 0.0;
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
        public double TAS_Area { get; set; } = 0.0;
        public double TAS_GUID { get; set; } = 0.0;
        public double TAS_ID { get; set; } = 0.0;
        public double TAS_Volume { get; set; } = 0.0;
        public double TAS_ZoneDescription { get; set; } = 0.0;
        public double TaskDesignLuxLevel { get; set; } = 0.0;
        public double TaskLightingProfile { get; set; } = 0.0;
        public double TerminalReference { get; set; } = 0.0;
        public double TotalZoneExtractAirFlow { get; set; } = 0.0;
        public double TotalZoneOutsideSupplyAirFlow { get; set; } = 0.0;
        public double TotalZoneSupplyAirFlow { get; set; } = 0.0;
        public double TrickleVent { get; set; } = 0.0;
        public string URL { get; set; } = "";
        public double URLRoomDataSheet { get; set; } = 0.0;
        public double VentType { get; set; } = 0.0;
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
