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

namespace BH.oM.Geometry
{
    [Description("A straight segment in space defining the shortest distance between two points in three-dimensional Euclidean geometry.\n" +
                 "The Vector from Start to End defines the Line direction, which can be important for some applications.")]
    public class Line : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Point Start { get; set; } = new Point();

        public virtual Point End { get; set; } = new Point();

        [Description("Defines the Line as a ray of infinite extents in both directions")]
        public virtual bool Infinite { get; set; } = false;


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Line(Polyline line)
        {
            if (line.ControlPoints.Count != 2)
                return null;

            return new Line() { Start = line.ControlPoints[0], End = line.ControlPoints[1] };
        }

        /***************************************************/

        public static explicit operator Line(NurbsCurve line)
        {
            if (line.ControlPoints.Count != 2)
                return null;

            return new Line() { Start = line.ControlPoints[0], End = line.ControlPoints[1] };
        }

        /***************************************************/

        public static explicit operator Line(PolyCurve curve)
        {
            if (curve.Curves.Count != 1)
                return null;

            ICurve c = curve.Curves[0];
            if (c is Line)
                return c as Line;
            else if (c is Polyline)
                return (Line)(c as Polyline);
            else if (c is NurbsCurve)
                return (Line)(c as NurbsCurve);
            else if (c is PolyCurve)
                return (Line)(c as PolyCurve);
            else
                return null;

        }

        /***************************************************/
    }
}



