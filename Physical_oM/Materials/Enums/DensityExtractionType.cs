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
using System.Text;
using System.ComponentModel;
using BH.oM.Base.Attributes;

namespace BH.oM.Physical.Materials
{
    [Description("Specifies how the density should be extracted from a physical Material with multiple IMaterialProperties of type IDensityProvider attached to it.")]
    public enum DensityExtractionType
    {
        [DisplayText("All matching.")]
        [Description("Require all densities across all IDensityProviders extracted to be equal within tolerance. If within tolerance, the average is computed.")]
        AllMatching,
        [Description("Compute and return the average value of all Densities found, independent of difference between them.")]
        Average,
        [Description("Return the maximum value of all densities found.")]
        Maximum,
        [Description("Return the minimum value of all densities found.")]
        Minimum
    }
}
