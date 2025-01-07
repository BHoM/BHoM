/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2025, the respective contributors. All rights reserved.
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
    [Description("Options for curve offset operations.")]
    public class OffsetOptions : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("If true segments shorter than tolerance are removed. Only applicable for polyline offsets. Recomended for the general case to be set to true. To be noted that when this option is true, the topology of the polyline might change due to segments being removed. Defaults to true.")]
        public virtual bool RemoveShortSegments { get; set;} = true;

        [Description("If true mehtod avoids creation of self intersections for offsets of concave curves by removal of segments tending to 0 length. Only applicable for Polyline offsets. Recomended for the general case to be set to true. To be noted that when this option is true, the topology of the polyline might change due to segments being removed. Defaults to true.")]
        public virtual bool HandleCreatedLocalSelfIntersections { get; set; } = true;

        [Description("If true mehtod avoids creation of self intersections for offsets of concave curves checking if any vertex being offsetted is ending up on or beyond another segment. Recomended for the general case to be set to true. To be noted that when this option is true, the topology of the polyline might change due to segments being removed. Only applicable for Polyline offsets. Defaults to true.")]
        public virtual bool HandleGeneralCreatedSelfIntersections { get; set; } = true;

        [Description("If true handles adjecent parallel segemnts, that is, segments that have an angle below tolerance. This is handled by removal of the vertex connection the two segments for a concave offset and introductions of one additional vertex for a convex offset. Recomended for the general case to be set to true. To be noted that when this option is true, the topology of the polyline might change due to segments being added and/or removed. Only applicable for Polyline offsets. Defaults to true.")]
        public virtual bool HandleAdjacentParallelSegments { get; set; } = true;
        
        /***************************************************/

    }
}



