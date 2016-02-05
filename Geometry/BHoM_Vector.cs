using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    [Serializable]
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector()
        {
            X = double.NaN;
            Y = double.NaN;
            Z = double.NaN;
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector dup)
        {
            X = dup.X;
            Y = dup.Y;
            Z = dup.Z;
        }

        public Vector(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
            Z = pt.Z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator *(double a, Vector b)
        {
            return new Vector(a * b.X, a * b.Y, a * b.Z);
        }

        public static double operator *(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }


        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector((a.Y * b.Z) - (a.Z * b.Y), (a.Z * b.X) - (a.X * b.Z), (a.X * b.Y) - (a.Y * b.X));
        }

        public static double DotProduct(Vector a, Vector b)
        {
            return a * b;
        }


        public double Length
        {
            get { return Math.Sqrt(this * this); }
        }

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

        public bool IsValid
        {
            get
            {
                if (double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z)) return false;

                else return true;
            }
        }

        public double U
        {
            get { return this.Length; }
        }

        public Vector Duplicate()
        {
            return new Vector(this);
        }

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
