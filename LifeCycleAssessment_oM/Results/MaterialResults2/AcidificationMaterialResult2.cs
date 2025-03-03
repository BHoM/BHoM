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

using BH.oM.Analytical.Results;
using BH.oM.Base;
using BH.oM.LifeCycleAssessment.Results.MetricsValues;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.Results
{
    public abstract class AcidificationMaterialResult2 : MaterialResult2<AcidificationValue>
    {
        /***************************************************/
        /**** Properties - Identifiers                  ****/
        /***************************************************/


        /***************************************************/
        /**** Properties - Result properties            ****/
        /***************************************************/

        public override IReadOnlyDictionary<LifeCycleAssessmentPhases, AcidificationValue> ResultValues { get; protected set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AcidificationMaterialResult2(string materialName, string environmentalProductDeclarationName, EnvironmentalMetrics metricType, IReadOnlyDictionary<LifeCycleAssessmentPhases, AcidificationValue> resultValues
                        ) : base(materialName, environmentalProductDeclarationName, metricType, resultValues)
        {

        }

        /***************************************************/
    }
}


