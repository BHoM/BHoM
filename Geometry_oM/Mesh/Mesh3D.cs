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
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Geometry
{
    [Description("A polygon mesh, defined by a list of triangular or quadrilateral Faces, Cells and their Vertices.")]
    public class Mesh3D : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines the three-dimensional Mesh geometry as  X, Y, Z coordinates.")]
        public virtual IReadOnlyList<Point> Vertices { get; }

        [Description("The list of polygons, defined as corner Point indices referencing the list of Vertices.")]
        public virtual IReadOnlyList<Face> Faces { get; }

        [Description("A parallel list to the Faces, details the index of the cells which is behind and infront of each Face.")]
        public virtual IReadOnlyList<CellRelation> CellRelation { get; }

        /***************************************************/

        public Mesh3D(List<Point> vertices, List<Face> faces, List<CellRelation> cellRelation)
        {
            Vertices = vertices;
            Faces = faces;
            CellRelation = cellRelation;
        }
    }
}



