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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Physical.Materials.Options
{
    [Description("Settings for extraction of Density from a Physical Material.")]
    public class DensityExtractionOptions : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A specific type of IDensityProvider to limit the search to. If null all IDensityProviders on the material are considered.")]
        public virtual Type Type { get; set; } = null;

        public virtual DensityExtractionType ExtractionType { get; set; } = DensityExtractionType.AllMatching;

        [Ratio]
        [Description("The ratio tolerance for considering the value of the densities as equal. Comparison is made by comparing the differance between min and max over their mean.")]
        public virtual double EqualTolerance { get; set; } = 0.001;

        [Description("Ignores densities of 0 if true when computing average or checking for equality.")]
        public virtual bool IgnoreZeroValues { get; set; } = true;
        /***************************************************/

    }
}


