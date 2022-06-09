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
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Geometry
{
    [Description("A pair of curves representing the boundary of a trimmed surface in both global X, Y, Z coordinates (Curve3d) as well as local surface U, V parameter space (Curve2d)." +
                 "\nA Surface Trim is immutable to ensure compatiblity of both curves.")]
    public class SurfaceTrim : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Trim Curve in global X, Y, Z coordinates.")]
        public virtual ICurve Curve3d { get; }

        [Description("Trim Curve in local surface U, V coordinates.")]
        public virtual ICurve Curve2d { get; }

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SurfaceTrim(ICurve curve3d, ICurve curve2d)
        {
            Curve3d = curve3d;
            Curve2d = curve2d;
        }

        /***************************************************/
    }
}



