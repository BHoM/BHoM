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

using BH.oM.Analytical.Results;
using BH.oM.Base;
using BH.oM.LifeCycleAssessment.MaterialFragments;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Base class for a LifeCycleAssessment of a single object. This contains the total quantity of global warming potential, acidification potential, etc. for a whole project.")]
    public abstract class LifeCycleAssessmentElementResult : IObjectIdResult, ICasedResult, ITimeStepResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Identifier for the case evaluated, e.g. GlobalWarmingPotential or Acidification")]
        public virtual IComparable ResultCase { get; } = "";

        [Description("Time step for time history results (This is unlikely for LCA).")]
        public virtual double TimeStep { get; } = 0.0;

        [Description("Scope the object this result was generated from belongs to, e.g. Foundation or Facade")]
        public virtual ObjectScope Scope { get; } = ObjectScope.Undefined;

        [Description("Category of the object this result was generated from, e.g. Beam or Wall")]
        public virtual ObjectCategory Category { get; } = ObjectCategory.Undefined;

        [Description("Phase of life abbreviation for the scope of the EPD. A single EnvironmentalMetric can contain either a single Phase or a list of Phases i.e. A1, A2, A3.")]
        public virtual List<LifeCycleAssessmentPhases> Phases { get; } = new List<LifeCycleAssessmentPhases>();

        [Description("The EnvironmentalProductDeclaration used to generate this result.")]
        public virtual List<EnvironmentalProductDeclaration> EnvironmentalProductDeclaration{ get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected LifeCycleAssessmentElementResult(   IComparable objectId,
                                IComparable resultCase,
                                double timeStep,
                                ObjectScope scope,
                                ObjectCategory category,
                                List<LifeCycleAssessmentPhases> phases,
                                List<EnvironmentalProductDeclaration> environmentalProductDeclaration)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            Scope = scope;
            Category = category;
            Phases = phases;
            EnvironmentalProductDeclaration = environmentalProductDeclaration;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, Scope, Category, TimeStep")]
        public int CompareTo(IResult other)
        {
            LifeCycleAssessmentElementResult otherRes = other as LifeCycleAssessmentElementResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int objectId = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (objectId == 0)
            {
                int resultcase = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (resultcase == 0)
                {
                    int scope = this.Scope.CompareTo(otherRes.Scope);
                    if (scope == 0)
                    {
                        int cat = this.Category.CompareTo(otherRes.Category);
                        return cat == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : cat;
                    }
                    else { return scope; }
                }
                else { return resultcase; }
            }
            else { return objectId; }
        }

        /***************************************************/
    }
}




