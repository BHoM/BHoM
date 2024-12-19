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

using System.ComponentModel;

namespace BH.oM.Verification.Conditions
{
    public class ValueCondition : IValueCondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Object defining the source of a value to evaluate.")]
        public virtual IValueSource ValueSource { get; set; } = null;

        [Description("Reference value to compare the extracted value against.")]
        public virtual object ReferenceValue { get; set; }

        [Description("Specifies whether the extracted value should be smaller, greater, etc. than the reference value.")]
        public virtual ValueComparisonType ComparisonType { get; set; } = ValueComparisonType.EqualTo;

        [Description("If applicable, tolerance to be considered in the comparison.")]
        public virtual object Tolerance { get; set; } = null;

        /***************************************************/
    }
}
