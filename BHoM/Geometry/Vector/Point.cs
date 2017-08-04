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
        /**** Local Optimisation Methods                ****/
        /***************************************************/

        public object GetClone() // Optimisation
        {
            return new Point(X, Y, Z);
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




        //public bool IsValid()
        //{
        //    return !(double.IsNaN(X) || double.IsNaN(Y) || double.IsNaN(Z));
        //}

        ///***************************************************/

        //public string ToString(int decimals = int.MaxValue)
        //{
        //    if (decimals == int.MaxValue)
        //        return "[" + X + ", " + Y + ", " + Z + "]";
        //    else
        //        return "[" + Math.Round(X, decimals) + ", " + Math.Round(Y, decimals) + ", " + Math.Round(Z, decimals) + "]";
        //}

        ///***************************************************/

        ///***************************************************/
        ///**** IBHoMGeometry Interface                   ****/
        ///***************************************************/

        //public GeometryType GetGeometryType()
        //{
        //    return GeometryType.Point;
        //}

        ///***************************************************/

        //public BoundingBox GetBounds()
        //{
        //    return new BoundingBox(this, this);
        //}



        ///***************************************************/

        //public IBHoMGeometry GetTranslated(Vector t)
        //{
        //    return this + t;
        //}



        ///// <summary>
        ///// Calcualte mean pt from list of points
        ///// </summary>
        ///// <param name="pts"></param>
        ///// <returns></returns>
        //public static Point Average(List<Point> pts)
        //{
        //    int count = pts.Count;
        //    if (count < 1) return null;
        //    Point mean = new Point(pts[0]);

        //    for (int i = 1; i < count; i++)
        //        mean += pts[i];

        //    return mean /= count;
        //}

        ///// <summary>
        ///// Calcualte max pt from list of points
        ///// </summary>
        ///// <param name="pts"></param>
        ///// <returns></returns>
        //public static Point Max(List<Point> pts)
        //{
        //    int count = pts.Count;
        //    if (count < 1) return null;
        //    Point max = new Point(pts[0]);

        //    for (int i = 1; i < count; i++)
        //        max = Max(max, pts[i]);

        //    return max;
        //}

        ///// <summary>
        ///// Calcualte min pt from list of points
        ///// </summary>
        ///// <param name="pts"></param>
        ///// <returns></returns>
        //public static Point Min(List<Point> pts)
        //{
        //    int count = pts.Count;
        //    if (count < 1) return null;
        //    Point min = new Point(pts[0]);

        //    for (int i = 1; i < count; i++)
        //        min = Min(min, pts[i]);

        //    return min;
        //}

        ///// <summary>
        ///// Max Values
        ///// </summary>
        ///// <param name="p1"></param>
        ///// <param name="p2"></param>
        ///// <returns>Max of X,Y,Z values</returns>
        //public static Point Max(Point p1, Point p2)
        //{
        //    return new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), Math.Max(p1.Z, p2.Z));
        //}

        ///// <summary>
        ///// Min Values
        ///// </summary>
        ///// <param name="p1"></param>
        ///// <param name="p2"></param>
        ///// <returns>Min of X,Y,Z Values</returns>
        //public static Point Min(Point p1, Point p2)
        //{
        //    return new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Min(p1.Z, p2.Z));
        //}

        ///// <summary>
        ///// Get the distance from a point 
        ///// </summary>
        ///// <param name="p"></param>
        ///// <returns></returns>
        //public double DistanceTo(Point p)
        //{
        //    return (this - p).Length;
        //}

        //public double SquareDistanceTo(Point p)
        //{
        //    return (this - p).SquareLength;
        //}

        ///// <summary>
        ///// Constructs a point at 0,0,0
        ///// </summary>
        //public static Point Origin
        //{
        //    get
        //    {
        //        return new Point(0, 0, 0);
        //    }
        //}

