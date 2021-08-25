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

using BH.oM.Geometry;
using System.Drawing;

namespace BH.oM.Graphics
{
    public class Vertex : IGeometry, IColourable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Geometry.Point Point { get; set; } = new Geometry.Point();

        public virtual Color Colour { get; set; } = Color.FromArgb(255, 250, 34, 74);

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Vertex(Geometry.Point point)
        {
            return new Vertex { Point = point };
        }

        /***************************************************/
    }
}


