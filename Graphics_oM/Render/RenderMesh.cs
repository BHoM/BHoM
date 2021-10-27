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

using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Graphics
{
    public class RenderMesh : IGeometry, IFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual List<RenderPoint> Vertices { get; set; } = new List<RenderPoint>();

        public virtual List<Face> Faces { get; set; } = new List<Face>();

        /***************************************************/

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator RenderMesh(Geometry.Mesh mesh)
        {
            return new RenderMesh() { Faces = mesh.Faces, Vertices = mesh.Vertices.Select(p => (RenderPoint)p).ToList() };
        }

        /***************************************************/
    }
}


