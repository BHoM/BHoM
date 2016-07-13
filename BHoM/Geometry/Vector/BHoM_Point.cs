using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Common;
using BHoM.Global;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Point object
    /// </summary>
    [Serializable]
    public class Point : GeometryBase, IComparable<Point>
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
        /// Construct an empty point
        /// </summary>
        public Point()
        {
            Coordinates = new double[] { 0, 0, 0, 1 };
        }

        /// <summary>
        /// Construct a point from coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            Coordinates = new double[] { x, y, z, 1 };
        }

        /// <summary>
        /// Construct a point from a double array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        internal Point(double[] v)
        {
            Coordinates = new double[4];
            Array.Copy(v, Coordinates, v.Length);
            Coordinates[3] = 1;
        }

        /// <summary>
        /// Duplicate a point
        /// </summary>
        /// <param name="dup"></param>
        public Point(Point dup)
        {
            Coordinates = BHoM.Common.Utils.Copy<double>(dup);
        }

        /// <summary>
        /// Create a point from json
        /// </summary>
        //public static Point FromJSON(string json)
        //{
        //    Point newPoint = new Point();
        //    int i0 = json.IndexOf('{') + 1;
        //    int i1 = json.LastIndexOf('}');
        //    string[] coords = json.Substring(i0, i1-i0).Split(',');

        //    if (coords.Length != 3) return null;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        double.TryParse(coords[i], out newPoint.Coordinates[i]);
        //    }

        //    return newPoint;
        //}


        public static implicit operator double[](Point v)
        {
            return v.Coordinates;
        }

        /// <summary>
        /// True if the point has valid coordinates
        /// </summary>
        public bool IsValid
        {
            get
            {

                if (double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z))
                {
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Duplicates a point
        /// </summary>
        /// <returns></returns>
        public Point DuplicatePoint()
        {
            return new Point(this);
        }


        /// <summary>
        /// Duplicates a point
        /// </summary>
        /// <returns></returns>
        public override GeometryBase Duplicate()
        {
            return DuplicatePoint();
        }

        /// <summary>
        /// Vector operations a-b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Point a, Point b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Vector operations a+b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Move point by adding a vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Move point by subtracting a vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator -(Point a, Vector b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Move a point by scaling coordinate values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator *(Point a, double b)
        {
            return new Point(a.X * b, a.Y * b, a.Z * b);
        }

        /// <summary>
        /// Move a point by scaling coordinate values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator *(double a, Point b)
        {
            return new Point(a * b.X, a * b.Y, a * b.Z);
        }

        /// <summary>
        /// Move a point by scaling coordinate values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator /(Point a, double b)
        {
            return new Point(a.X / b, a.Y / b, a.Z / b);
        }

        /// <summary>
        /// Point operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point operator /(double a, Point b)
        {
            return new Point(a / b.X, a / b.Y, a / b.Z);
        }

        /// <summary>
        /// Calcualte mean pt from list of points
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        public static Point Average(List<Point> pts)
        {
            int count = pts.Count;
            if (count < 1) return null;
            Point mean = new Point(pts[0]);

            for (int i = 1; i < count; i++)
                mean += pts[i];

            return mean /= count;
        }

        /// <summary>
        /// Calcualte max pt from list of points
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        public static Point Max(List<Point> pts)
        {
            int count = pts.Count;
            if (count < 1) return null;
            Point max = new Point(pts[0]);

            for (int i = 1; i < count; i++)
                max = Max(max, pts[i]);

            return max;
        }

        /// <summary>
        /// Calcualte min pt from list of points
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        public static Point Min(List<Point> pts)
        {
            int count = pts.Count;
            if (count < 1) return null;
            Point min = new Point(pts[0]);

            for (int i = 1; i < count; i++)
                min = Min(min, pts[i]);

            return min;
        }

        public static Point Max(Point p1, Point p2)
        {
            return new Point(VectorUtils.Max(p1, p2));
        }

        public static Point Min(Point p1, Point p2)
        {
            return new Point(VectorUtils.Min(p1, p2));
        }

        /// <summary>
        /// Get the distance from a point 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double DistanceTo(Point p)
        {
            return (this - p).Length;
        }

        /// <summary>
        /// Constructs a point at 0,0,0
        /// </summary>
        public static Point Origin
        {
            get
            {
                return new Point(0, 0, 0);
            }
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + ", " + Z + "]";
        }

        public override BoundingBox Bounds()
        {
            return null;
        }

        public override void Transform(Transform t)
        {
            Coordinates = VectorUtils.Multiply(t, Coordinates);
        }

        public override void Translate(Vector v)
        {
            Coordinates = VectorUtils.Add(v, Coordinates);
        }

        public override void Mirror(Plane p)
        {
            Coordinates = VectorUtils.Add(p.ProjectionVectors(Coordinates, 2), Coordinates);
        }

        public override void Project(Plane p)
        {
            Coordinates = VectorUtils.Add(p.ProjectionVectors(Coordinates), Coordinates);
        }

        public override void Update()
        {
        }

        public override string ToJSON()
        {
            return "{\"Primitive\": \"point\", \"point\": " + ToString() + "}";
        }

        public static new Point FromJSON(string json, Project project)
        {
            Dictionary<string, string> definition = BHoMJSON.GetDefinitionFromJSON(json);
            if (!definition.ContainsKey("Primitive")) return null;

            return new Point(BHoMJSON.ReadValue(typeof(double[]), definition["point"], project) as double[]);
        }

        public int CompareTo(Point other)
        {
            double value1 = X * 1E6 + Y * 1E3 + Z;
            double value2 = other.X * 1E6 + other.Y * 1E3 + other.Z;
            return value1.CompareTo(value2);
        }
    }
}
