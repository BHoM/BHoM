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
    [Description("Defines a direction and magnitude in three-dimensional Euclidean space.")]
    public class Vector : IGeometry, IComparable<Vector>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Length]
        [Description("Dimension along global X coordinate axis.")]
        public virtual double X { get; set; } = 0.0;

        [Length]
        [Description("Dimension along global Y coordinate axis.")]
        public virtual double Y { get; set; } = 0.0;

        [Length]
        [Description("Dimension along global Z coordinate axis.")]
        public virtual double Z { get; set; } = 0.0;


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Vector XAxis = new Vector { X = 1, Y = 0, Z = 0 };

        /***************************************************/

        public static readonly Vector YAxis = new Vector { X = 0, Y = 1, Z = 0 };

        /***************************************************/

        public static readonly Vector ZAxis = new Vector { X = 0, Y = 0, Z = 1 };


        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(Vector other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            else if (Y != other.Y)
                return Y.CompareTo(other.Y);
            else
                return Z.CompareTo(other.Z);
        }

        /***************************************************/

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Vector) && this == ((Vector)obj);
        }

        /***************************************************/

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }

        /***************************************************/

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }

        /***************************************************/

        public static Vector operator -(Vector a)
        {
            return new Vector { X = -a.X, Y = -a.Y, Z = -a.Z };
        }

        /***************************************************/

        public static Vector operator /(Vector a, double b)
        {
            return new Vector { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
        }

        /***************************************************/

        public static Vector operator *(Vector a, double b)
        {
            return new Vector { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }

        /***************************************************/

        public static Vector operator *(double b, Vector a)
        {
            return new Vector { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }

        /***************************************************/

        public static double operator *(Vector a, Vector b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }

        /***************************************************/

        public static double operator *(Vector a, Point b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }

        /***************************************************/

        public static double operator *(Point a, Vector b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }

        /***************************************************/

        public static bool operator ==(Vector a, Vector b)
        {
            return a?.X == b?.X && a?.Y == b?.Y && a?.Z == b?.Z;
        }

        /***************************************************/

        public static bool operator !=(Vector a, Vector b)
        {
            return a?.X != b?.X || a?.Y != b?.Y || a?.Z != b?.Z;
        }

        /***************************************************/
    }
}



