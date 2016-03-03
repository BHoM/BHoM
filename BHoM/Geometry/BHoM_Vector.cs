using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Vector object
    /// </summary>
    [Serializable]
    public class Vector
    {
        /// <summary>X coordinate</summary>
        public double X { get; private set; }
        /// <summary>Y coordinate</summary>
        public double Y { get; private set; }
        /// <summary>Z coordinate</summary>
        public double Z { get; private set; }

        /// <summary>
        /// Constructs an empty vector
        /// </summary>
        public Vector()
        {
            X = double.NaN;
            Y = double.NaN;
            Z = double.NaN;
        }

        /// <summary>
        /// Constructs a vector from XYZ coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Constructs a vector from two points
        /// </summary>
        /// <param name="StartPoint">Start Point</param>
        /// <param name="EndPoint">End Point</param>
        public Vector(Point StartPoint, Point EndPoint)
        {
            X = EndPoint.X - StartPoint.X;
            Y = EndPoint.Y - StartPoint.Y;
            Z = EndPoint.Z - StartPoint.Z;
        }

        /// <summary>
        /// Duplicates a vector
        /// </summary>
        /// <param name="dup"></param>
        public Vector(Vector dup)
        {
            X = dup.X;
            Y = dup.Y;
            Z = dup.Z;
        }

        /// <summary>
        /// Constructs a vector from a point
        /// </summary>
        /// <param name="pt"></param>
        public Vector(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
            Z = pt.Z;
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(double a, Vector b)
        {
            return new Vector(a * b.X, a * b.Y, a * b.Z);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector((a.Y * b.Z) - (a.Z * b.Y), (a.Z * b.X) - (a.X * b.Z), (a.X * b.Y) - (a.Y * b.X));
        }

        /// <summary>
        /// Dot product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DotProduct(Vector a, Vector b)
        {
            return a * b;
        }

        /// <summary>
        /// Calculates the vector length
        /// </summary>
        public double Length
        {
            get { return Math.Sqrt(this * this); }
        }

        /// <summary>
        /// Sets the vector length to one unit
        /// </summary>
        /// <returns></returns>
        public bool Unitize()
        {
            if (this.IsValid)
            {
                double length = this.Length;

                this.X = this.X / length;
                this.Y = this.Y / length;
                this.Z = this.Z / length;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// True if the vector XYZ values are set
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z)) return false;

                else return true;
            }
        }

        /// <summary>
        /// Gets the vector length
        /// </summary>
        public double U
        {
            get { return this.Length; }
        }

        /// <summary>
        /// Duplicates the vector
        /// </summary>
        /// <returns></returns>
        public Vector Duplicate()
        {
            return new Vector(this);
        }

        /// <summary>
        /// Projects a vector onto a plane
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public Vector Project(Plane plane)
        {
            Vector u = this;
            Vector n = plane.Z;

            Vector proj = u - ((u * n) / (Math.Pow(n.Length, 2))) * n;

            return proj;
        }

        /// <summary>
        /// Roates vector using Rodrigues' rotation formula
        /// </summary>
        /// <param name="rad"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public Vector Rotate(double rad, Vector axis)
        {
            // using Rodrigues' rotation formula

            axis.Unitize();

            return this * Math.Cos(rad) + Vector.CrossProduct(axis, this) * Math.Sin(rad) + axis * (axis * this) * (1 - Math.Cos(rad));

        }

        /// <summary>
        /// Returns the reversed vector
        /// </summary>
        /// <returns></returns>
        public Vector Reverse()
        {
            return this * -1.0;
        }

        /// <summary>
        /// Calculate the angle in radians between two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double VectorAngle(Vector a, Vector b)
        {
            Vector u = a.Duplicate();
            Vector v = b.Duplicate();
            if (!u.Unitize() || !v.Unitize())
                return double.NegativeInfinity;

            double d = DotProduct(u, v);

            return SafeAcos(d);
        }

        /// <summary>
        /// Computes Acos with tolerance for rounding errors
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double SafeAcos(double d)
        {
            double tol = 0.00001;
            if (d > 1.0)
                if (d - 1.0 <= tol)
                    return Math.Acos(1.0);
            return Math.Acos(d);
        }

        /// <summary>
        /// Calculate the angle in radians between two vectors with a guide normal vector to determine sign
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static double VectorAngle(Vector a, Vector b, Vector normal)
        {
            double angle = VectorAngle(a, b);

            Vector crossproduct = CrossProduct(a, b);
            if (VectorAngle(crossproduct, normal) < (Math.PI / 2.0))
                return angle;
            else
                return -1.0 * angle;
        }

    }
}
