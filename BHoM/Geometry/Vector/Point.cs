using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Geometry
{
    /// <summary>
    /// BHoM Point object
    /// </summary>
    public class Point : IBHoMGeometry, IComparable<Point>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double X { get; set; } = 0;

        public double Y { get; set; } = 0;

        public double Z { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Point(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/

        public Point(Vector v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        /***************************************************/
        /**** Static special cases                      ****/
        /***************************************************/

        public static Point Origin = new Point(0, 0, 0);


        /***************************************************/
        /**** Local Optimisation Methods                ****/
        /***************************************************/

        public object GetClone() // Optimisation
        {
            return new Point(X, Y, Z);
        }

        /***************************************************/

        public bool IsValid()
        {
            return !(double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z));
        }


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
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /***************************************************/

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /***************************************************/

        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /***************************************************/

        public static Point operator -(Point a, Vector b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /***************************************************/

        public static Point operator *(Point a, double b)
        {
            return new Point(a.X * b, a.Y * b, a.Z * b);
        }

        /***************************************************/

        public static Point operator *(double a, Point b)
        {
            return new Point(a * b.X, a * b.Y, a * b.Z);
        }

        /***************************************************/

        public static Point operator /(Point a, double b)
        {
            return new Point(a.X / b, a.Y / b, a.Z / b);
        }

        /***************************************************/

        public static Point operator /(double a, Point b)
        {
            return new Point(a / b.X, a / b.Y, a / b.Z);
        }

        /***************************************************/

        public static bool operator ==(Point a, Point b)
        {
            return a != null && b != null && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        /***************************************************/

        public static bool operator !=(Point a, Point b)
        {
            return a == null || b == null || a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }

    }
}


