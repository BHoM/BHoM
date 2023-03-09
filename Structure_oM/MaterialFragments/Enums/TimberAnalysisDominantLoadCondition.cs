/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using System.ComponentModel;
using System.Text;

namespace BH.oM.Structure.MaterialFragments
{
    [Description("Enum for controlling if analysis parameters of the Timber material should be assigned based on values for bending or axial stiffness.\n" +
                 "Only relevant for some engineered timber products.")]
    public enum TimberAnalysisDominantLoadCondition
    {
        [Description("Default value. For some timber types where the stiffness values are independant on load condition this can be used..")]
        Undefined,
        [Description("The element with the Timber material will have loads resulting in axial stresses as the predominant load condition.")]
        Axial,
        [Description("The element with the Timber material will have loads resulting in bending stresses as the predominant load condition.")]
        Bending,
    }
}
