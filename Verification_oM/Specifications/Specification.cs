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
using BH.oM.Verification.Extraction;
using BH.oM.Verification.Requirements;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Verification.Specifications
{
    [Description("A top level object in verification workflow. Contains the information about the whole workflow, from extraction, to checking, to reporting.")]
    public class Specification : BHoMObject, ISpecification
    {
        /***************************************************/
        /****                Properties                 ****/
        /***************************************************/

        [Description("Human readable identifier to reference the Specification.")]
        public virtual string Clause { get; set; }

        [Description("Description of the Specification.")]
        public virtual string Description { get; set; }

        [Description("Object describing how to extract the objects to be verify against Requirements.")]
        public virtual IExtraction Extraction { get; set; }

        [Description("A collection of objects, each containing an atomic check together with reporting config and metadata.")]
        public virtual List<IRequirement> Requirements { get; set; }

        /***************************************************/
    }
}

