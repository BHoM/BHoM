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

using BH.oM.LifeCycleAssessment.MaterialFragments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Analytical.Results;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Gives the total quantity of the specified Environmental Product Declaration Field of an object based on its EnvironmentalProductDeclaration.")]
    public class EnvironmentalMetricResult : LifeCycleAssessmentElementResult, IImmutable, IObjectResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The total quantity of the specified Field within the object.")]
        public virtual double Quantity { get; set; }

        [Description("The EPD Field selected for evaluation.")]
        public virtual EnvironmentalProductDeclarationField Metric { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EnvironmentalMetricResult(IComparable objectId,
                                IComparable resultCase,
                                double timeStep,
                                ScopeType scope,
                                ObjectCategory category,
                                List<LifeCycleAssessmentPhases> phases,
                                List<EnvironmentalProductDeclaration> environmentalProductDeclaration,
                                double quantity,
                                EnvironmentalProductDeclarationField metric): base(objectId, resultCase, timeStep, scope, category, phases, environmentalProductDeclaration)
        {
            Quantity = quantity;
            Metric = metric;
        }

        /***************************************************/

    }
}




