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
        public virtual double GlobalWarmingPotential { get; } = double.NaN;

        [Description("The project's GWP/m2 (kgCO2e/m2).")]
        public virtual double GlobalWarmingPotentialPerArea { get; } = double.NaN;

        [Description("The primary structural system providing lateral support for the building.")]
        public virtual string LateralStructuralMaterial { get; } = "";

        [Description("Phases included in the LCA concatenated (A1A2A3).")]
        public virtual string Phases { get; } = "";

        [Description("Typically a term utilised in BIM practices to clearly identify the scope of work being account for. Equivalents for LOD classifications can offen times be linked to design and construction phases common to the projects locale.")]
        public virtual string LevelOfDevelopment { get; } = "";

        [Description("The Area (m2) to used for the basis of kgCO2eq/m2 metrics.")]
        [Area]
        public virtual double Area { get; } = double.NaN;

        [Description("The project number or other unique identifier.")]
        public virtual string ProjectID { get; } = "";

        [Description("ID of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Identifier for the case evaluated, e.g. GlobalWarmingPotential or Acidification")]
        public virtual IComparable ResultCase { get; } = "";

        [Description("Time step for time history results (This is unlikely for LCA).")]
        public virtual double TimeStep { get; } = 0.0;

        [Description("Time that the result was generated.")]
        public virtual System.DateTime DateTime { get; } = System.DateTime.Now;

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
                                string projectId,
                                IComparable objectId,
                                IComparable resultCase,
                                double timeStep,
                                DateTime date)
        {
            BuildingLifespan = buildingLifespan;
            ConstructionScope = constructionScope;
            ContactName = contactName;
            ElementScope = elementScope;
            GravityStructuralMaterial = gravityStructuralMaterial;
            GlobalWarmingPotential = gwp;
            GlobalWarmingPotentialPerArea = gwpPerArea;
            LateralStructuralMaterial = lateralStructuralMaterial;
            Phases = lcaPhases;
            LevelOfDevelopment = levelOfDevelopment;
            ProjectID = projectId;
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            DateTime = date;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

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


