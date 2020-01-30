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

namespace BH.oM.Geometry
{
    public class BoundingBox : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Min { get; set; } = new Point();

        public Point Max { get; set; } = new Point();


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static BoundingBox operator +(BoundingBox a, BoundingBox b)
        {
            if (a == null || b == null)
                return null;

            return new BoundingBox
            {
                Min = new Point { X = Math.Min(a.Min.X, b.Min.X), Y = Math.Min(a.Min.Y, b.Min.Y), Z = Math.Min(a.Min.Z, b.Min.Z) },
                Max = new Point { X = Math.Max(a.Max.X, b.Max.X), Y = Math.Max(a.Max.Y, b.Max.Y), Z = Math.Max(a.Max.Z, b.Max.Z) }
            };
        }

        /***************************************************/

        public static BoundingBox operator +(BoundingBox box, Vector v)
        {
            if (box == null || v == null)
                return null;

            return new BoundingBox { Min = box.Min + v, Max = box.Max + v };
        }

        /***************************************************/
    }
}

