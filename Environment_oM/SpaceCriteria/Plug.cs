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
    [Description("Plug gains are defined as the amount of sensible heat contributed by electrical receptacle/outlet loads")]
    public class Plug : BHoMObject, IGain
    {
        [Description("The sensible heat contributed by plugs, which contributes to a rise in temperature with no change in phase.")]
        public virtual double Sensible { get; set; } = 0.0;

        [Description("Profiles depict the time period (hours per day, days per week) during which plug loads are contributing heat to the space.")]
        public virtual Profile Profile { get; set; } = new Profile();

        [Description("The radiant fraction depicts the percentage of long wave radiant heat given off by plugs.")]
        public virtual double RadiantFraction { get; set; } = 0.0;
    }
}



