using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class BoundingBox
    {
        public Point Max
        {
            get
            {
                return Centre + Extents;
            }
        }

        public Point Min
        {
            get
            {
                return Centre - Extents;
            }
        }
      
        public Vector Extents { get; private set; }
        public Point Centre { get; private set; }


        public BoundingBox(Point min, Point max)
        {
            Point Min = Point.Min(min, max);
            Point Max = Point.Max(min, max);

            Extents = (Max - Min) / 2;
            Centre = (Max + Min) / 2;
        }

        public BoundingBox(List<Point> pnts)
        {
            Point Min = Point.Min(pnts);
            Point Max = Point.Max(pnts);

            Extents = (Max - Min) / 2;
            Centre = (Max + Min) / 2;
        }

        internal BoundingBox(double[] points, int dimension)
        {
            int[] maxMin = VectorUtils.MaxMin(points, dimension + 1);
            Point Max = new Point(points[maxMin[0]], points[maxMin[1]], points[maxMin[2]]);
            Point Min = new Point(points[maxMin[3]], points[maxMin[4]], points[maxMin[5]]);
            Extents = (Max - Min) / 2;
            Centre = (Max + Min) / 2;
        }

        public static BoundingBox Merge(BoundingBox b1, BoundingBox b2)
        {
            Point Max = Point.Max(b1.Max, b2.Max);
            Point Min = Point.Min(b1.Min, b2.Min);
            return new BoundingBox(Min, Max);
        }

        public static bool InRange(BoundingBox b1, BoundingBox b2)
        {
            double[] v1 = b2.Centre - b1.Centre;
            double[] v2 = b1.Extents + b2.Extents;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] > v2[i]) return false;
            }
            return true;
        }
    }
}
