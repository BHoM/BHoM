/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System;
using System.ComponentModel;

namespace BH.oM.Data.Collections
{
    [Description("A numerical domain defined by a minimum and maximum value.")]
    public class Domain : IObject, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The lowest bound of the domain.")]
        public double Min { get; }

        [Description("The highest bound of the domain.")]
        public double Max { get; }

        [Description("Whether the Min and Max extremes are included in the Domain or not.")]
        public DomainExtremesInclusion ExtremesInclusion { get; } = DomainExtremesInclusion.IncludeBoth;

        /***************************************************/

        public Domain(double min, double max, DomainExtremesInclusion extremesInclusion = DomainExtremesInclusion.IncludeBoth)
        {
            Min = min;
            Max = max;
            ExtremesInclusion = extremesInclusion;
        }

        /***************************************************/

        public static Domain operator +(Domain a, Domain b)
        {
            if (a == null || b == null)
                return null;

            return new Domain(
                Math.Min(a.Min, b.Min),
                Math.Max(a.Max, b.Max)
                );
        }

        /***************************************************/
        public override string ToString()
        {
            return $"{(this.ExtremesInclusion == DomainExtremesInclusion.IncludeBoth || this.ExtremesInclusion == DomainExtremesInclusion.IncludeMin ? "[" : "(")}" +
                $"{ (this.Min == double.MinValue ? "-∞" : this.Min.ToString())}" + "," +
                $"{(this.Max == double.MaxValue ? "+∞" : this.Max.ToString())}" +
                $"{(this.ExtremesInclusion == DomainExtremesInclusion.IncludeBoth || this.ExtremesInclusion == DomainExtremesInclusion.IncludeMax ? "]" : ")")}";
        }
    }
}


