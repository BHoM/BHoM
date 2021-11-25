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

using System.ComponentModel;
using BH.oM.Analytical.Results;
using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace BH.oM.Structure.Results
{
    [Description("Full collection of discrete results for a Panel/FEMesh for a specific Loadcase or LoadCombination.")]
    public class MeshResult : IMeshResult<MeshElementResult>, IStructuralResult, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of the mesh that this result collection belongs to. When extracted from an analysis package, the object id will match the format and value used in that particular package.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; }

        [Description("Positive index, starting at one. Only set for cases with modal outputs such as dynamic cases.")]
        public virtual int ModeNumber { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        public virtual MeshResultLayer Layer { get; }

        [Description("Position within the element thickness that result is extracted from, normalised to 1. I.e. 0 = lower surface, 0.5 = middle, 1 = top surface.")]
        public virtual double LayerPosition { get; }

        public virtual MeshResultSmoothingType Smoothing { get; }

        [Description("A collection of the discrete mesh element results per node and/or face.")]
        public virtual ReadOnlyCollection<MeshElementResult> Results { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public MeshResult(IComparable objectId, IComparable resultCase, int modeNumber, double timeStep, MeshResultLayer layer, double layerPosition, MeshResultSmoothingType smoothing, IEnumerable<MeshElementResult> results)
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            ModeNumber = modeNumber;
            TimeStep = timeStep;
            Layer = layer;
            LayerPosition = layerPosition;
            Smoothing = smoothing;
            Results = new ReadOnlyCollection<MeshElementResult>(results.ToList());
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



