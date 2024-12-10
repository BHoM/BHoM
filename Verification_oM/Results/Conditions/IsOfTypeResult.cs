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

using BH.oM.Base;
using BH.oM.Verification.Conditions;
using System;
using System.ComponentModel;

namespace BH.oM.Verification.Results
{
    [Description("Object representing result of " + nameof(IsOfType) + " condition.")]
    public class IsOfTypeResult : IConditionResult, IImmutable
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Information whether the object passed or failed the condition. Null means inconclusive result.")]
        public virtual bool? Passed { get; } = false;

        [Description("Type of the checked object.")]
        public virtual Type ExtractedType { get; } = null;


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public IsOfTypeResult(bool? passed, Type extractedType)
        {
            Passed = passed;
            ExtractedType = extractedType;
        }

        /***************************************************/
    }
}
