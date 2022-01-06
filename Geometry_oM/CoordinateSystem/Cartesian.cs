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

namespace BH.oM.Geometry.CoordinateSystem
{
    [Description("A three-dimensional Cartesian coordinate system, as defined by a set of mutually orthogonal unit vectors and a common origin point")]
    public class Cartesian : IGeometry, IImmutable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Unit vector defining local x coordinate axis")]
        public virtual Vector X { get; } = Vector.XAxis;

        [Description("Unit vector defining local y coordinate axis")]
        public virtual Vector Y { get; } = Vector.YAxis;

        [Description("Unit vector defining local z coordinate axis")]
        public virtual Vector Z { get; } = Vector.ZAxis;

        [Description("Location point in three-dimensional space defining (0,0,0) and the origin for each axis")]
        public virtual Point Origin { get; set; } = Point.Origin;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Cartesian(Point origin, Vector x, Vector y, Vector z)
        {
            Origin = origin;
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/

        public Cartesian()
        { }

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Cartesian(Point point)
        {
            return new Cartesian() { Origin = point };
        }

        /***************************************************/
    }
}



