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
    [Description("JSON Schema keyword that validates numeric data must be less than or equal to (or less than if exclusive) the specified maximum value.")]
    public class MaximumKeyword : ISchemaKeyWord
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The maximum numeric value that the data can have. The validation depends on the Exclusive property setting.")]
        public virtual double Value { get; set; }

        [Description("If true, then the reference needs to be strictly smaller than the value. If false, the reference needs to be smaller or equal to the value.")]
        public virtual bool Exclusive { get; set; } = false;

        /***************************************************/
    }
}
