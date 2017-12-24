using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;



namespace BHoMTest
{


    public class TestObj : BHoMObject
    {
        public List<Point> Data { get; set; }
        public TestObj()
        {
            Point p1 = new Point(0, 0, 0);
            Point p2 = new Point(1, 2, 4);
            Data = new List<Point>() { p1, p2 };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}