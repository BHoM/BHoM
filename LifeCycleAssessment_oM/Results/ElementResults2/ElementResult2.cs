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
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.LifeCycleAssessment.Results
{
    public abstract class ElementResult2<TType, TMaterialResult> : IImmutable
        where TMaterialResult : MaterialResult2<TType>
        where TType : IMetricValue
    {
        /***************************************************/
        /**** Properties - Identifiers                  ****/
        /***************************************************/

        [Description("Id of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; protected set; } = "";

        [Description("Scope the object this result was generated from belongs to, e.g. Foundation or Facade")]
        public virtual ScopeType Scope { get; protected set; }

        [Description("Category of the object this result was generated from, e.g. Beam or Wall")]
        public virtual ObjectCategory Category { get; protected set; }

        [Description("Enum indicating the metric type the object relates to.")]
        public virtual EnvironmentalMetrics MetricType { get; protected set; }

        /***************************************************/
        /**** Properties - Material Breakdown           ****/
        /***************************************************/

        [Description("Result breakdown per material type.")]
        public virtual IReadOnlyList<TMaterialResult> MaterialResults { get; protected set; }

        /***************************************************/
        /**** Properties - Result properties            ****/
        /***************************************************/

        public abstract IReadOnlyDictionary<LifeCycleAssessmentPhases, TType> ResultValues { get; protected set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ElementResult2(IComparable objectId,
                              ScopeType scope, 
                              ObjectCategory category, 
                              EnvironmentalMetrics metricType, 
                              IReadOnlyList<TMaterialResult> materialResults,
                              IReadOnlyDictionary<LifeCycleAssessmentPhases, TType> resultValues)
        {
            ObjectId = objectId;
            Scope = scope;
            Category = category;
            MaterialResults = materialResults;
            MetricType = metricType;
            ResultValues = resultValues;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            if (other == null)
                return -1;

            ElementResult2<TType, TMaterialResult> otherRes = other as ElementResult2<TType, TMaterialResult>;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int i = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (i == 0)
            {
                int s = this.Scope.CompareTo(otherRes.Scope);
                if (s == 0)
                {
                    return this.Category.CompareTo(otherRes.Category);
                }
                else
                {
                    return s;
                }
            }
            else
            {
                return i;
            }
        }


        /***************************************************/
    }
}




