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
using BH.oM.Verification.Conditions;
using BH.oM.Verification.Requirements;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Verification.Results
{
    public class RequirementResult : IImmutable
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        //[Description("The condition that was evaluated.")]
        public virtual IComparable RequirementId { get; }

        //[Description("The objects that passed the condition.")]
        public virtual IComparable ObjectId { get; }

        public virtual IConditionResult VerificationResult { get; }


        /***************************************************/
        /****                Constructor                ****/
        /***************************************************/

        public RequirementResult(IComparable requirementId, IComparable verifiedObjectId, IConditionResult verificationResult)
        {
            RequirementId = requirementId;
            ObjectId = verifiedObjectId;
            VerificationResult = verificationResult;
        }

        /***************************************************/
    }
}