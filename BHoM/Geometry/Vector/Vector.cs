using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;
using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Vector object
    /// </summary>
    public class Vector : GeometryBase
    {
        private double[] Coordinates;

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
            Coordinates = BHoM.Common.Utils.Copy<double>(dup);
        }

        /// <summary>
        /// Constructs a vector from a point
        /// </summary>
        /// <param name="pt"></param>
        public Vector(Point pt)
        {
            Coordinates = BHoM.Common.Utils.Copy<double>(pt);
        }

        internal Vector(double[] v)
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
            return new Vector(VectorUtils.Add(a, b));
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(VectorUtils.Sub(a, b));
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(VectorUtils.Divide(a, b));
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(VectorUtils.Multiply(a, b));
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(double a, Vector b)
        {
            return new Vector(VectorUtils.Multiply(b, a));
        }

        /// <summary>
        /// Vector operations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Vector b)
        {
            return VectorUtils.DotProduct(a, b);
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector(VectorUtils.CrossProduct(a, b));
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
            get { return VectorUtils.Length(this); }
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

                Coordinates = VectorUtils.Normalise(this);
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
        public Vector DuplicateVector()
        {
            return new Vector(this);
        }

        /// <summary>
        /// Rotates vector using Rodrigues' rotation formula
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
            return VectorUtils.Angle(a, b);
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

        public bool IsParallel(Vector v, double tolerance = 0.0001)
        {
            return (VectorUtils.Parallel(Coordinates, v.Coordinates, tolerance) != 0);
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

        /// <summary>
        /// Transform Vector
        /// </summary>
        /// <param name="t">Transformation matrix</param>
        public override void Transform(Transform t)
        {
            Coordinates = VectorUtils.Multiply(t, Coordinates);
        }

        public override void Translate(Vector v) { }

        /// <summary>
        /// Mirrors vector about a plane
        /// </summary>
        /// <param name="p"></param>
        public override void Mirror(Plane p)
        {
            Coordinates = VectorUtils.Add(p.ProjectionVectors(Coordinates, 2), Coordinates);
        }

        /// <summary>
        /// Projects a vector onto a plane
        /// </summary>
        /// <param name="plane"></param>
        public override void Project(Plane p)
        {
            Coordinates = VectorUtils.Add(p.ProjectionVectors(Coordinates), Coordinates);
        }

        public override void Update() { }

        public override GeometryBase Duplicate()
        {
            return this.DuplicateVector();
        }

        public override string ToJSON()
        {
            return "{\"__Type__\": \"" + this.GetType().FullName + "\", \"Vector\": " + ToString() + "}";
        }

        public static new Vector FromJSON(string json, Project project = null)
        {
            if (project == null)
                project = Global.Project.ActiveProject;

            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);

            return new Vector(BHoMJSON.ReadValue(typeof(double[]), definition["Vector"], project) as double[]);
        }
    }
}
