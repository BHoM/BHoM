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

using BH.oM.Base;
using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("An ordered set of mutually orthogonal unit vectors defining three-dimensional orientation in space")]
    public class Basis : IGeometry, IImmutable
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

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Basis(Vector x, Vector y, Vector z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Basis XY = new Basis(Vector.XAxis, Vector.YAxis, Vector.ZAxis);

        /***************************************************/

        public static readonly Basis XZ = new Basis(Vector.XAxis, Vector.ZAxis, -Vector.YAxis);

        /***************************************************/

        public static readonly Basis YZ = new Basis(Vector.YAxis, Vector.ZAxis, Vector.XAxis);

        /***************************************************/
        /**** Explicit Casting                          ****/
        /***************************************************/

        public static explicit operator Basis(CoordinateSystem.Cartesian coordinateSystem)
        {
            return new Basis(coordinateSystem.X, coordinateSystem.Y, coordinateSystem.Z);
        }

        /***************************************************/
    }
}


