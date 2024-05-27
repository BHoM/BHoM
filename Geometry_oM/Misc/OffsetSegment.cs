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
    public class OffsetSegment : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Length of the segment.")]
        public virtual double Length { get; set; } = 0;

        [Description("Unit tangent vector of the segment.")]
        public virtual Vector Tangent { get; set; } = null;

        [Description("Orthogonal unit vector of the segment. Equal to direction of the offset.")]
        public virtual Vector Orthogonal { get; set; } = null;

        [Description("Value describing how much longer or shorter the segments will get given a unit offset.")]
        public virtual double SegmentLengthChange { get; set; } = 0;

        [Description("Flag indicating if the length change needs to be recomputed or not.")]
        public virtual bool ComputeLengthChange { get; set; } = false;

        [Description("Flag indicating if the length needs to be recomputed or not.")]
        public virtual bool RecomputeLength { get; set; } = false;

        /***************************************************/

    }
}


