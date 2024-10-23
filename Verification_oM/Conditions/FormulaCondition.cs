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

using System.Collections.Generic;

namespace BH.oM.Verification.Conditions
{
    //[Description("Identifies a Condition that verifies if a Property of the object is within a certain domain (range).")]
    public class FormulaCondition : ICondition
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        public virtual Dictionary<string, IValueSource> Inputs { get; set; } = new Dictionary<string, IValueSource>();

        public virtual List<string> CalculationFormulae { get; set; } = new List<string>();

        public virtual string VerificationFormula { get; set; } = "";

        public virtual double Tolerance { get; set; }

        /***************************************************/
    }
}


