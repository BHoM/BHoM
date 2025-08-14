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
    [Description("Enumeration of JSON Schema primitive types used to specify the expected data type for validation.")]
    [DocumentationURL("https://json-schema.org/understanding-json-schema/reference/type#type-specific-keywords", Base.Attributes.Enums.DocumentationType.Documentation)]
    public enum SchemaType
    {
        [Description("JSON array type - an ordered list of values.")]
        array,
        
        [Description("JSON boolean type - true or false values.")]
        boolean,
        
        [Description("JSON integer type - whole numbers without decimal points.")]
        integer,
        
        [Description("JSON number type - numeric values including integers and floating-point numbers.")]
        number,
        
        [Description("JSON null type - represents null/empty values.")]
        @null,
        
        [Description("JSON object type - key-value pairs (dictionary/map structure).")]
        @object,
        
        [Description("JSON string type - textual data enclosed in quotes.")]
        @string,
    }
}
