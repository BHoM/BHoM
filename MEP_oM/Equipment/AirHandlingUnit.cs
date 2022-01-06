/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.MEP.Equipment.Parts;

namespace BH.oM.MEP.Equipment
{
    [Description("Air Handling Units are devices which house fans, filter, coils, and energy wheels which produce heated and cooled fresh/partially recirculated air to a building")]
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Type denotes the kind of Air Handling Unit (eg heat and ventilation, energy recovery)")]
        public virtual string Type { get; set; } = "";
        
        [Description("Total Airflow accounts for the maximum amount of supply/outside air that the Air Handling Unit will be passing. This value is measured in m3/s (e.g. 2.35 m3/s (5000 CFM) of Outside Air)")]
        public virtual double TotalAirFlow { get; set; } = 0.0;

        [Description("Air velocity across coil denotes the maximum velocity of the air that should be passed along the Air Handling Unit's coil. This value is measured in m/s (maximum values around 2.5 m/s (500 ft/min) are considered best practice)")]
        public virtual double AirVelocityAcrossCoil { get; set; } = 0.0;

        [Description("A collection of the parts (Air Handling Unit, Fans, Coils, Energy Wheel, Filters, Electrical Connectors) that make up the Air Handling Unit")]
        public virtual List<IPart> Parts { get; set; } = new List<IPart>();

        /***************************************************/
    }
}



