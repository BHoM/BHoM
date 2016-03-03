using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry 
{
    /// <summary>
    /// BHoM Point object
    /// </summary>
    [Serializable]
    public class Point : IPoint
    {
        private double[] m_Coordinates;

        /// <summary>X coordinate</summary>
        public double X 
        { 
            get
            {
                return m_Coordinates[0];
            }     
            set
            {
                m_Coordinates[0] = value;
            }
        }
        /// <summary>Y coordinate</summary>
        public double Y  
        {
            get
            {
                return m_Coordinates[1];
            }     
            set
            {
                m_Coordinates[1] = value;
            }
        }
        /// <summary>Z coordinate</summary>
        public double Z 
        {
            get
            {
                return m_Coordinates[2];
            }     
            set
            {
                m_Coordinates[2] = value;
            }
        }

        /// <summary>
        /// Construct an empty point
        /// </summary>
        public Point()
        {
            X = double.NaN;
            Y = double.NaN;
            Z = double.NaN;
        }

        /// <summary>
        /// Construct a point from coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            m_Coordinates = new double[] {x, y, z};
        }

        /// <summary>
        /// Duplicate a point
        /// </summary>
        /// <param name="dup"></param>
        public Point(Point dup)
        {
            m_Coordinates = new double[] { dup.X, dup.Y, dup.Z };           
        }

        internal Point(double[] coords)
        {
            m_Coordinates = coords;
        }
       
        /// <summary>
        /// Gets or sets the coordinates as an array
        /// </summary>
        public double[] CartesianCoordinates
        {
            get { return m_Coordinates;}        
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
        public Point Duplicate()
        {
            return new Point(this);
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

 
    }
}
