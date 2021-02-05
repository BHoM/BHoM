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

using BH.oM.Analytical.Results;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("A collection of simplified project results commonly used for database collection.")]
    public partial class ProjectLifeCycleAssessmentResult : IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The proposed lifespan of the project scope after completion.")]
        public virtual double BuildingLifespan { get; } = double.NaN;

        [Description("Scope of the project typically new build or renovation.")]
        public virtual string ConstructionScope { get; } = "";

        [Description("Name of the individual compiling the results.")]
        public virtual string ContactName { get; } = "";

        [Description("Discipline scopes included in the LCA.")]
        public virtual string ElementScope { get; } = "";

        [Description("The primary structural system providing gravity support for the building.")]
        public virtual string GravityStructuralMaterial { get; } = "";

        [Description("The project total GlobalWarmingPotential (kgCO2e).")]
        public virtual double Gwp { get; } = double.NaN;

        [Description("The project's GWP/m2 (kgCO2e/m2).")]
        public virtual double GwpPerArea { get; } = double.NaN;

        [Description("The primary structural system providing lateral support for the building.")]
        public virtual string LateralStructuralMaterial { get; } = "";

        [Description("Phases included in the LCA concatenated (A1A2A3).")]
        public virtual string LcaPhases { get; } = "";

        [Description("Typically a term utilised in BIM practices to clearly identify the scope of work being account for. Equivalents for LOD classifications can offen times be linked to design and construction phases common to the projects locale.")]
        public virtual string LevelOfDevelopment { get; } = "";

        [Description("The Project Area (m2) denotes the more precise project area which will allow assessment of kgCO2eq/m2 metrics.")]
        [Area]
        public virtual double ProjectArea { get; } = double.NaN;

        [Description("The project's unique identifier.")]
        public virtual string ProjectId { get; } = "";

        [Description("The project's location in Lat Long format.")]
        public virtual string ProjectLocation { get; } = "";

        [Description("The project's name.")]
        public virtual string ProjectName { get; } = "";

        [Description("A general classification of the buildings primary function. This value is for categorisation purposes only and will not effect the overall results.")]
        public virtual string ProjectType { get; } = "";

        [Description("Id of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Identifier for the case evaluated, e.g. GlobalWarmingPotential or Acidification")]
        public virtual IComparable ResultCase { get; } = "";

        [Description("Time step for time history results (This is unlikely for LCA).")]
        public virtual double TimeStep { get; } = 0.0;

        [Description("Time step for time history results (This is unlikely for LCA).")]
        public virtual string Date { get; } = "";

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ProjectLifeCycleAssessmentResult(double buildingLifespan,
                                string constructionScope,
                                string contactName,
                                string elementScope,
                                string gravityStructuralMaterial,
                                double gwp,
                                double gwpPerArea,
                                string lateralStructuralMaterial,
                                string lcaPhases,
                                string levelOfDevelopment,
                                double projectArea,
                                string projectId,
                                string projectLocation,
                                string projectName,
                                string projectType,
                                IComparable objectId,
                                IComparable resultCase,
                                double timeStep,
                                string date)
        {
            BuildingLifespan = buildingLifespan;
            ConstructionScope = constructionScope;
            ContactName = contactName;
            ElementScope = elementScope;
            GravityStructuralMaterial = gravityStructuralMaterial;
            Gwp = gwp;
            GwpPerArea = gwpPerArea;
            LateralStructuralMaterial = lateralStructuralMaterial;
            LcaPhases = lcaPhases;
            LevelOfDevelopment = levelOfDevelopment;
            ProjectArea = projectArea;
            ProjectId = projectId;
            ProjectLocation = projectLocation;
            ProjectName = projectName;
            ProjectType = projectType;
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            Date = date;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        // TODO - Edit

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, Scope, Category, TimeStep")]
        public int CompareTo(IResult other)
        {
            ProjectLifeCycleAssessmentResult otherRes = other as ProjectLifeCycleAssessmentResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectId = this.ObjectId.CompareTo(otherRes.ObjectId);

            return objectId;
        }

        /***************************************************/
    }
}



