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
using BH.oM.Quantities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.LifeCycleAssessment.MaterialFragments
{
    [Description("Base class for all environmental metrics.")]
    public abstract class EnvironmentalMetric2<T> : BHoMObject, IImmutable, IDynamicPropertyProvider where T : IQuantity
    {
        [Description("Enum indicating the metric type the object relates to.")]
        public virtual EnvironmentalMetrics MetricType { get; protected set; }

        [Description("")]
        public abstract Dictionary<LifeCycleAssessmentPhases, T> Values { get; protected set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public EnvironmentalMetric2(EnvironmentalMetrics metricType, Dictionary<LifeCycleAssessmentPhases, T> values)
        {
            MetricType = metricType;
            Values = values;
        }

        /***************************************************/
    }
}


