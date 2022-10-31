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
    [Description("Settings for extraction of Density from a List of IDensityProviders.")]
    public class DensityExtractionOptions : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A specific type of IDensityProvider to limit the search to. If null all IDensityProviders on the material are considered.\n" +
                     "Errors will be raised if the type provided is not a IDensityProvider type.")]
        public virtual Type Type { get; set; } = null;

        [Description("If true, and material does not contain a IDensityProvider of the specified type, DensityExtraction falls back to look for other densities. If false and material does not contain the type DensityExtraction exits.")]
        public virtual bool AllowFallbackIfNoType { get; set; } = false;

        public virtual DensityExtractionType ExtractionType { get; set; } = DensityExtractionType.AllMatching;

        [Ratio]
        [Description("The ratio tolerance for considering the value of the densities as equal. Density values are deemed equal if (max - min / mean) is smaller than this value, where mean = (max + min)/2, i.e. a tolerance of 0.01 means an allowable difference of 1% normalised to the mean value of found densities.")]
        public virtual double EqualTolerance { get; set; } = 0.001;

        [Description("Ignores densities of 0 if true when computing average or checking for equality.")]
        public virtual bool IgnoreZeroValues { get; set; } = true;

        [Description("Threshold for density values to be seen as 0.")]
        public virtual double ZeroTolerance { get; set; } = 1e-6;

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Returns a DensityExtractionOptions class with provided Type set set and all other values as defaults.")]
        public static explicit operator DensityExtractionOptions(Type type)
        {
            return new DensityExtractionOptions { Type = type };
        }

        /***************************************************/

        [Description("Returns a DensityExtractionOptions class with provided ExtractionType set and all other values as defaults.")]
        public static explicit operator DensityExtractionOptions(DensityExtractionType extractionType)
        {
            return new DensityExtractionOptions { ExtractionType = extractionType };
        }

        /***************************************************/

    }
}


