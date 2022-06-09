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


using BH.oM.Geometry;
using System.ComponentModel;
using System;
using BH.oM.Analytical.Results;
using BH.oM.Base;

namespace BH.oM.Humans.ViewQuality
{
    public abstract class ViewQualityResult : IObjectIdResult, ICasedResult, ITimeStepResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual IComparable ObjectId { get; }

        public virtual IComparable ResultCase { get; }

        public virtual double TimeStep { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public ViewQualityResult(IComparable objectId, IComparable resultCase, double timeStep)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            ViewQualityResult otherRes = other as ViewQualityResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;
            }
            else
            {
                return n;
            }

        }

        /***************************************************/
    }
}



