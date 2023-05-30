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

namespace BH.oM.LifeCycleAssessment.Results
{
    public abstract class ElementResult<T> : IElementResult<T>, IImmutable
        where T : MaterialResult
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
        public virtual IReadOnlyList<T> MaterialResults { get; protected set; }

        /***************************************************/
        /**** Properties - Result properties            ****/
        /***************************************************/

        [Description("Resulting data relating to the Raw Material Supply module in the Product stage.")]
        public abstract double A1 { get; protected set; }

        [Description("Resulting data relating to the Transport module in the Product stage.")]
        public abstract double A2 { get; protected set; }

        [Description("Resulting data relating to the Manufacturing module in the Product stage.")]
        public abstract double A3 { get; protected set; }

        [Description("Resulting data relating to the full product stage.")]
        public abstract double A1toA3 { get; protected set; }

        [Description("Resulting data relating to the Transport module in the Construction Process stage.")]
        public abstract double A4 { get; protected set; }

        [Description("Resulting data relating to the Construction Installation Process module in the Construction Process stage.")]
        public abstract double A5 { get; protected set; }

        [Description("Resulting data relating to the Use module in the Use stage.")]
        public abstract double B1 { get; protected set; }

        [Description("Resulting data relating to the Maintenance module in the Use stage.")]
        public abstract double B2 { get; protected set; }

        [Description("Resulting data relating to the Repair module in the Use stage.")]
        public abstract double B3 { get; protected set; }

        [Description("Resulting data relating to the Replacement module in the Use stage.")]
        public abstract double B4 { get; protected set; }

        [Description("Resulting data relating to the Refurbishment module in the Use stage.")]
        public abstract double B5 { get; protected set; }

        [Description("Resulting data relating to the Operational Energy Use module in the Use stage.")]
        public abstract double B6 { get; protected set; }

        [Description("Resulting data relating to the Operational Water Use module in the Use stage.")]
        public abstract double B7 { get; protected set; }

        [Description("Resulting data relating to the full Use Stage.")]
        public abstract double B1toB7 { get; protected set; }

        [Description("Resulting data relating to the De-construction Demolition module in the End of Life stage.")]
        public abstract double C1 { get; protected set; }

        [Description("Resulting data relating to the Transport module in the End of Life stage.")]
        public abstract double C2 { get; protected set; }

        [Description("Resulting data relating to the Waste Processing module in the End of Life stage.")]
        public abstract double C3 { get; protected set; }

        [Description("Resulting data relating to the Disposal module in the End of Life stage.")]
        public abstract double C4 { get; protected set; }

        [Description("Resulting data relating to the full End of Life stage.")]
        public abstract double C1toC4 { get; protected set; }

        [Description("Resulting data relating to benefits and loads beyond the system boundary.")]
        public abstract double D { get; protected set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ElementResult(IComparable objectId, ScopeType scope, ObjectCategory category, EnvironmentalMetrics metricType, IReadOnlyList<T> materialResults,
                        double a1,
                        double a2,
                        double a3,
                        double a1toa3,
                        double a4,
                        double a5,
                        double b1,
                        double b2,
                        double b3,
                        double b4,
                        double b5,
                        double b6,
                        double b7,
                        double b1tob7,
                        double c1,
                        double c2,
                        double c3,
                        double c4,
                        double c1toc4,
                        double d)
        {
            ObjectId = objectId;
            Scope = scope;
            Category = category;
            MaterialResults = materialResults;
            MetricType = metricType;
            A1 = a1;
            A2 = a2;
            A3 = a3;
            A1toA3 = a1toa3;
            A4 = a4;
            A5 = a5;
            B1 = b1;
            B2 = b2;
            B3 = b3;
            B4 = b4;
            B5 = b5;
            B6 = b6;
            B7 = b7;
            B1toB7 = b1tob7;
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C1toC4 = c1toc4;
            D = d;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            if (other == null)
                return -1;

            ElementResult<T> otherRes = other as ElementResult<T>;

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


