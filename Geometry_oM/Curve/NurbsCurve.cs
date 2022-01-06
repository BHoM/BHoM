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
using System.Linq;
using System;

namespace BH.oM.Geometry
{
    [Description("A non-uniform rational basis spline (or B-spline). Enables definition of smooth and continuous curves as piece-wise polynomial basis functions evaluated from discrete geometrical ControlPoints." +
                 "\nA NurbsCurve, through its use of ControlPoint Weightings, has the ability to precisely represent the conic sections, such as the circle and parabolas etc.")]
    public class NurbsCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("An ordered set of three-dimensional points defining the curve shape. The control point locations are approximating, as opposed to interpolating, meaning in the general case the resulting curve will not pass through the control point locations themselves." +
                     "\nThe special case of where both Knot and ControlPoint count are equal defines a NurbsCurve of Degree 1. This shape will pass through all ControlPoints, linearly interpolating beween them and being equivalent to a Polyline.")]
        public virtual List<Point> ControlPoints { get; set; } = new List<Point>();

        [Description("A list of scalar factors, one for each ControlPoint. The weights in effect add an additional degree of freedom, allowing control over the relative influence of each control point on the curve shape")]
        public virtual List<double> Weights { get; set; } = new List<double>();

        [Description("The knot vector is a non-decreasing list of numbers, the relative spacing of which define the spans and transition points of the basis functions along the curve's domain." +
                     "\nKnot vector length must be equal to or greater than the number of ControlPoints, such that together, the difference in counts defines the order (and degree) of the NurbsCurve." +
                     "\nThe NurbsCurve degree is equal to order plus one.")]
        public virtual List<double> Knots { get; set; } = new List<double>();


        /***************************************************/
        /**** Explicit Casting - Special Case           ****/
        /***************************************************/

        public static explicit operator NurbsCurve(Line line)
        {
            return new NurbsCurve {
                ControlPoints = new List<Point> { line.Start, line.End },
                Knots = new List<double> { 0, 1 },
                Weights = new List<double> { 1, 1 },
            };
        }

        /***************************************************/

        public static explicit operator NurbsCurve(Polyline polyline)
        {
            List<Point> points = polyline.ControlPoints;
            List<double> weights = polyline.ControlPoints.Select(x => 1.0).ToList();
            List<double> knots = new List<double> { 0 };

            double t = 0;
            for (int i = 1; i < points.Count; i++)
            {
                Vector v = points[i] - points[i - 1];
                t += Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
                knots.Add(t);
            }
            knots = knots.Select(x => x / t).ToList();

            return new NurbsCurve { ControlPoints = points, Weights = weights, Knots = knots };
        }

        /***************************************************/

        public static explicit operator NurbsCurve(Ellipse ellipse)
        {

            Point centre = ellipse.Centre;
            Vector d1 = ellipse.Radius1 * ellipse.Axis1;
            Vector d2 = ellipse.Radius2 * ellipse.Axis2;
            double factor = Math.Cos(Math.PI / 4);

            List<Point> points = new List<Point>
            {
                centre + d1,
                centre + d1 + d2,
                centre + d2,
                centre - d1 + d2,
                centre - d1,
                centre - d1 - d2,
                centre - d2,
                centre + d1 - d2,
                centre + d1
            };

            return new NurbsCurve
            {
                ControlPoints = points,
                Knots = new List<double> { 0, 0, 0.25, 0.25, 0.5, 0.5, 0.75, 0.75, 1.0, 1.0 },
                Weights = new List<double> { 1.0, factor, 1.0, factor, 1.0, factor, 1.0, factor, 1.0 }
            };

        }

        /***************************************************/

        public static explicit operator NurbsCurve(Circle circle)
        {
            Ellipse ellipse = (Ellipse)circle;
            return (NurbsCurve)ellipse;
        }

        /***************************************************/

        public static explicit operator NurbsCurve(PolyCurve curve)
        {
            if (curve.Curves.Count != 1)
                return null;

            ICurve c = curve.Curves[0];
            if (c is NurbsCurve)
                return c as NurbsCurve;
            else if (c is Line)
                return (NurbsCurve)(c as Line);
            else if (c is Polyline)
                return (NurbsCurve)(c as Polyline);
            else if (c is Circle)
                return (NurbsCurve)(c as Circle);
            else if (c is Ellipse)
                return (NurbsCurve)(c as Ellipse);
            else if (c is PolyCurve)
                return (NurbsCurve)(c as PolyCurve);
            else
                return null;
            
        }

        /***************************************************/

    }
}



