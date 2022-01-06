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

using System;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Geometry
{
    [Description("A plane curve. A circular Arc, a curve, with a constant distance from a point, its centre, defined it the local angular domain between start and end angle.")]
    public class Arc : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Defines Arc centre equal to Origin of the CoordinateSystem, as well as the orientation of the Arc in three-dimensional space, equal to local xy-Plane of the CoordinateSystem.")]
        public virtual CoordinateSystem.Cartesian CoordinateSystem { get; set; } = new CoordinateSystem.Cartesian();

        [Length]
        [Description("Distance from the CoordinateSystem.Origin to the any point on Arc.")]
        public virtual double Radius { get; set; } = 0;

        [Angle]
        [Description("Angle in radians to the start point from the local x-axis, counter clockwise around the local z-axis.")]
        public virtual double StartAngle { get; set; } = 0;

        [Angle]
        [Description("Angle in radians to the end point from the local x-axis, counter clockwise around the local z-axis.")]
        public virtual double EndAngle { get; set; } = 0;


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

        public static explicit operator Arc(PolyCurve curve)
        {
            if (curve.Curves.Count != 1)
                return null;

            ICurve c = curve.Curves[0];
            if (c is Arc)
                return c as Arc;
            else if (c is Circle)
                return (Arc)(c as Circle);
            else if (c is Ellipse)
                return (Arc)(c as Ellipse);
            else if (c is PolyCurve)
                return (Arc)(c as PolyCurve);
            else
                return null;

        }

        /***************************************************/

        public static explicit operator Arc(Ellipse curve)
        {
            Circle circle = (Circle)curve;

            if (circle == null)
                return null;

            return (Arc)circle;
        }

        /***************************************************/
    }
}



