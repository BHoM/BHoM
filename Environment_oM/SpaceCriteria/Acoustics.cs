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
    [Description("The Acoustics object defines the noise criteria for an environments space, whether it's the prescribed ductwork velocity, the noise rating for the space or the dB level.")]
    public class Acoustics : BHoMObject
    {
        [Description("The prescribed velocity of the ductwork in the space (with more strict requirements for velocity in bedrooms and theatres (~3 m/s)")]
        public virtual double DuctVelocity { get; set; } = 0.0;

        [Description("The noise rating (NR), also known as noise criteria (NC) in the US, is the perceived loudness of a space")]
        public virtual double NoiseRating { get; set; } = 0.0;

        [Description("The Decibel A (dBA) is the sound pressure sensed by the human ear without sensitivity to very low and very high frequencies prescribed for a space")]
        public virtual double DecibelA { get; set; } = 0.0;

    }
}

