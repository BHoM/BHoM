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
using BH.oM.Quantities.Attributes;
using System;

namespace BH.oM.Geometry
{
    [Description("A plane curve. A standard ellipse defining a curve of constant combined distance around two foci." +
                 "\nThe larger of the two radii defines the major axis of the Ellipse, and the line along which the two foci lie.")]
    public class Ellipse : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Origin point defining location of the Ellipse in three-dimensional space.")]
        public virtual Point Centre { get; set; } = new Point();

        [Description("Together with Axis2 defines orientation in three-dimensional space. Direction only, and not magnitude, matters.")]
        public virtual Vector Axis1 { get; set; } = new Vector { X = 1.0, Y = 0.0, Z = 0.0 };

        [Description("Together with Axis1 defines orientation in three-dimensional space. Direction only, and not magnitude, matters.")]
        public virtual Vector Axis2 { get; set; } = new Vector { X = 0.0, Y = 1.0, Z = 0.0 };

        [Length]
        [Description("Distance from the Centre to a point on the Ellipse along Axis1.")]
        public virtual double Radius1 { get; set; } = 0;

        [Length]
        [Description("Distance from the Centre to a point on the Ellipse along Axis2.")]
        public virtual double Radius2 { get; set; } = 0;

        /***************************************************/
        /**** Explicit Casting - Special Case           ****/
        /***************************************************/

        public static explicit operator Ellipse(Circle circle)
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

            return new Ellipse()
            {
                Centre = circle.Centre,
                Axis1 = x,
                Axis2 = y,
                Radius1 = circle.Radius,
                Radius2 = circle.Radius,
            };
        }

        /***************************************************/

        public static explicit operator Ellipse(PolyCurve curve)
        {
            if (curve.Curves.Count != 1)
                return null;

            ICurve c = curve.Curves[0];
            if (c is Ellipse)
                return c as Ellipse;
            else if (c is Circle)
                return (Ellipse)(c as Circle);
            else if (c is Arc)
                return (Ellipse)(c as Arc);
            else if (c is PolyCurve)
                return (Ellipse)(c as PolyCurve);
            else
                return null;

        }

        /***************************************************/

        public static explicit operator Ellipse(Arc curve)
        {
            Circle circle = (Circle)curve;

            if (circle == null)
                return null;

            return (Ellipse)circle;
        }

        /***************************************************/
    }
}



