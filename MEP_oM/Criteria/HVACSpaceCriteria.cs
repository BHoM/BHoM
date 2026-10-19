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
    [Description("Rates for one HVAC calculation pass. Name is stored on each result as ResultCase. NaN means the rate was not supplied.")]
    public class HVACSpaceCriteria : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

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

        [VolumetricFlowRate]
        [Description("Outdoor air per occupant (m3/s).")]
        public virtual double OutdoorAirPerPerson { get; set; } = double.NaN;

        [Description("Outdoor air per floor area (m3/s·m2).")]
        public virtual double OutdoorAirPerArea { get; set; } = double.NaN;

        [Description("Outdoor air changes per hour. Requires an approved height.")]
        public virtual double OutdoorAirChangesPerHour { get; set; } = double.NaN;

        /***************************************************/
    }
}
