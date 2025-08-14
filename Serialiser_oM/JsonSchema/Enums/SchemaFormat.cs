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
    [Description("Enumeration of semantic formats that can be applied to string data for additional validation.")]
    [DocumentationURL("https://json-schema.org/understanding-json-schema/reference/type#format", Base.Attributes.Enums.DocumentationType.Documentation)]
    public enum SchemaFormat
    {
        [Description("Date format (YYYY-MM-DD) as defined by RFC 3339.")]
        date,
        
        [Description("Date and time format (YYYY-MM-DDTHH:mm:ssZ) as defined by RFC 3339.")]
        date_time,
        
        [Description("Duration format as defined by ISO 8601 (e.g., P3Y6M4DT12H30M5S).")]
        duration,
        
        [Description("Regular expression pattern format.")]
        regex,
        
        [Description("Universally Unique Identifier format as defined by RFC 4122.")]
        uuid,
    }
}
