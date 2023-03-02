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
    [Description("Enum for controlling if analysis parameters of the Timber material should be assigned based on edgewise or flatwise parameters. Only applicable for some engineered timber products, such as LVL.")]
    public enum TimberAnalysisOrientation
    {
        [Description("Default value. For some timber types with no distinction between edgewise and flatwise behaviour this can be used.")]
        Unknown,
        [Description("Stiffness values should be assigned based on Flatwise values, i.e. the material will be applied to an element in a way that the lamination layers are built up along the element normal. Generally what should be used if the material is applied to a surface element such as a Panel.")]
        Flatwise,
        [Description("Stiffness values should be assigned based on Edgewise values, i.e. the material will be applied to an element in a way that the lamination layers are built up perpendicular to the element normal. Generally what should be used if the material is applied to a linear element such as a Bar.")]
        Edgewise
    }
}
