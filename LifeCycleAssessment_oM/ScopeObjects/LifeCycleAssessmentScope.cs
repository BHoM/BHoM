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

using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;

namespace BH.oM.LifeCycleAssessment
{
    [Description("The Life Cycle Assessment Scope object intends to provide a means of reporting all of the project criteria (name, area, type, location). This object may be used for studies at any stage of development and can serve as a true means of 'apples to apples' comparison when catalogued. The information provided within this object is utilised for database construction and organisation only, therefore all values will not effect the overall life cycle assessment results.")]
    public class LifeCycleAssessmentScope : BHoMObject, IScope
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Additional notes should convey project design constraints (eg design for seismic activity) that could affect the overall embodied carbon.")]
        public virtual string AdditionalNotes { get; set; } = "N/A";

        [Description("Biogenic Carbon is a true/false that indicates that the project contains materials that originated from a biological source (trees, soil), these materials have the ability sequester/store carbon.")]
        public virtual bool BiogenicCarbon { get; set; } = false;

        [Description("The assumed lifespan of the building being evaluated.  These values are for categorisation purposes only and will not effect the overall results.")]
        public virtual int BuildingLifespan { get; set; } = 0;

        [Description("Identifies the overall construction scope for the project. Set True if New Construction exists within your project.")]
        public virtual bool ConstructionScopeNew { get; set; } = false;

        [Description("Identifies the overall construction scope for the project. Set True if Renovation exists within your project.")]
        public virtual bool ConstructionScopeRenovation { get; set; } = false;

        [Description("The Contact Name denotes the person/people who performed the LCA study.")]
        public virtual string ContactName { get; set; } = "No contact provided.";

        [Description("The primary structural system providing gravity support for the building.")]
        public virtual GravityStructuralMaterial GravityStructuralMaterial { get; set; } = GravityStructuralMaterial.Undefined;

        [Description("The primary structural system providing lateral support for the building.")]
        public virtual LateralStructuralMaterial LateralStructuralMaterial { get; set; } = LateralStructuralMaterial.Undefined;

        [Description("Typically a term utilised in BIM practices to clearly identify the scope of work being account for. Equivalents for LOD classifications can offen times be linked to design and construction phases common to the projects locale.")]
        public virtual LevelOfDevelopment LevelOfDevelopment { get; set; } = LevelOfDevelopment.Undefined;
        
        [Description("This is a list of life cycle assessment phases to be accounted for within this assessment. These values are for categorisation purposes only and will not effect the overall results.")]
        public virtual List<LifeCycleAssessmentPhases> LifeCycleAssessmentPhases { get; set; } = new List<LifeCycleAssessmentPhases>();

        [Description("A general classification of the buildings primary function. This value is for categorisation purposes only and will not effect the overall results.")]
        public virtual ProjectType ProjectType { get; set; } = ProjectType.Undefined;

        [Description ("The Project Name denotes the name of the project for reporting purposes.")]
        public virtual string ProjectName { get; set; } = "Please provided a project name.";
        
        [Description("The Project Area (m2) denotes the more precise project area which will allow assessment of kgCO2eq/m2 metrics.")]
        [Area]
        public virtual double ProjectArea { get; set; } = double.NaN;

        [Description("Seismic Design Category is a classification assigned to a structure based on it's occupancy category, and the severity of the design earthquake ground motion. These categories are currently in reference to ASCE 7-05.")]
        public virtual SeismicDesignCategory SeismicDesignCategory { get; set; } = SeismicDesignCategory.Undefined;

        [Description("Wind speed category is in reference to the Beaufort Scale of wind speeds. Values are arranged from 0-12 equivalent, 0 being Calm and 12 being Hurricane, and are used only to represent an average site-based, wind condition. Specific informaion on categorisation can be found at https://www.spc.noaa.gov/faq/tornado/beaufort.html")]
        public virtual WindSpeedCategory WindSpeedCategory { get; set; } = WindSpeedCategory.Undefined;

        [Description("Provide the projects geographic location for database organisation purposes. This value is for categorisation purposes only and will not effect the overall results.")]
        public virtual BH.oM.Environment.Climate.Location Location { get; set; } = null;

        /***************************************************/
    }
}


