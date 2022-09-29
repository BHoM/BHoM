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
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BH.oM.Dimensional;

namespace BH.oM.Geometry
{
    [Description("Simple Polygon. Closed, planar and non-self intersecting. Can be irregular, convex and/or concave.")]
    public class Polygon : IPolyline, ICurve, IBoundary, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("An ordered set of three-dimensional points defining the curve shape.\n" + 
                     "The list should not contain any duplicate points - the first point in the list will be treated as both the start and end point.")]
        public virtual IReadOnlyList<Point> Vertices { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Polygon(IEnumerable<Point> vertices)
        {
            Vertices = new ReadOnlyCollection<Point>(vertices == null ? new List<Point>() : vertices.ToList());
        }

        /***************************************************/
        /**** Implicit Casting                          ****/
        /***************************************************/

        [Description("Enables implicit casting of a Polygon to a Polyline. This ensures that a Polygon can be passed freely to a method expecting a Polyline.")]
        public static implicit operator Polyline(Polygon polygon)
        {
            Polyline pLine = new Polyline { ControlPoints = polygon.Vertices.ToList() };
            pLine.ControlPoints.Add(pLine.ControlPoints[0]);    //Closed polylines have dupliace start/end point. First Vertice inserted in the list.
            return pLine;
        }

        /***************************************************/

    }
}


