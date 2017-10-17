using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using R = Rhino.Geometry;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;
using BH.oM.Base;

using BH.oM.Structural.Loads;
using BH.oM.Structural.Results;
using BH.oM.Structural.Elements;
using System.Xml;



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