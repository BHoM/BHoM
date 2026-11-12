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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.MEP
{
    [Description("The principal cooling plant of a building's HVAC system.")]
    public enum HVACCooling
    {
        Undefined,
        [DisplayText("Water cooled chiller")]
        WaterCooledChiller,
        [DisplayText("Air cooled chiller")]
        AirCooledChiller,
        [DisplayText("Cooling tower")]
        CoolingTower,
        [DisplayText("District cooling")]
        DistrictCooling,
        [DisplayText("Air source heat pump")]
        AirSourceHeatPump,
        [DisplayText("Water source heat pump")]
        WaterSourceHeatPump,
        [DisplayText("Ground source heat pump")]
        GroundSourceHeatPump,
        [DisplayText("Sewer source heat pump")]
        SewerSourceHeatPump,
        Other,
    }
}
