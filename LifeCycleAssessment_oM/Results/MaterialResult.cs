/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BH.oM.LifeCycleAssessment.Results
{
    [Description("Life Cycle Assessment result for a Material/Environmental Product Declaration evaluated.")]
    public class MaterialResult : IResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Name of the physical material evaluated.")]
        public virtual string MaterialName { get; }

        [Description("Name of the Environmental Product Declaration evaluated.")]
        public virtual string EnvironmentalProductDeclarationName { get; }

        [Description("The total quantity of the specified Field within the object.")]
        public virtual double Quantity { get; }

        [Description("Phase of life abbreviation for the scope of the Environmental Product Declaration. A single EnvironmentalMetric can contain either a single Phase or a list of Phases i.e. A1, A2, A3.")]
        public virtual IReadOnlyList<LifeCycleAssessmentPhases> Phases { get; }

        [Description("The Environmental Product Declaration Field selected for evaluation.")]
        public virtual EnvironmentalProductDeclarationField Metric { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MaterialResult(string materialName, string environmentalProductDeclarationName, IReadOnlyList<LifeCycleAssessmentPhases> phases, double quantity, EnvironmentalProductDeclarationField metric)
        {
            MaterialName = materialName;
            EnvironmentalProductDeclarationName = environmentalProductDeclarationName;
            Phases = phases;
            Quantity = quantity;
            Metric = metric;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MaterialResult otherRes = other as MaterialResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.Metric.CompareTo(otherRes.Metric);
            if (n == 0)
            {
                int l = this.MaterialName.CompareTo(otherRes.MaterialName);
                if (l == 0)
                {
                    return this.MaterialName.CompareTo(otherRes.MaterialName);
                }
                else
                {
                    return l;
                }
            }
            else
            {
                return n;
            }
        }

        /***************************************************/
    }
}

