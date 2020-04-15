/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

namespace BH.oM.Environment.Gains
{
    public class Profile : BHoMObject, IEnvironmentObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Profile Type depicts the time period (hours per day or year) during which the gain is actively contributing to the space")]
        public virtual ProfileType ProfileType { get; set; } = ProfileType.Undefined;

        [Description("The multiplication factor indicates the total percentage 0.0-1.0 over which the profile should be applied")]
        public virtual double MultiplicationFactor { get; set; } = 1.0;

        [Description("The set back value indicates the total percentage 0.0-1.0 over which the profile should not be applied")]
        public virtual double SetBackValue { get; set; } = 0.0;

        public virtual string Function { get; set; } = "";

        [Description("Values denotes the hour-by-hour values based on the chosen Profile Type: yearly, daily")]
        public virtual List<double> Values { get; set; } = new List<double>();

        [Description("The profile category in an enum that denotes what this profile is being set for: a gain, humdistat or thermostat")]
        public virtual ProfileCategory Category { get; set; } = ProfileCategory.Undefined;

        /***************************************************/
    }
}

