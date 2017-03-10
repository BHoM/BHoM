using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Vector object
    /// </summary>
    public class Vector : BHoMGeometry
    {
        private double[] m_Coordinates;
        public double[] Coordinates { get; }

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Vector;
            }
        }


        /// <summary>X coordinate</summary>
        public double X
        {
            get
            {
                return Coordinates[0];
            }
            set
            {
                Coordinates[0] = value;
            }
        }
        /// <summary>Y coordinate</summary>
        public double Y
        {
            get
            {
                return Coordinates[1];
            }
            set
            {
                Coordinates[1] = value;
            }
        }
        /// <summary>Z coordinate</summary>
        public double Z
        {
            get
            {
                return Coordinates[2];
            }
            set
            {
                Coordinates[2] = value;
            }
        }

        public double this[int i]
        {
            get
            {
                return Coordinates[i];
            }
        }


        public void SetCoordinates(double[] coords)
        {
            m_Coordinates = coords;
        }

        /// <summary>
        /// Constructs an empty vector
        /// </summary>
        public Vector()
        {
            Coordinates = new double[4];
        }

        /// <summary>
        /// Constructs a vector from XYZ coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            Coordinates = new double[] { x, y, z, 0 };
        }

        /// <summary>
        /// Duplicates a vector
        /// </summary>
        /// <param name="dup"></param>
        public Vector(Vector dup)
        {
            Coordinates = Utils.Copy<double>(dup);
        }

        /// <summary>
        /// Constructs a vector from a point
        /// </summary>
        /// <param name="pt"></param>
        public Vector(Point pt)
        {
            Coordinates = Utils.Copy<double>(pt);
        }

        public Vector(double[] v)
        {
            Coordinates = v;
        }

        public static implicit operator double[] (Vector v)
        {
            return v.Coordinates;
        }

        public static Vector Zero
        {
            get { return new Vector(0, 0, 0); }
        }


        public static Vector XAxis(double n = 1)
        {
            return new Vector(n, 0, 0);
        }

        public static Vector YAxis(double n = 1)
        {
            return new Vector(0, n, 0);
        }

        public static Vector ZAxis(double n = 1)
        {
            return new Vector(0, 0, n);
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
            return new Vector(a.X/b, a.Y/b, a.Z/b);
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
        public static Vector operator *(double b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Vector b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Point b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Point a, Vector b)
        {
            return (a.X * b.X + a.Y * b.Y + a.Z * b.Z);
        }


        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector(
                a[1] * b[2] - a[2] * b[1],
                a[2] * b[0] - a[0] * b[2],
                a[0] * b[1] - a[1] * b[0]
            );
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
        /// Dot product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DotProduct(Vector a, Point b)
        {
            return a * b;
        }

        /// <summary>
        /// Dot product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DotProduct(Point a, Vector b)
        {
            return a * b;
        }


        /// <summary>
        /// Calculates the vector length
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(SquareLength);
            }
        }

        /// <summary>
        /// Calculates the vector length
        /// </summary>
        public double SquareLength
        {
            get
            {
                double result = 0;
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    result += Coordinates[i] * Coordinates[i];
                }
                return result;
            }
        }

        /// <summary>
        /// Sets the vector length to one unit
        /// </summary>
        /// <returns></returns>
        public Vector Normalise()
        {
            return this / Length;
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
        public Vector DuplicateVector()
        {
            return new Vector(this);
        }
      
        /// <summary>
        /// Returns the reversed vector
        /// </summary>
        /// <returns></returns>
        public Vector Reverse()
        {
            return this * -1.0;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + ", " + Z + "]";
        }

        public string ToString(int decimals)
        {
            return "[" + Math.Round(X, decimals) + ", " + Math.Round(Y, decimals) + ", " + Math.Round(Z, decimals) + "]";
        }

        public override BoundingBox Bounds()
        {
            return null;
        }

      

        public override void Update() { }

        public override BHoMGeometry Duplicate()
        {
            return this.DuplicateVector();
        }
    }
}
