/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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

using BH.oM.Base.Attributes;
using System;
using System.ComponentModel;

namespace BH.oM.Serialiser.JsonSchema
{
    [Description("JSON Schema keyword that validates array elements at specific positions (tuple validation) with different schemas for each position.")]
    [DocumentationURL("https://json-schema.org/understanding-json-schema/reference/array#tupleValidation", Base.Attributes.Enums.DocumentationType.Documentation)]
    public class PrefixItemsKeyword : ISchemaKeyWord
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Array of JSON schemas where each schema validates the corresponding array element at the same index position (tuple-style validation).")]
        public virtual JsonSchema[] PreFixItems { get; set; }

        [Description("Indicates whether additional array elements beyond the defined prefix items are allowed. If false, the array cannot have more elements than defined in PreFixItems.")]
        public virtual bool AllowAdditional { get; set; }
        /***************************************************/
    }
}
