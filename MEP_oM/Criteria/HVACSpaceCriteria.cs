/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *
 *
 * The BHoM is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License, or
 * (at your option) any later version.
 *
 * The BHoM is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.
 */

using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.MEP.Criteria
{
    [Description("HVAC space design conditions, rates and assumptions used for space loads, outdoor-air requirements and airside balances. May provide SpaceType defaults or explicitly supplied calculation inputs. NaN means a value was not supplied. Design humidity values define calculation states, not automatic humidity-control requirements.")]
    public class HVACSpaceCriteria : BHoMObject
    {
        /***************************************************/
        /**** Design Conditions                         ****/
        /***************************************************/

        [Description("Indoor air-temperature setpoint used for heating design calculations (degrees Celsius). NaN means the value was not supplied. This is air temperature, not operative temperature.")]
        public virtual double HeatingDesignTemperature { get; set; } = double.NaN;

        [Description("Indoor air-temperature setpoint used for cooling design calculations (degrees Celsius). NaN means the value was not supplied. This is air temperature, not operative temperature.")]
        public virtual double CoolingDesignTemperature { get; set; } = double.NaN;

        [Description("Indoor relative humidity used with HeatingDesignTemperature to define the heating design air state. Fraction from 0 to 1 inclusive: 0.40 means 40% RH. NaN means unspecified. This is a design-state assumption, not automatically a minimum RH limit or a requirement for humidification.")]
        public virtual double HeatingDesignRelativeHumidity { get; set; } = double.NaN;

        [Description("Indoor relative humidity used with CoolingDesignTemperature to define the cooling design air state. Fraction from 0 to 1 inclusive: 0.50 means 50% RH. NaN means unspecified. This is a design-state assumption, not automatically a maximum RH limit or a requirement for active humidity control.")]
        public virtual double CoolingDesignRelativeHumidity { get; set; } = double.NaN;

        /***************************************************/
        /**** Occupancy and Internal Gains              ****/
        /***************************************************/

        [Description("Floor area per design occupant (m2/person). NaN means the value was not supplied.")]
        public virtual double AreaPerPerson { get; set; } = double.NaN;

        [EnergyPerUnitTime]
        [Description("Sensible heat gain per occupant (W).")]
        public virtual double SensibleGainPerPerson { get; set; } = double.NaN;

        [EnergyPerUnitTime]
        [Description("Latent heat gain per occupant (W).")]
        public virtual double LatentGainPerPerson { get; set; } = double.NaN;

        [EnergyPerUnitArea]
        [Description("Lighting heat gain per floor area (W/m2).")]
        public virtual double LightingGainPerArea { get; set; } = double.NaN;

        [EnergyPerUnitArea]
        [Description("Sensible equipment heat gain per floor area (W/m2).")]
        public virtual double EquipmentSensiblePerArea { get; set; } = double.NaN;

        [EnergyPerUnitArea]
        [Description("Latent equipment heat gain per floor area (W/m2).")]
        public virtual double EquipmentLatentPerArea { get; set; } = double.NaN;

        /***************************************************/
        /**** Outdoor Air                               ****/
        /***************************************************/

        [VolumetricFlowRate]
        [Description("Outdoor air per occupant (m3/s).")]
        public virtual double OutdoorAirPerPerson { get; set; } = double.NaN;

        [Description("Outdoor air per floor area (m3/s/m2).")]
        public virtual double OutdoorAirPerArea { get; set; } = double.NaN;

        [Description("Outdoor air changes per hour. Requires an approved height.")]
        public virtual double OutdoorAirChangesPerHour { get; set; } = double.NaN;

        /***************************************************/
    }
}
