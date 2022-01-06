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
    public class PlumbingLoadingFixtureUnitFragment : IFragment
    {
        [Description("The number of cold water fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double ColdWaterLoadingFixtureUnits { get; set; } = 0.0;

        [Description("The number of hot water fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double HotWaterLoadingFixtureUnits { get; set; } = 0.0;

        [Description("The number of waste/drainage fixture or loading units for the plumbing fixture which denote the hydraulic load imposed based on flow rate, time of operation and frequency of use.")]
        public virtual double DrainageLoadingFixtureUnits { get; set; } = 0.0;
    }
}


