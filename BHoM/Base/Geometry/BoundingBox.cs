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
            int[] maxMin = CollectionUtils.MaxMinIndices(points, dimension + 1);
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

        public void Merge(BoundingBox b)
        {
            Point max = Point.Max(Max, b.Max);
            Point min = Point.Min(Min, b.Min);
            Extents = (max - min) / 2;
            Centre = (max + min) / 2;
        }

        public static bool InRange(BoundingBox b1, BoundingBox b2, double tolerance = 0)
        {
            double[] v1 = b2.Centre - b1.Centre;
            double[] v2 = b1.Extents + b2.Extents;
            for (int i = 0; i < v1.Length; i++)
            {
                if (Math.Abs(v1[i]) > v2[i]) return false;
            }
            return true;
        }

        public bool Contains(BoundingBox box)
        {
            return (Min.X <= box.Min.X && Min.Y <= box.Min.Y && Min.Z <= box.Min.Z && Max.X >= box.Max.X && Max.Y >= box.Max.Y && Max.Z >= box.Max.Z); 
        }

        public BoundingBox Add(BHoMGeometry obj)
        {
            BoundingBox other = obj.Bounds();
            Point max = Point.Max(other.Max, Max);
            Point min = Point.Min(other.Min, Min);
            return new BoundingBox(min, max);
        }

        public BoundingBox Add(List<BHoMGeometry> obj)
        {
            Point max = Max;
            Point min = Min;
            for (int i = 0; i < obj.Count; i++)
            {
                BoundingBox other = obj[i].Bounds();
                max = Point.Max(other.Max, Max);
                min = Point.Min(other.Min, Min);
            }
            return new BoundingBox(min, max);
        }

        public bool Contains(Point p)
        {
            double[] max = Max;
            double[] min = Min;
            double[] pnt = p;
            for (int i = 0; i < pnt.Length; i++)
            {
                if (pnt[i] > max[i]) return false;
                if (pnt[i] < min[i]) return false;
            }
            return true;
        }

        public BoundingBox Inflate(double amount)
        {
            Vector extents = Extents + new Vector(amount, amount, amount);
            return new BoundingBox(Centre - extents, Centre + extents);
        }

        public override string ToString()
        {
            return "Centre: " + Centre.ToString(3) + ", Extents: " + Extents.ToString(3);
        }
    }
}
