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
using BH.oM.Environment.Fragments;
using System.ComponentModel;

namespace BH.oM.Environment.SpaceCriteria
{
    public class Thermostat : BHoMObject, IEnvironmentObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Proportional control indicates that the thermostat can modulate the voltage delivered to the heating and/or cooling device")]
        public virtual bool ProportionalControl { get; set; } = false;

        [Description("Control range indicates the range in temperature (in degrees of celsius)")]
        public virtual double ControlRange { get; set; } = 0.0;

        [Description("Profiles depict the time period (hours per day, days per week) during which the thermostat will be active.")]
        public virtual List<Profile> Profiles { get; set; } = new List<Profile>();

        /***************************************************/
    }
}



