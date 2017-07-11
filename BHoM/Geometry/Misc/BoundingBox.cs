using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public class BoundingBox
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Min { get; set; } = new Point();

        public Point Max { get; set; } = new Point();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BoundingBox() { }

        /***************************************************/

        public BoundingBox(Point min, Point max)
        {
            Min = min;
            Max = max;
        }

        /***************************************************/

        public BoundingBox(Point centre, Vector extent)
        {
            Min = new Point(centre.X - extent.X, centre.Y - extent.Y, centre.Z - extent.Z);
            Max = new Point(centre.X + extent.X, centre.Y + extent.Y, centre.Z + extent.Z);
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/
      
        public Vector GetExtents()
        {
            return new Vector(Max.X-Min.X, Max.Y-Min.Y, Max.Z-Min.Z);
        }

        /***************************************************/

        public Point GetCentre()
        {
            return new Point((Max.X + Min.X)/2, (Max.Y + Min.Y) / 2, (Max.Z + Min.Z) / 2);
        }

        /***************************************************/

        public override string ToString()
        {
            return "Min: " + Min.ToString(3) + ", Max: " + Max.ToString(3);
        }


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static BoundingBox operator +(BoundingBox a, BoundingBox b)
        {
            Point min = new Point(Math.Min(a.Min.X, b.Min.X), Math.Min(a.Min.Y, b.Min.Y), Math.Min(a.Min.Z, b.Min.Z));
            Point max = new Point(Math.Max(a.Max.X, b.Max.X), Math.Max(a.Max.Y, b.Max.Y), Math.Max(a.Max.Z, b.Max.Z));

            return new BoundingBox(min, max);
        }

        /***************************************************/

        public static BoundingBox operator +(BoundingBox box, Vector v)
        {
            return new BoundingBox(box.Min + v, box.Max + v);
        }


        //public BoundingBox(List<Point> pnts)
        //{
        //    Point Min = Point.Min(pnts);
        //    Point Max = Point.Max(pnts);

        //    Extents = (Max - Min) / 2;
        //    Centre = (Max + Min) / 2;
        //}

        //internal BoundingBox(double[] points, int dimension)
        //{
        //    int[] maxMin = CollectionUtils.MaxMinIndices(points, dimension + 1);
        //    Point Max = new Point(points[maxMin[0]], points[maxMin[1]], points[maxMin[2]]);
        //    Point Min = new Point(points[maxMin[3]], points[maxMin[4]], points[maxMin[5]]);
        //    Extents = (Max - Min) / 2;
        //    Centre = (Max + Min) / 2;
        //}

        //public static BoundingBox Merge(BoundingBox b1, BoundingBox b2)
        //{
        //    Point Max = Point.Max(b1.Max, b2.Max);
        //    Point Min = Point.Min(b1.Min, b2.Min);
        //    return new BoundingBox(Min, Max);
        //}

        //public void Merge(BoundingBox b)
        //{
        //    Point max = Point.Max(Max, b.Max);
        //    Point min = Point.Min(Min, b.Min);
        //    Extents = (max - min) / 2;
        //    Centre = (max + min) / 2;
        //}

        //public static bool InRange(BoundingBox b1, BoundingBox b2, double tolerance = 0)
        //{
        //    double[] v1 = b2.Centre - b1.Centre;
        //    double[] v2 = b1.Extents + b2.Extents;
        //    for (int i = 0; i < v1.Length; i++)
        //    {
        //        if (Math.Abs(v1[i]) > v2[i]) return false;
        //    }
        //    return true;
        //}

        //public bool Contains(BoundingBox box)
        //{
        //    return (Min.X <= box.Min.X && Min.Y <= box.Min.Y && Min.Z <= box.Min.Z && Max.X >= box.Max.X && Max.Y >= box.Max.Y && Max.Z >= box.Max.Z); 
        //}

        //public BoundingBox Add(IBHoMGeometry obj)
        //{
        //    BoundingBox other = obj.GetBounds();
        //    Point max = Point.Max(other.Max, Max);
        //    Point min = Point.Min(other.Min, Min);
        //    return new BoundingBox(min, max);
        //}

        //public BoundingBox Add(List<IBHoMGeometry> obj)
        //{
        //    Point max = Max;
        //    Point min = Min;
        //    for (int i = 0; i < obj.Count; i++)
        //    {
        //        BoundingBox other = obj[i].GetBounds();
        //        max = Point.Max(other.Max, Max);
        //        min = Point.Min(other.Min, Min);
        //    }
        //    return new BoundingBox(min, max);
        //}

        //public bool Contains(Point p)
        //{
        //    double[] max = Max;
        //    double[] min = Min;
        //    double[] pnt = p;
        //    for (int i = 0; i < pnt.Length; i++)
        //    {
        //        if (pnt[i] > max[i]) return false;
        //        if (pnt[i] < min[i]) return false;
        //    }
        //    return true;
        //}

        //public BoundingBox Inflate(double amount)
        //{
        //    Vector extents = Extents + new Vector(amount, amount, amount);
        //    return new BoundingBox(Centre - extents, Centre + extents);
        //}


    }
}
