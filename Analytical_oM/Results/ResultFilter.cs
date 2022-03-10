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

using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Analytical.Results
{
    [Description("Object to support filtering of results")]
    public class ResultFilter : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("If ResultCaseFilters contains items, only results of type ICasedResult will be returned that has a ResultCase matching any items in the ResultCaseFilters.")]
        public virtual HashSet<IComparable> ResultCaseFilters { get; set; } = new HashSet<IComparable>();

        [Description("If ObjectIDFilters contains items, only results of type IObjectIdResult will be returned that has a ObjectId matching any items in the ObjectIDFilters.")]
        public virtual HashSet<IComparable> ObjectIDFilters { get; set; } = new HashSet<IComparable>();

        [Description("If NodeIDFilters contains items, only results of type IMeshElementResult will be returned that has a NodeId matching any items in the NodeIDFilters.")]
        public virtual HashSet<IComparable> NodeIDFilters { get; set; } = new HashSet<IComparable>();

        [Description("If MeshFaceIDFilters contains items, only results of type IMeshElementResult will be returned that has a MeshFaceId matching any items in the MeshFaceIDFilters.")]
        public virtual HashSet<IComparable> MeshFaceIDFilters { get; set; } = new HashSet<IComparable>();

        [Description("If TimeStepFilters contains items, only results of type ITimeStepResult will be returned that has a TimeStep matching any items in the TimeStepFilters.")]
        public virtual HashSet<double> TimeStepFilters { get; set; } = new HashSet<double>();

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        [Description("Casting method to allow for simpler usage with the common case of filtering by a singe ResultCase.")]
        public static explicit operator ResultFilter(string resultFilter)
        {
            if (string.IsNullOrEmpty(resultFilter))
                return null;
            return new ResultFilter { ResultCaseFilters = new HashSet<IComparable> { resultFilter } };
        }

        /***************************************************/

        [Description("Casting method to allow for simpler usage with the common case of filtering by a singe ResultCase.")]
        public static explicit operator ResultFilter(int resultFilter)
        {
            return new ResultFilter { ResultCaseFilters = new HashSet<IComparable> { resultFilter } };
        }

        /***************************************************/
    }
}


