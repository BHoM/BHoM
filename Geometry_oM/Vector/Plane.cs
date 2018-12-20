/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
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

namespace BH.oM.Geometry
{
    public class Plane : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Origin { get; set; } = new Point();

        public Vector Normal { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Plane XY = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.ZAxis };

        /***************************************************/

        public static readonly Plane YZ = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.XAxis };

        /***************************************************/

        public static readonly Plane XZ = new Plane { Origin = new Point { X = 0, Y = 0, Z = 0 }, Normal = Vector.YAxis };


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Plane(CoordinateSystem.Cartesian cartesian)
        {
            return new Plane { Origin = cartesian.Origin, Normal = cartesian.Z };
        }

        /***************************************************/
    }
}
