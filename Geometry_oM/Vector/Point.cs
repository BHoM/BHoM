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
using BH.oM.Dimensional;
using System.ComponentModel;

namespace BH.oM.Geometry
{
    [Description("Defines a dimensionless location in three-dimensional space.")]
    public class Point : IGeometry, IComparable<Point>, IElement0D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Position along global X coordinate axis.")]
        public virtual double X { get; set; } = 0;

        [Description("Position along global Y coordinate axis.")]
        public virtual double Y { get; set; } = 0;

        [Description("Position along global Z coordinate axis.")]
        public virtual double Z { get; set; } = 0;


        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static readonly Point Origin = new Point { X = 0, Y = 0, Z = 0 };


        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(Point other)
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
            return obj.GetType() == typeof(Point) && this == ((Point)obj);
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

        public static Vector operator -(Point a, Point b)
        {
            return new Vector { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }

        /***************************************************/

        public static Point operator +(Point a, Point b)
        {
            return new Point { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }

        /***************************************************/

        public static Point operator +(Point a, Vector b)
        {
            return new Point { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }

        /***************************************************/

        public static Point operator -(Point a, Vector b)
        {
            return new Point { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }

        /***************************************************/

        public static Point operator *(Point a, double b)
        {
            return new Point { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
        }

        /***************************************************/

        public static Point operator *(double a, Point b)
        {
            return new Point { X = a * b.X, Y = a * b.Y, Z = a * b.Z };
        }

        /***************************************************/

        public static Point operator /(Point a, double b)
        {
            return new Point { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
        }

        /***************************************************/

        public static Point operator /(double a, Point b)
        {
            return new Point { X = a / b.X, Y = a / b.Y, Z = a / b.Z };
        }

        /***************************************************/

        public static bool operator ==(Point a, Point b)
        {
            return a?.X == b?.X && a?.Y == b?.Y && a?.Z == b?.Z;
        }

        /***************************************************/

        public static bool operator !=(Point a, Point b)
        {
            return a?.X != b?.X || a?.Y != b?.Y || a?.Z != b?.Z;
        }

        /***************************************************/
    }
}



