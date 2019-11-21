/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

using System.ComponentModel;
using BH.oM.Common;
using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base;
using System.Collections.ObjectModel;
using System;

namespace BH.oM.Structure.Results
{
    public class MeshResult : IResult, IResultCollection<MeshElementResult>, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public IComparable ObjectId { get; } = "";

        public IComparable ResultCase { get; }

        public double TimeStep { get; }

        public MeshResultLayer Layer { get; } 

        [Description("Position within the element thickness that result is extracted from, normalised to 1. 0 = lower surface, 0.5 = middle, 1 = top surface")]
        public double LayerPosition { get; }

        public MeshResultSmoothingType Smoothing { get; }

        public ReadOnlyCollection<MeshElementResult> Results { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshResult(IComparable objectId, IComparable resultCase, double timeStep, MeshResultLayer resultLayer, double layerPosition, MeshResultSmoothingType smoothing, ReadOnlyCollection<MeshElementResult> results)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            Layer = resultLayer;
            LayerPosition = layerPosition;
            Smoothing = smoothing;
            Results = results;
        }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            MeshResult otherRes = other as MeshResult;

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
