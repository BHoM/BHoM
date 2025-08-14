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

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Serialiser.JsonSchema
{
    [Description("JSON Schema keyword that defines reusable schema definitions that can be referenced elsewhere in the schema using $ref.")]
    public class DefsKeyword : ISchemaKeyWord
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Dictionary of named schema definitions that can be referenced by other parts of the schema. The key is the definition name and the value is the corresponding JSON schema.")]
        public virtual Dictionary<string, JsonSchema> Definitions { get; set; } = new Dictionary<string, JsonSchema>();

        /***************************************************/
    }
}
