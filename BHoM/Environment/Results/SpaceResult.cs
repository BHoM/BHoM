using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class SpaceResult : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DryBulbTemperature { get; set; } = 0;
        public double MeanRadiantTemperature { get; set; } = 0;
        public double ResultantTemperature { get; set; } = 0;
        public ProfileResult SensibleLoad { get; set; } = new ProfileResult();
        public ProfileResult HeatingLoad { get; set; } = new ProfileResult();
        public ProfileResult CoolingLoad { get; set; } = new ProfileResult();
        public ProfileResult SolarGain { get; set; } = new ProfileResult();
        public ProfileResult LightingGain { get; set; } = new ProfileResult();
        public ProfileResult InfiltrationVentilationGain { get; set; } = new ProfileResult();
        public ProfileResult AirMovementGain { get; set; } = new ProfileResult();
        public ProfileResult BuildingHeatTransfer { get; set; } = new ProfileResult();
        public ProfileResult ExternalConductionOpaque { get; set; } = new ProfileResult();
        public ProfileResult ExternalConductionGlazing { get; set; } = new ProfileResult();
        public ProfileResult OccupancySensibleGain { get; set; } = new ProfileResult();
        public ProfileResult EquipmentSensibleGain { get; set; } = new ProfileResult();
        public double HumidityRatio { get; set; } = 0;
        public ProfileResult OccupancyLatentGain { get; set; } = new ProfileResult();
        public ProfileResult EquipmentLatentGain { get; set; } = new ProfileResult();
        public ProfileResult LatentLoad { get; set; } = new ProfileResult();
        public ProfileResult LatentRemovalLoad { get; set; } = new ProfileResult();
        public ProfileResult LatentAdditionLoad { get; set; } = new ProfileResult();
        public double VapourPressure { get; set; } = 0;
        public double ApertureFlowIn { get; set; } = 0;
        public double ApertureFlowOut { get; set; } = 0;
        public double Infiltration { get; set; } = 0;
        public double Ventilation { get; set; } = 0;
        public double IZAMIn { get; set; } = 0;
        public double IZAMOut { get; set; } = 0;
        public double RelativePressure { get; set; } = 0;
        public double Pollutant { get; set; } = 0;
    }
}
