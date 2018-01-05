using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Thermostat object for environmental models.
    /// </summary>
    public class InternalGain : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Infiltration { get; set; } = 0.0;
        public double Ventilation { get; set; } = 0.0;
        public double LightingGain { get; set; } = 0.0;
        public double OccupancySensibleGain { get; set; } = 0.0;
        public double OccupancyLatentGain { get; set; } = 0.0;
        public double EquipmentSensibleGain { get; set; } = 0.0;
        public double EquipmentLatentGain { get; set; } = 0.0;
        public double PollutantGeneration { get; set; } = 0.0;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public InternalGain() { }

        /***************************************************/

        public InternalGain(double infiltration, double ventilation, double lightinggain, double occupancysensiblegain,
                            double occupancylatentgain, double equipmentsensiblegain, double equipmentlatentgain, double pollutantgeneration)

        {
            Infiltration = infiltration;
            Ventilation = ventilation;
            LightingGain = lightinggain;
            OccupancySensibleGain = occupancysensiblegain;
            OccupancyLatentGain = occupancylatentgain;
            EquipmentSensibleGain = equipmentsensiblegain;
            EquipmentLatentGain = equipmentlatentgain;
            PollutantGeneration = pollutantgeneration;
        }

    }

}
