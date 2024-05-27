/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

namespace BH.oM.Geometry
{
    [Description("Internal class used in Polyline offset algorithm.")]
    public class OffsetVertex : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position of the vertex.")]
        public virtual Point Position { get; set; } = null;

        [Description("Translation direction and maginute for a unit offset (offset with magnitude on 1).")]
        public virtual Vector Translation { get; set; } = null;

        [Description("Value describing how much longer or shorter the two adjacent segments will get given a unit offset.")]
        public virtual double AdjacentSegmentLengthChange { get; set; } = 0;

        [Description("Maxmimum allowed offset before the vertex hits a segment.")]
        public virtual double OffsetUntilIntersection { get; set; } = double.MaxValue;

        [Description("Index of the segment being intersected. -1 Means no segment is ever intersected.")]
        public virtual int SegmentIntersected { get; set; } = -1;

        [Description("Flag indicating if the translation vector needs to be (re)computed or not.")]
        public virtual bool ComputeTranlation { get; set; } = true;

        [Description("Flag indicating if the intersection needs to be (re)computed or not.")]
        public virtual bool ComputeIntersection { get; set; } = false;

        [Description("Flag indicating if any segment is in range in terms of tangent intersection, even if it might be out of range in terms of end points.")]
        public virtual bool AnySegmentInRangeForIntersection { get; set; } = false;

        /***************************************************/

    }
}


