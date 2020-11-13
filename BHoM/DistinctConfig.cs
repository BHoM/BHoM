/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
    [Description("Settings to determine the uniqueness of an Object.")]
    public class DistinctConfig : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("If any name is specified here, only properties corresponding to that name will be considered in the hash."
            + "\nThis has higher priority than PropertyNameExceptions.")]
        public List<string> PropertyNamesToConsider { get; set; } = new List<string>(); //e.g. `{ StartNode, EndNode }`

        [Description("Names of properties you want to disregard in defining the uniqueness of an object. `BHoM_Guid` is always added by default.")]
        public List<string> PropertyNameExceptions { get; set; } = new List<string>() { "BHoM_Guid" }; //e.g. `BHoM_Guid`

        [Description("If you want to exclude a specific property of an object. E.g. `BH.oM.Structure.Elements.Bar.Fragments`.")]
        public List<string> PropertyFullNameExceptions { get; set; } = new List<string>(); //e.g. `BH.oM.Structure.Elements.Bar.Fragments` – can use * wildcard here.

        [Description("Any corresponding namespace is ignored. E.g. `BH.oM.Structure`.")]
        public List<string> NamespaceExceptions { get; set; } = new List<string>(); //e.g. `BH.oM.Structure`

        [Description("Any corresponding type is ignored. E.g. `typeof(Guid)`.")]
        public List<Type> TypeExceptions { get; set; } = new List<Type>(); //e.g. `typeof(Guid)`

        [Description("Keys of the BHoMObjects' CustomData dictionary that should be ignored.\nBy default it includes `RenderMesh`.")]
        public virtual List<string> CustomdataKeysExceptions { get; set; } = new List<string>() { "RenderMesh" };

        [Description("If any property is nested into the object over that level, it is ignored. Defaults to 100.")]
        public int MaxNesting = 100;

        [Description("Determines the number of digits retained after the comma; applies rounding. Defaults to 1E-12, which corresponds to 12 digits.")]
        public double NumericTolerance = 1E-12;

        [Description("If a property name matches this, applies a rounding to the corresponding number of digits specified.\nSupports * wildcard. E.g. e.g. `{ { StartNode.Point.X, 2 } }`.")]
        public Dictionary<string, int> FractionalDigitsPerProperty = null; // e.g. { { StartNode.Point.X, 2 } } – can use * wildcard here.

        /***************************************************/
    }
}


