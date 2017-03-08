using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BHoM.Base;

namespace BHoM.Geometry
{
    /// <summary>
    /// BHoM Point object
    /// </summary>
    public class Point : GeometryBase, IComparable<Point>
    {
        private double[] m_Coordinates;

        public override GeometryType GeometryType
        {
            get
            {
                return GeometryType.Point;
            }
        }

        public double[] Coordinates
        {
            get
            {
                return m_Coordinates;
            }
        }
        private int Offset = 0;

        /// <summary>X coordinate</summary>
        public double X
        {
            get
            {
                return Coordinates[Offset];
            }
            set
            {
                Coordinates[Offset] = value;
            }
        }
        /// <summary>Y coordinate</summary>
        public double Y
        {
            get
            {
                return Coordinates[Offset + 1];
            }
            set
            {
                Coordinates[Offset + 1] = value;
            }
        }
        /// <summary>Z coordinate</summary>
        public double Z
        {
            get
            {
                return Coordinates[Offset + 2];
            }
            set
            {
                Coordinates[Offset + 2] = value;
            }
        }

        public void SetCoordinates(double[] coords)
        {
            m_Coordinates = coords;
        }

        /// <summary>
        /// Construct an empty point
        /// </summary>
        public Point()
        {
            m_Coordinates = new double[] { 0, 0, 0, 1 };
        }

        /// <summary>
        /// Construct a point from coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            m_Coordinates = new double[] { x, y, z, 1 };
        }

        /// <summary>
        /// Construct a point from a double array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double[] v)
        {
            m_Coordinates = new double[4];
            Array.Copy(v, Coordinates, v.Length);
            Coordinates[3] = 1;
        }

        internal Point(double[] v, int startIndex)
        {
            m_Coordinates = v;
            Offset = startIndex;
        }

        /// <summary>
        /// Duplicate a point
        /// </summary>
        /// <param name="dup"></param>
        public Point(Point dup)
        {
            m_Coordinates = Utils.Copy<double>(dup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                return i >= 0 && i <= 4 && i + Offset < Coordinates.Length ? Coordinates[i + Offset] : double.NaN;
            }
            set
            {
                if (i >= 0 && i <= 4 && i + Offset < Coordinates.Length)
                {
                    Coordinates[i + Offset] = value;
                }
            }
        }

        public static implicit operator double[] (Point v)
        {
            return v.Coordinates.Length == 4 ? v.Coordinates : BHoM.Base.Utils.SubArray<double>(v.Coordinates, v.Offset, 4);
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

        /// <summary>
        /// Max Values
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Max of X,Y,Z values</returns>
        public static Point Max(Point p1, Point p2)
        {
            return new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), Math.Max(p1.Z, p2.Z));
        }

        /// <summary>
        /// Min Values
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Min of X,Y,Z Values</returns>
        public static Point Min(Point p1, Point p2)
        {
            return new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Min(p1.Z, p2.Z));
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

        public double SquareDistanceTo(Point p)
        {
            return (this - p).SquareLength;
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

        public string ToString(int decimals)
        {
            return "[" + Math.Round(X, decimals) + ", " + Math.Round(Y, decimals) + ", " + Math.Round(Z, decimals) + "]";
        }

        public override BoundingBox Bounds()
        {
            return new BoundingBox(this, this);
        }

        /// <summary>
        /// Compares two points in order of priority of X,Y,Z
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Point other)
        {
            int counter = 0;
            while (counter < 4 && this[counter] == other[counter])
            {
                counter++;
            }
            return this[counter].CompareTo(other[counter]);
        }

        public override void Update() { }
    }
}
