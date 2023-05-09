﻿/*
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

using BH.oM.Analytical.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Base interface for Life Cycle Assessment results for a particular element..")]
    public interface IElementResult<out T> : IObjectResult, IResultItem, ILifeCycleAssesmentResult
        where T : MaterialResult
    {
        [Description("Scope the object this result was generated from belongs to, e.g. Foundation or Facade")]
        ScopeType Scope { get; }

        [Description("Category of the object this result was generated from, e.g. Beam or Wall")]
        ObjectCategory Category { get; }

        [Description("Result breakdown per material type.")]
        IReadOnlyList<T> MaterialResults { get; }
    }
}
