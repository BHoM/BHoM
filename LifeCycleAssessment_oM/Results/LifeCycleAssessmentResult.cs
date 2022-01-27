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
using BH.oM.LifeCycleAssessment.MaterialFragments;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Base;
using System;
using System.Collections.ObjectModel;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Result class for a LifeCycleAssessment of a whole project. This is used to get the total quantity in terms of embodied carbon, acidification, etc. for a whole project.")]
    public class LifeCycleAssessmentResult : IObjectIdResult, ICasedResult, ITimeStepResult, IResultCollection<LifeCycleAssessmentElementResult>, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the project that this result is for.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Identifier for the case evaluated, e.g. GlobalWarmingPotential or Acidification")]
        public virtual IComparable ResultCase { get; } = "";

        [Description("Time step for time history results (This is unlikely for LCA).")]
        public virtual double TimeStep { get; } = 0.0;

        [Description("A LifeCycleAssessmentScope object containing project information for the LifeCycleAssessment")]
        public virtual LifeCycleAssessmentScope LifeCycleAssessmentScope { get; }

        [Description("A collection of the per element LifeCycleAssessment results")]
        public virtual ReadOnlyCollection<LifeCycleAssessmentElementResult> Results { get; }

        [Description("The total quantity of the specified EPD Field for all objects in the Project within the LCA Scope.")]
        public virtual double TotalQuantity { get; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LifeCycleAssessmentResult(IComparable objectId, IComparable resultCase, double timeStep, LifeCycleAssessmentScope lifeCycleAssessmentScope, ReadOnlyCollection<LifeCycleAssessmentElementResult> results, double totalQuantity)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            LifeCycleAssessmentScope = lifeCycleAssessmentScope;
            Results = results;
            TotalQuantity = totalQuantity;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, TimeStep")]
        public int CompareTo(IResult other)
        {
            LifeCycleAssessmentResult otherRes = other as LifeCycleAssessmentResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;
            }
            else
            {
                return n;
            }
        }

        /***************************************************/

    }
}



