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

using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    [Description("A curve consisting of a continuous chain of straight line segments. The Polyline is considered closed if the first and last ControlPoints are coincident")]
    public class Polyline : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("An ordered set of three-dimensional points defining the curve shape")]
        public virtual List<Point> ControlPoints { get; set; } = new List<Point>();


        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Polyline(Line line)
        {
            return new Polyline() { ControlPoints = new List<Point>() { line.Start, line.End } };
        }

        /***************************************************/

        public static explicit operator Polyline(NurbsCurve nurbs)
        {
            if (nurbs.Knots.Count != nurbs.ControlPoints.Count)
                return null;

            return new Polyline() { ControlPoints = nurbs.ControlPoints };
        }

        /***************************************************/

        public static explicit operator Polyline(PolyCurve polyCurve)
        {
            if (polyCurve.Curves.Count == 0)
                return null;

            List<Polyline> polyLines = new List<Polyline>();
            foreach (ICurve c in polyCurve.Curves)
            {
                switch (c.GetType().Name)
                {
                    case "NurbsCurve":
                        NurbsCurve nCurve = c as NurbsCurve;
                        Polyline pl = (Polyline)nCurve;
                        if (pl == null)
                            return null;
                        else
                            polyLines.Add(pl);
                        break;
                    case "PolyCurve":
                        PolyCurve pCurve = c as PolyCurve;
                        pl = (Polyline)pCurve;
                        if (pl == null)
                            return null;
                        else
                            polyLines.Add(pl);
                        break;
                    case "Line":
                        polyLines.Add((Polyline)(c as Line));
                        break;
                    case "Polyline":
                        polyLines.Add(c as Polyline);
                        break;
                    default:
                        return null;
                }
            }

            Polyline result = new Polyline();

            result.ControlPoints.Add(polyLines[0].ControlPoints[0]);
            for (int i = 1; i < polyLines.Count; i++)
            {
                result.ControlPoints.AddRange(polyLines[i].ControlPoints.Skip(1));
            }

            return result;
        }

        /***************************************************/
    }
}

