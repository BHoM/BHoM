/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using BH.oM.Base;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Life Cycle Assessment Scope object intends to provide a means of reporting all of the project criteria (name, area, type, location) as well as the objects that the study encompassed (structural slabs, foundation walls, etc) along with their properties for the Enviornmental Product Declarations they used (when using SetProperty), their densities and volumes. This object may be used for studies at any stage of development and can serve as a true means of 'apples to apples' comparison when catalogued.")]
    public class LifeCycleAssessmentScope : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual LevelOfDevelopment LevelOfDevelopment { get; set; } = LevelOfDevelopment.Undefined;
        public virtual LifeCycleAssessmentPhases LifeCycleAssessmentPhases { get; set; } = LifeCycleAssessmentPhases.Undefined;
        public virtual PrimaryStructuralMaterial PrimaryStructuralMaterial { get; set; } = PrimaryStructuralMaterial.Undefined;
        public virtual ProjectArea ProjectArea { get; set; } = ProjectArea.Undefined;
        public virtual ProjectType ProjectType { get; set; } = ProjectType.Undefined;

        [Description ("The Project Name denotes the name of the project (eg Mercedes-Benz Stadium)")]
        public virtual string ProjectName { get; set; } = "Please provided a project name.";
        
        [Description("The Contact Name denotes the person/people who performed the LCA study.")]
        public virtual string ContactName { get; set; } = "No contact provided.";
        
        [Description("The Actual Project Area denotes the more precise project area (m2) which will allow assessment of kgCO2eq/m2 metrics")]
        public virtual double ActualProjectArea { get; set; } = double.NaN;
        
        [Description("Biogenic Carbon is a true/false that indicates that the project contains materials that originated from a biological source (trees, soil), these materials have the ability sequester/store carbon.")]
        public virtual bool BiogenicCarbon { get; set; } = false;
        
        [Description("Zip Code is the means of tracking the project's location")]
        public virtual int ZipCode { get; set; } = 00000;
      
        [Description("Additional notes should convey project design constraints (eg design for seismic activity) that could affect the overall embodied carbon")]
        public virtual string AdditionalNotes { get; set; } = "None";

        /***************************************************/
    }
}
