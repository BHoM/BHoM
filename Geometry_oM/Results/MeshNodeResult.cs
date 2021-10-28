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

using BH.oM.Analytical.Results;
using BH.oM.Geometry;
using System.ComponentModel;
using BH.oM.Base;
using System;

namespace BH.oM.Geometry.Results
{
    public class MeshNodeResult : IMeshNodeResult, ICasedResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual IAdapterId ObjectId { get; }

        [Description("Id of the Node in the mesh that this result belongs to. Will be empty for smoothing types not relating to Nodes. When extracted from an analysis package, the Node id will correspond to the node id in the software and match the format and value used in that particular package.")]
        public virtual IAdapterId NodeId { get; }

        [Description("Identifier for the Loadcase or LoadCombination that the result belongs to. Is generally name or number of the loadcase, depending on the analysis package.")]
        public virtual IComparable ResultCase { get; }

        public virtual MeshResultLayer MeshResultLayer { get; }

        [Description("Position within the element thickness that result is extracted from, normalised to 1. I.e. 0 = lower surface, 0.5 = middle, 1 = top surface.")]
        public virtual double LayerPosition { get; }

        [Description("Vector basis required in order to report results in a particular direction, for example, for anisotropic materials.")]
        public virtual Basis Orientation { get; } = Basis.XY;

        public int CompareTo(IResult other)
        {
            throw new NotImplementedException();
        }
    }
}



