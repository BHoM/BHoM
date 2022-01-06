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

namespace BH.oM.Geometry
{
    [Description("A plane curve. Standard circle defining a curve of constant distance from a point, its Centre.")]
    public class Circle : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Origin point defining location of the Circle in three-dimensional space.")]
        public virtual Point Centre { get; set; } = new Point();

        [Description("Vector perpendicular to the plane in which the Circle lies.")]
        public virtual Vector Normal { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };

        [Length]
        [Description("Distance from the Centre to any point on Circle.")]
        public virtual double Radius { get; set; } = 0;


        /***************************************************/
        /**** Explicit Casting - Special Case           ****/
        /***************************************************/

        public static explicit operator Circle(PolyCurve curve)
        {
            if (curve.Curves.Count != 1)
                return null;
            
            ICurve c = curve.Curves[0];
            if (c is Circle)
                return c as Circle;
            else if (c is Arc)
                return (Circle)(c as Arc);
            else if (c is Ellipse)
                return ((Circle)(c as Ellipse));
            else if (c is PolyCurve)
                return (Circle)(c as PolyCurve);
            else
                return null;
        }

        /***************************************************/

        public static explicit operator Circle(Ellipse curve)
        {
            if (System.Math.Abs(curve.Radius1 - curve.Radius2) > Tolerance.Distance)
                return null;

            Vector x = curve.Axis1;
            Vector y = curve.Axis2;

            Vector normal = new Vector { X = x.Y * y.Z - x.Z * y.Y, Y = x.Z * y.X - x.X * y.Z, Z = x.X * y.Y - x.Y * y.X };

            return new Circle()
            {
                Centre = curve.Centre,
                Radius = curve.Radius1,
                Normal = normal,
            };
        }

        /***************************************************/

        public static explicit operator Circle(Arc curve)
        {
            if (System.Math.Abs((curve.EndAngle - curve.StartAngle) - System.Math.PI * 2) > Tolerance.Distance)
                return null;

            return new Circle()
            {
                Centre = curve.CoordinateSystem.Origin,
                Normal = curve.CoordinateSystem.Z,
                Radius = curve.Radius,
            };
        }

        /***************************************************/
    }
}



