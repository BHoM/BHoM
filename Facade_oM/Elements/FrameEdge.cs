/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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
using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Analytical.Elements;
using System.ComponentModel;
using BH.oM.Dimensional;

namespace BH.oM.Facade.Elements
{
    [Description("A facade object used to define an edge of a frame and the type of edge (Sill, Head, Left, or Right)")]
    public class FrameEdge : BHoMObject, IEdge, IElement1D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("A BHoM Geometry planar curve object (e.g Polyline, Line, etc.)")]
        public virtual ICurve Curve { get; set; } = new Polyline();

        [Description("Type of frame edge (Sill, Head, Left, Right, or Undefined)")]
        public virtual FrameEdgeType Type { get; set; } = FrameEdgeType.Undefined;

        /***************************************************/
    }
}

