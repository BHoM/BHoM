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

namespace BH.oM.Environment.Gains
{
    [Description("Infiltration gains are defined as the amount of heat or heat loss contributed by cracks in the exterior envelope of the building which allow unconditioned outside air to be introduced to the space")]
    public class Infiltration : BHoMObject, IGain
    {
        [Description("The sensible heat contributed or lost by infiltration, which contributes to a rise or drop in temperature with no change in phase.")]
        public virtual double Sensible { get; set; } = 0.0;

        [Description("The latent heat contributed or lost by infiltration, which contributes to a change in phase from solid to liquid.")]
        public virtual double Latent { get; set; } = 0.0;

        [Description("Profiles depict the time period (hours per day, days per week) during which infiltration is contributing to or causing a loss of heat to the space.")]
        public virtual Profile Profile { get; set; } = new Profile();
    }
}

