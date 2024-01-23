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
using System.Linq;

namespace BH.oM.Base
{
    [Description("Settings to determine the uniqueness of an Object, i.e. when comparing and when computing the object Hash.")]
    public abstract class BaseComparisonConfig : IObject, IImmutable
    {
        [Description("Names of properties you want to disregard in defining the uniqueness of an object. You can specify the property name or the Full Name. Supports * wildcard."
            + "\nExamples of valid values: `BHoM_Guid`, `StartNode`, `Bar.StartNode.Position.X`, `Bar.*.Position.Y`. See the wiki for more details.")]
        public virtual HashSet<string> PropertyExceptions { get; } = new HashSet<string>() { };

        [Description("If one or more entries are specified here, only objects/properties that match them will be considered in the hash." +
           "\nE.g. Given input objects BH.oM.Structure.Elements.Bar, specifying `StartNode` will only check that property of the Bar." +
           "\nLike for PropertyExceptions, you can specify the property name or the Full Name. Supports * wildcard." +
           "\nNote that using this will incur in a general slowdown because it is computationally heavy. See the wiki for more details.")]
        public virtual HashSet<string> PropertiesToConsider { get; } = new HashSet<string>();

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be ignored." +
            "\nBy default it includes `RenderMesh`. " +
            "\nThis does not support wildcard usage. See the wiki for more details.")]
        public virtual HashSet<string> CustomdataKeysExceptions { get; } = new HashSet<string>() { "RenderMesh" };

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be included in the comparison." +
            "\nAdding keys to this List will exclude any key that is not in this List." +
            "\nI.e. for every object, if it has CustomData keys present in this List, we then exclude any other CustomData key found in it.")]
        public virtual HashSet<string> CustomdataKeysToConsider { get; } = new HashSet<string>() { };

        [Description("Any corresponding type is ignored. E.g. `typeof(Guid)`.")]
        public virtual HashSet<Type> TypeExceptions { get; } = new HashSet<Type>();

        [Description("Any corresponding namespace is ignored. E.g. `BH.oM.Structure`. Does not support wildcard. See the wiki for more details.")]
        public virtual HashSet<string> NamespaceExceptions { get; } = new HashSet<string>();

        [Description("If any property is nested into the object over that level, it is ignored. Useful to limit the runtime." +
            "\nDefaults to unlimited.")]
        public virtual int MaxNesting { get; } = int.MaxValue;

        [Description("Sets the maximum number of property differences to be determined before stopping. Useful to limit the runtime." +
            "\nDefaults to unlimited.")]
        public virtual int MaxPropertyDifferences { get; } = int.MaxValue;

        [Description("Numeric tolerance for property values, applied to all numerical properties. Defaults to double.MinValue: no rounding applied." +
            "\nApplies rounding for numbers smaller than this." +
            "\nYou can override on a per-property basis by using `PropertyNumericTolerances`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual double NumericTolerance { get; } = double.MinValue;

        [Description("Tolerance used for individual properties. When computing Hash or the property Diffing, if the analysed property name is found in this collection, the corresponding tolerance is applied." +
            "\nSupports * wildcard in the property name matching. E.g. `StartNode.Point.*, 2`." +
            "\nIf a match is found, this take precedence over the global `NumericTolerance`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual HashSet<NamedNumericTolerance> PropertyNumericTolerances { get; } = new HashSet<NamedNumericTolerance>();

        [Description("Number of significant figures allowed for numerical data." +
            "\nDefaults to `int.MaxValue`: no approximation applied." +
            "\nYou can override on a per-property basis by using `PropertySignificantDigits`." +
            "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual int SignificantFigures { get; } = int.MaxValue;

        [Description("Number of significant figures allowed for numerical data on a per-property base. " +
             "\nSupports * wildcard in the property name matching. E.g. `StartNode.Point.*, 2`." +
             "\nIf a match is found, this take precedence over the global `SignificantFigures`." +
             "\nIf conflicting values/multiple matches are found among the Configurations on numerical precision, the largest approximation among all (least precise number) is registered.")]
        public virtual HashSet<NamedSignificantFigures> PropertySignificantFigures { get; } = new HashSet<NamedSignificantFigures>();

        [Description("If true, geometric types will be identified based on the GeometryHash function. " +
            "This function reduces the identity of geometry down to its most basic components, and it is faster than scouring for all its properties. " +
            "See its implementation in the Geometry_Engine for more details.")]
        public virtual bool UseGeometryHash { get; } = true;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BaseComparisonConfig(HashSet<string> propertyExceptions = null, HashSet<string> propertiesToConsider = null,
            HashSet<string> customdataKeysExceptions = null, HashSet<string> customdataKeysToConsider = null,
            HashSet<Type> typeExceptions = null, HashSet<string> namespaceExceptions = null,
            int maxNesting = int.MaxValue, int maxPropertyDifferences = int.MaxValue,
            double numericTolerance = double.MinValue, HashSet<NamedNumericTolerance> propertyNumericTolerances = null,
            int significantFigures = int.MaxValue, HashSet<NamedSignificantFigures> propertySignificantFigures = null,
            bool useGeometryHash = false)
        {
            PropertyExceptions = propertyExceptions ?? new HashSet<string>();
            PropertiesToConsider = propertiesToConsider ?? new HashSet<string>();
            CustomdataKeysExceptions = customdataKeysExceptions ?? new HashSet<string>();
            CustomdataKeysToConsider = customdataKeysToConsider ?? new HashSet<string>();
            TypeExceptions = typeExceptions ?? new HashSet<Type>();
            NamespaceExceptions = namespaceExceptions ?? new HashSet<string>();
            MaxNesting = maxNesting < 0 ? int.MaxValue : maxNesting;
            MaxPropertyDifferences = maxPropertyDifferences < 0 ? int.MaxValue : maxPropertyDifferences;
            NumericTolerance = Math.Abs(numericTolerance);
            PropertyNumericTolerances = propertyNumericTolerances ?? new HashSet<NamedNumericTolerance>();
            SignificantFigures = Math.Abs(significantFigures);
            PropertySignificantFigures = propertySignificantFigures ?? new HashSet<NamedSignificantFigures>();
            UseGeometryHash = useGeometryHash;

            if (!UseGeometryHash)
                return;

            // Verify that no numerical approximation is requested for objects belonging to Geometrical types.
            if (PropertyNumericTolerances?.Where(p => p.Name.Contains("Geometry")).Any() ?? false)
                throw new ArgumentException($"Please note that the input {nameof(ComparisonConfig)}.{nameof(PropertyNumericTolerances)} will not be considered for Geometry objects because {nameof(UseGeometryHash)} was set to true.");

            if (PropertySignificantFigures?.Where(p => p.Name.Contains("Geometry")).Any() ?? false)
                throw new ArgumentException($"Please note that the input {nameof(ComparisonConfig)}.{nameof(PropertySignificantFigures)} will not be considered for Geometry objects because {nameof(UseGeometryHash)} was set to true.");
        }

        /***************************************************/
    }
}