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
    [Description("The plumbing attributes of a space are indicative of the amount of cold water, hot water and waste required by a space, as well as requirements for vent, floor drains, hose bibs or natural gas")]
    public class Plumbing : BHoMObject
    {
        [Description("The total number of cold water units (aka fixture units or loading units) that should be provided to the space based on the number of plumbing fixtures requiring cold water within the space (e.g. 1 sink = 1.0 units, 2 sinks = 2.0 units, 1 urinal = 10.0 units per IPC2015 Table E103.3).")]
        public virtual double ColdWaterUnits { get; set; } = 0.0;

        [Description("The total number of hot water units (aka fixture units or loading units) that should be provided to the space based on the number of plumbing fixtures requiring hot water within the space (e.g. 1 sink = 1.0 units, 2 sinks = 2.0 units, 1 urinal = 0.0 units (no hot water for urinals!) per IPC2015 Table E103.3).")]
        public virtual double HotWaterUnits { get; set; } = 0.0;

        [Description("The total number of waste/sanitary/drainage units (aka fixture units or loading units) that should be provided to the space based on the number of plumbing fixtures requiring waste/sanitary/drainage connections within the space (e.g. 1 sink = 2.0 units, 2 sinks = 4.0 units, 1 urinal = 4.0 units per IPC2018 Table 709.1).")]
        public virtual double WasteUnits { get; set; } = 0.0;

        [Description("The natural gas rate will indicate the m3/hr of gas required within the space incurred by stovetops, fireplaces or clothes dryers.")]
        public virtual double NaturalGasRate { get; set; } = 0.0;

        [Description("An indication that the space will require vent (inherently linked to the need for waste/sanitary/drainage) the size will be calculated based on the number of waste units required.")]
        public virtual bool VentRequirement { get; set; } = true;

        [Description("An indication that the space will require floor drains (janitor's closet or mechanical room).")]
        public virtual bool FloorDrainRequirement { get; set; } = false;

        [Description("An indication that the space will require hose bibs (janitor's closet or mechanical room).")]
        public virtual bool HoseBibRequirement { get; set; } = false;

    }
}



