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
    public abstract class MaterialResult : ILifeCycleAssesmentResult, IImmutable
    {
        /***************************************************/
        /**** Properties - Identifiers                  ****/
        /***************************************************/

        [Description("Name of the physical material evaluated.")]
        public virtual string MaterialName { get; }

        [Description("Name of the Environmental Product Declaration evaluated.")]
        public virtual string EnvironmentalProductDeclarationName { get; }

        [Description("Enum indicating the metric type the object relates to.")]
        public abstract EnvironmentalMetrics MetricType { get; }

        /***************************************************/
        /**** Properties - Result properties            ****/
        /***************************************************/

        [Description("Resulting values due to the Raw materials in the product stage.")]
        public abstract double A1 { get; }

        [Description("Resulting values due to the Transport in the product stage.")]
        public abstract double A2 { get; }

        [Description("Resulting values due to the Manufacturing in the product stage.")]
        public abstract double A3 { get; }

        [Description("Resulting values due to the full product stage.")]
        public abstract double A1toA3 { get; }

        [Description("Resulting values due to the transport during the assembly stage.")]
        public abstract double A4 { get; }

        [Description("Resulting values due to the final assembly during the assembly stage.")]
        public abstract double A5 { get; }

        [Description("Resulting values due to the general use during the usage stage.")]
        public abstract double B1 { get; }

        [Description("Resulting values due to the maintance during the usage stage.")]
        public abstract double B2 { get; }

        [Description("Resulting values due to the repair during the usage stage.")]
        public abstract double B3 { get; }

        [Description("Resulting values due to the replacement during the usage stage.")]
        public abstract double B4 { get; }

        [Description("Resulting values due to the refurbishment during the usage stage.")]
        public abstract double B5 { get; }

        [Description("Resulting values due to the operational energy use during the usage stage.")]
        public abstract double B6 { get; }

        [Description("Resulting values due to the operational water use during the usage stage.")]
        public abstract double B7 { get; }

        [Description("Resulting values due to the deconstruction and/or demolition during the end of life stage.")]
        public abstract double C1 { get; }

        [Description("Resulting values due to the transport during the end of life stage.")]
        public abstract double C2 { get; }

        [Description("Resulting values due to the waste processing during the end of life stage.")]
        public abstract double C3 { get; }

        [Description("Resulting values due to the disposal during the end of life stage.")]
        public abstract double C4 { get; }

        [Description("Resulting values due to the stage beyond the system boundary.")]
        public abstract double D { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MaterialResult(string materialName, string environmentalProductDeclarationName)
        {
            MaterialName = materialName;
            EnvironmentalProductDeclarationName = environmentalProductDeclarationName;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MaterialResult otherRes = other as MaterialResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

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

        /***************************************************/
    }
}
