/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Life Cycle Assessment Scope object intends to provide a means of reporting all of the project criteria (name, area, type, location) as well as the objects that the study encompassed (structural slabs, foundation walls, etc) along with their properties for the Enviornmental Product Declarations they used (when using SetProperty), their densities and volumes. This object may be used for studies at any stage of development and can serve as a true means of 'apples to apples' comparison when catalogued.")]
    public class ProjectLifeCycleAssessment : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The Life Cycle Assessment Scope object intends to provide a means of reporting all of the project criteria (name, area, type, location) as well as the objects that the study encompassed (structural slabs, foundation walls, etc) along with their properties for the Enviornmental Product Declarations they used (when using SetProperty), their densities and volumes. This object may be used for studies at any stage of development and can serve as a true means of 'apples to apples' comparison when catalogued.")]
        public virtual LifeCycleAssessmentScope LifeCycleAssessmentScope { get; set; } = new LifeCycleAssessmentScope();

        [Description("The Structures Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
        public virtual StructuresScope StructuresScope { get; set; } = new StructuresScope();

        [Description("The Enclosures Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
        public virtual EnclosuresScope EnclosuresScope { get; set; } = new EnclosuresScope();

        [Description("The Foundations Scope object provides a template for expected objects commonly assessed within Life Cycle Assessments. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
        public virtual FoundationsScope FoundationsScope { get; set; } = new FoundationsScope();

        [Description("The MEP Scope object provides a template for expected objects to be assessed within this Life Cycle Assessments. Note that this category is not commonly assessed, but will provide for higher quality results. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
        public virtual MEPScope MEPScope { get; set; } = new MEPScope();

        [Description("The Tenant Improvement Scope object provides a template for expected objects to be assessed within this Life Cycle Assessments. Note that this category is not commonly assessed, but will provide for higher quality results. Please provide as many objects with their corresponding Environmental Product Declaration data for the most accurate Life Cycle Assessment.")]
        public virtual TenantImprovementScope TenantImprovementScope { get; set; } = new TenantImprovementScope();

        /***************************************************/
    }
}


