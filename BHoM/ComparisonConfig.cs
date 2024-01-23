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
    [Description("Settings to determine the uniqueness of an Object, i.e. when comparing and when computing the object Hash.")]
    public class ComparisonConfig : BaseComparisonConfig
    {
        public ComparisonConfig(HashSet<string> propertyExceptions = null, HashSet<string> propertiesToConsider = null,
            HashSet<string> customdataKeysExceptions = null, HashSet<string> customdataKeysToConsider = null,
            HashSet<Type> typeExceptions = null, HashSet<string> namespaceExceptions = null,
            int maxNesting = int.MaxValue, int maxPropertyDifferences = int.MaxValue,
            double numericTolerance = double.MinValue, HashSet<NamedNumericTolerance> propertyNumericTolerances = null,
            int significantFigures = int.MaxValue, HashSet<NamedSignificantFigures> propertySignificantFigures = null,
            bool useGeometryHash = false) : base(propertyExceptions, propertiesToConsider,
                customdataKeysExceptions, customdataKeysToConsider,
                typeExceptions, namespaceExceptions,
                maxNesting, maxPropertyDifferences,
                numericTolerance, propertyNumericTolerances,
                significantFigures, propertySignificantFigures,
                useGeometryHash)
        {

        }
    }
}