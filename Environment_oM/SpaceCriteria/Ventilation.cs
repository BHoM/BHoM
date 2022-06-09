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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Environment.SpaceCriteria

{ 
    [Description("Ventilation defines the amount of outside air that should be introduced to a space, which is typically based on the number of occupants breathing the air and the area of the space.")]
    public class Ventilation : BHoMObject
    {
        [Description("The ventilation rate associated with the number of occupants within a space, example: 0.00025 m3/s per person")]
        public virtual double PeopleRate { get; set; } = 0.0;

        [Description("The ventilation rate associated with the area of the space, example: 0.0003 m3/s*m2")]
        public virtual double AreaRate { get; set; } = 0.0;

        [Description("The air change rate per hour (ACH) is a value that denotes the amount of air that must be replaced each hour, based on the volume of the space (1 ACH would be 1x the volume of space each hour, if the space is 1m3, it would be 1m3 of outside air per hour)")]
        public virtual double AirChangeRate { get; set; } = 0.0;

    }
}


