/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Verification.Conditions
{
    [Description("Formula in a form of a string in a specific convention, used to calculate values in verification workflows.")]
    public class Formula : IObject
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Equation in a form of a string, resulting in either numerical, string or Boolean values." +
                     "\nOnly basic mathematical operators are currently supported." +
                     "\nStrings need to be wrapped in single quotation marks (')." +
                     "\nEnum values need to stay unwrapped and expressed only with the value itself (e.g. MyValue instead of MyEnum.MyValue)." +
                     "\nExamples of valid formule:" +
                     "\n(a + b) * 2" +
                     "\na == b * 2" +
                     "\na == 'StringValue'" +
                     "\na == EnumValue" +
                     "\na == 'StringValueA' or (a == 'StringValueB' and b == 'StringValueC')" +
                     "\nif a == 0: 'zero', else if a == 1: 'one', else if a == 2: 'two', else: 'not supported'" +
                     "\nif a == b and a == c: 'all values equal', else: 'values not equal'")]
        public virtual string Equation { get; set; } = "";

        [Description("Tolerance to be applied when evaluating the formula.")]
        public virtual object Tolerance { get; set; } = 1e-6;

        /***************************************************/
    }
}
