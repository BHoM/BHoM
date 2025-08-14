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
using System.ComponentModel;

namespace BH.oM.Serialiser.JsonSchema
{
    [Description("JSON Schema keyword that implements conditional validation using if-then-else logic.")]
    public class IfKeyword : ISchemaKeyWord
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The condition schema that is evaluated first. If the data validates against this schema, the Then schema is applied.")]
        public virtual JsonSchema If { get; set; }

        [Description("The schema that is applied when the If condition is satisfied. This schema must be valid for the overall validation to pass.")]
        public virtual JsonSchema Then { get; set; }

        [Description("The schema that is applied when the If condition is not satisfied. This schema must be valid for the overall validation to pass.")]
        public virtual JsonSchema Else { get; set; }

        /***************************************************/
    }
}
