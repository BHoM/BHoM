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
using BH.oM.Analytical.Results;
using BH.oM.Geometry;
using System.ComponentModel;
using System;

namespace BH.oM.Structure.Results
{
    [Description("Base class for all Node result classes. Stores all identifier information and how to sort the results in a collection.")]
    public abstract class NodeResult : IStructuralResult, IImmutable, IObjectResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the node that this result belongs to. When extracted from an analysis package, the object id will match the format and value used in that particular package.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; }

        [Description("Positive index, starting at one. Only set for cases with modal outputs such as dynamic cases.")]
        public virtual int ModeNumber { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        [Description("Defines the directionality of the results. Defaults to global XYZ.")]
        public virtual Basis Orientation { get; } = Basis.XY;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public NodeResult(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, Basis orientation)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            ModeNumber = modeNumber;
            TimeStep = timeStep;
            Orientation = orientation;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        [Description("Controls how this result is sorted in relation to other results. Sorts with the following priority: Type, ObjectId, ResultCase, TimeStep.")]
        public int CompareTo(IResult other)
        {
            NodeResult otherRes = other as NodeResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                if (l == 0)
                {
                    int m = this.ModeNumber.CompareTo(otherRes.ModeNumber);
                    return m == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : m;
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



