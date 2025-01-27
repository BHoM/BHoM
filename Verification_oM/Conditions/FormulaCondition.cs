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

using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Verification.Conditions
{
    [Description("Condition that verifies an object based on a given formula.")]
    public class FormulaCondition : ICondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Initial values to be extracted from the verified object." +
                     "\nKeys are the names of variables to be used in the calculations." +
                     "\nValues are value sources to extract the values from.")]
        public virtual Dictionary<string, IValueSource> Inputs { get; set; } = new Dictionary<string, IValueSource>();

        [Description("Formulae to calculate the variables to be verified in the verification formula." +
                     "\nFormulae can be chained, i.e. one calculated variable can be derived from the previously calculated ones." +
                     "\nKeys are the names of variables to be used in the calculations." +
                     "\nValues are the formulae correspondent to each given variable name.")]
        public virtual Dictionary<string, Formula> CalculationFormulae { get; set; } = new Dictionary<string, Formula>();

        [Description("Final formula to verify, needs to return a Boolean value, e.g. 'a > b'.")]
        public virtual Formula VerificationFormula { get; set; } = null;

        /***************************************************/
    }
}
