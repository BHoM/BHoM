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

using System.ComponentModel;
using System;


namespace BH.oM.Geometry
{
    [Description("Arc starting from the local x, rotating Angle number of radians counter clockwise")]
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public CoordinateSystem.Cartesian CoordinateSystem { get; set; } = new CoordinateSystem.Cartesian();

        public double Radius { get; set; } = 0;

        [Description("Angle in radians to the start point from the local X-axis, counter clowise around the local Z-axis")]
        public double StartAngle { get; set; } = 0;

        [Description("Angle in radians to the end point from the local X-axis, counter clowise around the local Z-axis")]
        public double EndAngle { get; set; } = 0;

        /***************************************************/
        /**** Explicit Casting - Special Case           ****/
        /***************************************************/

        public static explicit operator Arc(Circle circle)
        {
            //No way of having explicit operators outside the class definition, why some code for crossproducts etc is stored in here.

            double length = Math.Sqrt(circle.Normal.X * circle.Normal.X + circle.Normal.Y * circle.Normal.Y + circle.Normal.Z * circle.Normal.Z);

            //Get normalised z vector
            Vector z = new Vector { X = circle.Normal.X / length, Y = circle.Normal.Y / length, Z = circle.Normal.Z / length };

            Vector x;
            if (z.Y != 0 && z.Z != 0)
                x = Vector.XAxis;
            else
                x = Vector.YAxis;

            //Project local x to the plane
            x = x - (x.X * z.X + x.Y * z.Y + x.Z * z.Z) * z;

            //Normalise x
            length = Math.Sqrt(x.X * x.X + x.Y * x.Y + x.Z * x.Z);
            x = x / length;

            //Crossproduct to get local y
            Vector y = new Vector { X = z.Y * x.Z - z.Z * x.Y, Y = z.Z * x.X - z.X * x.Z, Z = z.X * x.Y - z.Y * x.X };

            return new Arc
            {
                CoordinateSystem = new CoordinateSystem.Cartesian(circle.Centre, x, y, z),
                Radius = circle.Radius,
                StartAngle = 0,
                EndAngle = Math.PI * 2
            };
        }

        /***************************************************/
    }
}
