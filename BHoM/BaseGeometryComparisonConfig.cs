/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

namespace BH.oM.Base
{
    [Description("Base class for settings to determine the uniqueness of a Geometry object, used when comparing a geometry via Diffing and/or when the GeometryHash." +
        "More settings can be found in BH.oM.Geometry.GeometryComparisonConfig.")]
    public abstract class BaseGeometryComparisonConfig : IObject
    {
        [Description("If true, geometric types will be identified based on the GeometryHash function. " +
            "This function reduces the identity of geometry down to its most basic components, and it is faster than scouring for all its properties. " +
            "See its implementation in the Geometry_Engine for more details.")]
        public virtual bool UseGeometryHash { get; set; } = true;
    }
}