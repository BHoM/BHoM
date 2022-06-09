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
using BH.oM.Environment.Fragments;

namespace BH.oM.Environment.SpaceCriteria
{
    [Description("A profile object represents a gain, thermostat or humdistat as conditions vary over a 24-hour period")]
    public class Profile : BHoMObject, IEnvironmentObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Profile Type depicts the type of profile (OnOff (0 or 1), ModulatingPercentage (0.0-1.0), or Absolute (-10000 to +10000))")]
        public virtual ProfileType ProfileType { get; set; } = ProfileType.Undefined;

        [Description("Profile Day depicts the day described in the profile, whether it's a day of the week or a holiday")]
        public virtual List<ProfileDay> ProfileDay { get; set; } = new List<ProfileDay>();

        [Description("Hourly Values denotes the hour-by-hour values for a 24-hour period. These values may be represented in temperature (degrees C) (thermostat), fraction (0.9) (lighting gain), or flow (m3/s) (ventilation)")]
        public virtual List<double> HourlyValues { get; set; } = new List<double>();

        /***************************************************/
    }
}



