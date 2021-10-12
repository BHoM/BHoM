/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
    public class ComparisonConfig : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Names of properties you want to disregard in defining the uniqueness of an object. `BHoM_Guid` is always added by default. Supports * wildcard (see examples below)."
            + "\nExamples of valid values: `BHoM_Guid`, `StartNode`, `Bar.StartNode.Point.X`, `Bar.*.Point.Y`")] 
        public virtual List<string> PropertyExceptions { get; set; } = new List<string>() { "BHoM_Guid" }; //e.g. `BHoM_Guid`

        [Description("Any corresponding namespace is ignored. E.g. `BH.oM.Structure`.")]
        public virtual List<string> NamespaceExceptions { get; set; } = new List<string>(); //e.g. `BH.oM.Structure`

        [Description("Any corresponding type is ignored. E.g. `typeof(Guid)`.")]
        public virtual List<Type> TypeExceptions { get; set; } = new List<Type>(); //e.g. `typeof(Guid)`

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be exclusively included. Adding keys to this List will exclude any key that is not in this List. I.e. for every object, if it has CustomData keys present in this List, we then exclude any other CustomData key found in it.")]
        public virtual List<string> CustomdataKeysToInclude { get; set; } = new List<string>() {  };

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be ignored.\nBy default it includes `RenderMesh`.")]
        public virtual List<string> CustomdataKeysExceptions { get; set; } = new List<string>() { "RenderMesh" };

        [Description("If any name is specified here, only properties corresponding to that name will be considered in the hash." +
           "\nE.g. For BH.oM.Structure.Elements.Bar, specifying `StartNode` will only check if that property is different." +
           "\nYou can List specify sub-properties or partial paths, e.g. `StartNode.Name` or `*.Name`.")]
        public virtual List<string> PropertiesToConsider { get; set; } = new List<string>(); //e.g. `{ StartNode, EndNode }`

        [Description("If any property is nested into the object over that level, it is ignored. Defaults to 100.")]
        public virtual int MaxNesting { get; set; } = 100;

        [Description("Numeric tolerance for property values, applied to all numerical properties. Applies rounding for numbers smaller than this. Defaults to 1E-12.")]
        public virtual double NumericTolerance { get; set; } = 1E-12;

        [Description("Number of fractional digits retained for individual property. If a property name matches a key in the dictionary, applies a rounding to the corresponding number of digits."
            + "\nSupports * wildcard in the property name matching. E.g. `{ { StartNode.Point.*, 2 } }`.")]
        public virtual Dictionary<string, int> FractionalDigitsPerProperty { get; set; } = null; // e.g. { { StartNode.Point.X, 2 } } - can use * wildcard here.

        [Description("Additional functions that can be specified as delegates and that will be executed while comparing.")]
        public virtual ComparisonFunctions ComparisonFunctions { get; set; } = new ComparisonFunctions();

        /***************************************************/
    }
}


