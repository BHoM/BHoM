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
    public abstract class ElementResult<T> : IElementResult<T>, IImmutable
        where T : MaterialResult
    {
        /***************************************************/
        /**** Properties - Identifiers                  ****/
        /***************************************************/

        [Description("Id of the BHoMObject that this result belongs to.")]
        public virtual IComparable ObjectId { get; } = "";

        [Description("Scope the object this result was generated from belongs to, e.g. Foundation or Facade")]
        public virtual ScopeType Scope { get; }

        [Description("Category of the object this result was generated from, e.g. Beam or Wall")]
        public virtual ObjectCategory Category { get; }

        /***************************************************/
        /**** Properties - Material Breakdown           ****/
        /***************************************************/

        [Description("Result breakdown per material type.")]
        public virtual IReadOnlyList<T> MaterialResults { get; }

        /***************************************************/
        /**** Properties - Result properties            ****/
        /***************************************************/

        [Description("Resulting values due to the Raw materials in the product stage.")]
        public abstract double A1 { get; protected set; }

        [Description("Resulting values due to the Transport in the product stage.")]
        public abstract double A2 { get; protected set; }

        [Description("Resulting values due to the Manufacturing in the product stage.")]
        public abstract double A3 { get; protected set; }

        [Description("Resulting values due to the full product stage.")]
        public abstract double A1toA3 { get; protected set; }

        [Description("Resulting values due to the transport during the assembly stage.")]
        public abstract double A4 { get; protected set; }

        [Description("Resulting values due to the final assembly during the assembly stage.")]
        public abstract double A5 { get; protected set; }

        [Description("Resulting values due to the general use during the usage stage.")]
        public abstract double B1 { get; protected set; }

        [Description("Resulting values due to the maintance during the usage stage.")]
        public abstract double B2 { get; protected set; }

        [Description("Resulting values due to the repair during the usage stage.")]
        public abstract double B3 { get; protected set; }

        [Description("Resulting values due to the replacement during the usage stage.")]
        public abstract double B4 { get; protected set; }

        [Description("Resulting values due to the refurbishment during the usage stage.")]
        public abstract double B5 { get; protected set; }

        [Description("Resulting values due to the operational energy use during the usage stage.")]
        public abstract double B6 { get; protected set; }

        [Description("Resulting values due to the operational water use during the usage stage.")]
        public abstract double B7 { get; protected set; }

        [Description("Resulting values due to the deconstruction and/or demolition during the end of life stage.")]
        public abstract double C1 { get; protected set; }

        [Description("Resulting values due to the transport during the end of life stage.")]
        public abstract double C2 { get; protected set; }

        [Description("Resulting values due to the waste processing during the end of life stage.")]
        public abstract double C3 { get; protected set; }

        [Description("Resulting values due to the disposal during the end of life stage.")]
        public abstract double C4 { get; protected set; }

        [Description("Resulting values due to the stage beyond the system boundary.")]
        public abstract double D { get; protected set; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ElementResult(IComparable objectId, ScopeType scope, ObjectCategory category, IReadOnlyList<T> materialResults)
        {
            ObjectId = objectId;
            Scope = scope;
            Category = category;
            MaterialResults = materialResults;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
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


