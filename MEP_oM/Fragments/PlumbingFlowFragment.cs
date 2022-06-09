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
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System.ComponentModel;

namespace BH.oM.MEP.Fragments
{
    public class PlumbingFlowFragment : IFragment
    {
        [VolumetricFlowRate]
        [Description("The volume of cold water being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double ColdWaterFlowRate { get; set; } = 0;

        [VolumetricFlowRate]
        [Description("The volume of hot water being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double HotWaterFlowRate { get; set; } = 0;

        [VolumetricFlowRate]
        [Description("The volume of waste/drainage being conveyed by the Plumbing Fixture per second (m3/s).")]
        public virtual double DrainageFlowRate { get; set; } = 0;
    }
}


