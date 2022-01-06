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
    [Description("Infiltration gains are defined as the amount of heat or heat loss contributed by cracks in the exterior envelope of the building which allow unconditioned outside air to be introduced to the space")]
    public class Infiltration : BHoMObject, IGain
    {
        [Description("The AirChangeRate indicates the amount of conditioned air lost by infiltration that should be replaced each hour, based on the volume of the space (1 ACH would be 1x the volume of space each hour, if the space is 1m3, it would be 1m3 of outside air per hour)")]
        public virtual double AirChangeRate { get; set; } = 0.0;

        [Description("The AirflowByWallExternalArea indicates the amount of air (m3/s) lost by infiltration based on the exterior wall area, that should be replaced within the space.")]
        public virtual double AirflowByWallExternalArea { get; set; } = 0.0;

        [Description("The AirflowByWallExternalCrackLength indicates the amount of air (m3/s) lost by infiltration based on the exterior wall crack length (the sum of the edge lengths), that should be replaced within the space.")]
        public virtual double AirflowByWallExternalCrackLength { get; set; } = 0.0;

        [Description("Profiles depict the time period (hours per day, days per week) during which infiltration is contributing to or causing a loss of heat to the space.")]
        public virtual Profile Profile { get; set; } = new Profile();
    }
}



