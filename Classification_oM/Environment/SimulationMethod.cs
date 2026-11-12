/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

using BH.oM.Base.Attributes;
using System.ComponentModel;

namespace BH.oM.Classification.Environment
{
    [Description("The method or standard an energy simulation follows (e.g. ASHRAE 90.1, Part L, TM54).")]
    public enum SimulationMethod
    {
        Undefined,
        [DisplayText("ASHRAE 90.1 - Default")]
        ASHRAE90_1Default,
        [DisplayText("ASHRAE 90.1 - Tailored")]
        ASHRAE90_1Tailored,
        [DisplayText("Design for performance")]
        DesignForPerformance,
        [DisplayText("Part L1A")]
        PartL1A,
        [DisplayText("Part L1B")]
        PartL1B,
        [DisplayText("Part L2A")]
        PartL2A,
        [DisplayText("Part L2B")]
        PartL2B,
        [DisplayText("Section 6")]
        Section6,
        [DisplayText("TM54 - HVAC")]
        TM54HVAC,
        [DisplayText("TM54 - Simple")]
        TM54Simple,
        Other,
    }
}
