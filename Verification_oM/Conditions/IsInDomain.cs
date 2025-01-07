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

using BH.oM.Data.Collections;
using System.ComponentModel;

namespace BH.oM.Verification.Conditions
{
    [Description("Condition that verifies if a value extracted from an object is within a certain domain (range).")]
    public class IsInDomain : IValueCondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Object defining the source of a value to evaluate.")]
        public virtual IValueSource ValueSource { get; set; } = null;

        [Description("Reference value that the extracted value is compared to.")]
        public virtual Domain Domain { get; set; }

        [Description("If applicable, tolerance to be applied in the comparison.")]
        public virtual double Tolerance { get; set; }

        /***************************************************/
    }
}

