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

namespace BH.oM.Geometry
{
    [Description("A composite curve constructed by combining a collection of curves of any type. Whole PolyCurve integrity, continuity and closure is not guaranteed at creation. Discontinuous and/or multi-region definitions are possible, although not recommended as may cause unexpected results in method operating on PolyCurves.")]
    public class PolyCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("A collection of curves, of any or mixed type, which together define the composite shape.")]
        public virtual List<ICurve> Curves { get; set; } = new List<ICurve>();

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator PolyCurve(Arc curve)
        {
            return new PolyCurve() { Curves = new List<ICurve>() { curve } };
        }

        /***************************************************/

        public static explicit operator PolyCurve(Circle curve)
        {
            return new PolyCurve() { Curves = new List<ICurve>() { curve } };
        }

        /***************************************************/

        public static explicit operator PolyCurve(Ellipse curve)
        {
            return new PolyCurve() { Curves = new List<ICurve>() { curve } };
        }

        /***************************************************/

        public static explicit operator PolyCurve(Line curve)
        {
            return new PolyCurve() { Curves = new List<ICurve>() { curve } };
        }

        /***************************************************/

        public static explicit operator PolyCurve(NurbsCurve curve)
        {
            return new PolyCurve() { Curves = new List<ICurve>() { curve } };
        }

        /***************************************************/

        public static explicit operator PolyCurve(Polyline curve)
        {
            PolyCurve result = new PolyCurve();

            for (int i = 0; i < curve.ControlPoints.Count - 1; i++)
            {
                result.Curves.Add(new Line() { Start = curve.ControlPoints[i], End = curve.ControlPoints[i + 1] });
            }

            return result;
        }

        /***************************************************/
    }
}   



