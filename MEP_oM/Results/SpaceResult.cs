/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
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

using System;
using System.ComponentModel;
using BH.oM.Analytical.Results;
using BH.oM.Base;

namespace BH.oM.MEP.Results
{
    [Description("Identifiers for a result belonging to one MEP space and one criteria set.")]
    public abstract class SpaceResult : IObjectIdResult, ICasedResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [ObjectIdentifier]
        [Description("Identifier of the space this result belongs to.")]
        public virtual IComparable ObjectId { get; }

        [ScenarioIdentifier]
        [Description("Name of the HVACSpaceCriteria that produced this result.")]
        public virtual IComparable ResultCase { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        protected SpaceResult(IComparable objectId, IComparable resultCase)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            SpaceResult otherResult = other as SpaceResult;
            if (otherResult == null)
                return GetType().Name.CompareTo(other.GetType().Name);

            int objectCompare = ObjectId.CompareTo(otherResult.ObjectId);
            return objectCompare == 0 ? ResultCase.CompareTo(otherResult.ResultCase) : objectCompare;
        }

        /***************************************************/
    }
}
