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

using BH.oM.Base;
using BH.oM.Data.Library;
using BH.oM.Verification.Conditions;
using BH.oM.Verification.Reporting;
using BH.oM.Verification.Specifications;
using System.ComponentModel;

namespace BH.oM.Verification.Requirements
{
    [Description("Object representing a single, condition-based requirement to run against each object in a set filtered based on " + nameof(Specification) + "." +  nameof(Specification.Extraction) +
                 "Also contains the config required to represent the verification results in a human friendly form.")]
    public class Requirement : BHoMObject, IRequirement
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Human readable identifier to reference the Requirement.")]
        public virtual string Clause { get; set; }

        [Description("Source material for this Requirement. E.g. Codes, best practices, guidelines, etc.")]
        public virtual Source Source { get; set; }

        [Description("Any additional notes.")]
        public virtual string Comment { get; set; }

        [Description("General, human-readable message explaining what does the failure mean to the user.")]
        public virtual string FailureMessage { get; set; }

        [Description("Severity of Requirement failure, originating from the concept that not all conditions are necessarily errors.")]
        public virtual FailureSeverity Severity { get; set; } = FailureSeverity.Error;

        [Description("Condition to be met for an object to pass a Requirement.")]
        public virtual ICondition Condition { get; set; } = null;

        [Description("Reporting config containing settings needed to present the verification results in a human friendly form.")]
        public virtual IConditionReportingConfig ReportingConfig { get; set; } = null;

        /***************************************************/
    }
}

