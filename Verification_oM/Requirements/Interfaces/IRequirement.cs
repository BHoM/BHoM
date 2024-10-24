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
using BH.oM.Data.Library;
using System.ComponentModel;

namespace BH.oM.Verification.Requirements
{
    public interface IRequirement : IBHoMObject
    {
        //[Description("Unique identifier to reference the Condition within a set.")]
        string Clause { get; set; }

        //[Description("Name given to this Condition.")]
        //string Name { get; set; }

        //[Description("Source material for this Condition. E.g. Codes, best practices, guidelines, etc.")]
        Source Source { get; set; }

        [Description("Any additional notes.")]
        string Comment { get; set; }

        [Description("Human-readable message explaining what does the failure mean to the user.")]
        string FailureMessage { get; set; }

        [Description("Severity of condition failure, originating from the concept that not all conditions are necessarily errors.")]
        FailureSeverity Severity { get; set; }
    }
}


