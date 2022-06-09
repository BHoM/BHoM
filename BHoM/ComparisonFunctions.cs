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
    [Description("Additional functions that can be specified as delegates and that will be executed while determining the uniqueness of an object, i.e. when comparing and when computing the object Hash.")]
    public class ComparisonFunctions : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("This function is executed every time a 'property full name' is considered, and it modifies it." +
            "\nA `property full name` is the full property path, e.g. for a property named `Position`, the full name could be `BH.oM.Structure.Elements.Node.Position` or `BH.oM.Structure.Elements.Bar.StartNode.Position`, etc., depending on the object being considered." +
            "\nFirst parameter (`string`): property full name. Second parameter (`object`): the object holding this property. Return value (`string`): the modified property name." +
            "\nExample of property path: if interested in the property `Position`, the property path can be specified as `BH.oM.Structure.Elements.Node.Position` or `BH.oM.Structure.Elements.Bar.StartNode.Position`, etc., depending on the object being considered, or simply as `Position` if any property named as such is to be matched.")]
        public virtual Func<string, object, string> PropertyFullNameModifier { get; set; } = null;

        [Description("A filter function on each 'property full name' being considered during comparison." +
            "\nA `property full name` is the full property path, e.g. for a property named `Position`, the full name could be `BH.oM.Structure.Elements.Node.Position` or `BH.oM.Structure.Elements.Bar.StartNode.Position`, etc., depending on the object being considered." + 
            "\nIf the Func returns true, the property is skipped (not considered when comparing or computing the Hash)." +
            "\nFirst parameter (`string`): property full name. Second parameter (`object`): the object holding this property. Return value (`bool`): true if the property is to be skipped, false otherwise.")]
        public virtual Func<string, object, bool> PropertyFullNameFilter { get; set; } = null;

        [Description("A filter function on CustomData keys. If the Func returns true, the key is skipped (not considered when comparing or computing the Hash)."+
            "\nFirst parameter (`string`): Custom Data key. Second parameter (`object`): the CustomData dictionary. Return value (`bool`): true if the key is to be skipped, false otherwise.")]
        public virtual Func<string, object, bool> CustomDataKeyFilter { get; set; } = null;


        [Description("This function is executed before a 'property full name' is returned as a difference, and it modifies it." +
            "\nA `property full name` is the full property path, e.g. for a property named `Position`, the full name could be `BH.oM.Structure.Elements.Node.Position` or `BH.oM.Structure.Elements.Bar.StartNode.Position`, etc., depending on the object being considered." +
            "\nFirst parameter (`string`): property full name. Second parameter (`object`): the object holding this property. Return value (`string`): the modified property name." +
            "\nExample of property path: if interested in the property `Position`, the property path can be specified as `BH.oM.Structure.Elements.Node.Position` or `BH.oM.Structure.Elements.Bar.StartNode.Position`, etc., depending on the object being considered, or simply as `Position` if any property named as such is to be matched.")]
        public virtual Func<string, object, string> PropertyDisplayNameModifier { get; set; } = null;

        /***************************************************/
    }
}



