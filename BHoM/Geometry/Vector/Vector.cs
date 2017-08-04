using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Geometry
{
    /// <summary>
    /// BHoM Vector object
    /// </summary>
    public class Vector : IBHoMGeometry, IComparable<Vector>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double X { get; set; } = 0.0;

        public double Y { get; set; } = 0.0;

        public double Z { get; set; } = 0.0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Vector(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /***************************************************/

        public Vector(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
            Z = pt.Z;
        }

        /***************************************************/

        public static Vector XAxis()
        {
            return new Vector(1, 0, 0);
        }

        /***************************************************/

        public static Vector YAxis()
        {
            return new Vector(0, 1, 0);
        }

        /***************************************************/

        public static Vector ZAxis()
        {
            return new Vector(0, 0, 1);
        }


        /***************************************************/
        /**** Local Optimisation Methods                ****/
        /***************************************************/

        public object GetClone() // Optimisation
        {
            return new Vector(X, Y, Z);
        }

        /***************************************************/

        public bool IsValid()
        {
            return !(double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z));
        }


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
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /***************************************************/

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /***************************************************/

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.X, -a.Y, -a.Z);
        }

        /***************************************************/

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        /***************************************************/

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        /***************************************************/

        public static Vector operator *(double b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
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
            return a != null && b != null && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        /***************************************************/

        public static bool operator !=(Vector a, Vector b)
        {
            return a == null || b == null || a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }

    }
}

