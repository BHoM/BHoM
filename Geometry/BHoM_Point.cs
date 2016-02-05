using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    [Serializable]
    public class Point
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        

        public Point()
        {

            X = double.NaN;
            Y = double.NaN;
            Z = double.NaN;
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public Point(Point dup)
        {
            X = dup.X;
            Y = dup.Y;
            Z = dup.Z;

        }
       
        public double[] XYZ
        {
            get { return new double[3]{X, Y, Z};}
            set 
            {
                X = value[0];
                Y = value[1];
                Z = value[2];
            }
        }

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

       
        public Point Duplicate()
        {
            return new Point(this);
        }

        public static Vector operator -(Point a, Point b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point operator -(Point a, Vector b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Point operator *(Point a, double b)
        {
            return new Point(a.X * b, a.Y * b, a.Z * b);
        }

        public static Point operator *(double a, Point b)
        {
            return new Point(a * b.X, a * b.Y, a * b.Z);
        }

        public static Point operator /(Point a, double b)
        {
            return new Point(a.X / b, a.Y / b, a.Z / b);
        }

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


        public double DistanceTo(Point p)
        {
            return (this - p).Length;
        }


        public static Point Origin
        {
            get
            {
                return new Point(0, 0, 0);
            }
        }

 
    }
}
