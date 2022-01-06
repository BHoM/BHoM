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
using System.ComponentModel;

namespace BH.oM.Base
{
    [Description("Settings to determine the uniqueness of an Object, i.e. when comparing and when computing the object Hash.")]
    public abstract class BaseComparisonConfig : IObject
    {
        [Description("Names of properties you want to disregard in defining the uniqueness of an object. You can specify the property name or the Full Name. Supports * wildcard."
            + "\nExamples of valid values: `BHoM_Guid`, `StartNode`, `Bar.StartNode.Position.X`, `Bar.*.Position.Y`. See the wiki for more details.")]
        public virtual List<string> PropertyExceptions { get; set; } = new List<string>() { };

        [Description("If one or more entries are specified here, only objects/properties that match them will be considered in the hash." +
           "\nE.g. Given input objects BH.oM.Structure.Elements.Bar, specifying `StartNode` will only check that property of the Bar." +
           "\nLike for PropertyExceptions, you can specify the property name or the Full Name. Supports * wildcard." +
           "\nNote that using this will incur in a general slowdown because it is computationally heavy. See the wiki for more details.")]
        public virtual List<string> PropertiesToConsider { get; set; } = new List<string>();

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be ignored." +
            "\nBy default it includes `RenderMesh`. " +
            "\nThis does not support wildcard usage. See the wiki for more details.")]
        public virtual List<string> CustomdataKeysExceptions { get; set; } = new List<string>() { "RenderMesh" };

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be included in the comparison." +
            "\nAdding keys to this List will exclude any key that is not in this List." +
            "\nI.e. for every object, if it has CustomData keys present in this List, we then exclude any other CustomData key found in it.")]
        public virtual List<string> CustomdataKeysToConsider { get; set; } = new List<string>() { };

        [Description("Any corresponding type is ignored. E.g. `typeof(Guid)`.")]
        public virtual List<Type> TypeExceptions { get; set; } = new List<Type>();

        [Description("Any corresponding namespace is ignored. E.g. `BH.oM.Structure`. Does not support wildcard. See the wiki for more details.")]
        public virtual List<string> NamespaceExceptions { get; set; } = new List<string>();

        [Description("If any property is nested into the object over that level, it is ignored. Useful to limit the runtime." +
            "\nDefaults to unlimited.")]
        public virtual int MaxNesting { get; set; } = int.MaxValue;

        [Description("Sets the maximum number of property differences to be determined before stopping. Useful to limit the runtime." +
            "\nDefaults to unlimited.")]
        public virtual int MaxPropertyDifferences { get; set; } = int.MaxValue;

        [Description("Numeric tolerance for property values, applied to all numerical properties. Defaults to double.MinValue: no rounding applied." +
            "\nApplies rounding for numbers smaller than this." +
            "\nYou can override on a per-property basis by using `PropertyNumericTolerances`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual double NumericTolerance { get; set; } = double.MinValue;

        [Description("Tolerance used for individual properties. When computing Hash or the property Diffing, if the analysed property name is found in this collection, the corresponding tolerance is applied." +
            "\nSupports * wildcard in the property name matching. E.g. `StartNode.Point.*, 2`." +
            "\nIf a match is found, this take precedence over the global `NumericTolerance`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual HashSet<NamedNumericTolerance> PropertyNumericTolerances { get; set; } = new HashSet<NamedNumericTolerance>();

        [Description("Number of significant figures allowed for numerical data." +
            "\nDefaults to `int.MaxValue`: no approximation applied." +
            "\nYou can override on a per-property basis by using `PropertySignificantDigits`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual int SignificantFigures { get; set; } = int.MaxValue;

        [Description("Number of significant figures allowed for numerical data on a per-property base. " +
             "\nSupports * wildcard in the property name matching. E.g. `StartNode.Point.*, 2`." +
             "\nIf a match is found, this take precedence over the global `SignificantFigures`." +
             "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual HashSet<NamedSignificantFigures> PropertySignificantFigures { get; set; } = new HashSet<NamedSignificantFigures>();
    }
}



