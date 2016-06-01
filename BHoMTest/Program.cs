using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Structural;
using BHoM.Global;
using BHoM.Structural.Loads;
using System.IO;
using System.Diagnostics;
using R = Rhino.Geometry;


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
            Polyline line = new Polyline(new List<Point>() { new Point(-150, 10, 0), new Point(150, 10, 0) });

            Polyline line1 = new Polyline(
                new List<Point>() {
                    new Point(-50, -200, 0),
                    new Point(-50, 200, 0),
                    new Point(100,100,0),
                    new Point(100,-100,0)
                });

            Circle c = new Circle(100, new Plane(new Point(0, 0, 0), new Vector(0, 0, 1)));

            Group<Curve> crvs = new Group<Curve>(new List<Curve>() { c,line });

            string groupJson = crvs.ToJSON();

            GeometryBase jsonResult = GeometryBase.FromJSON(groupJson);


            Plane plane = new Plane(new Point(0, 0, 0), new Vector(0, 0, 1));
            Arc arc1 = new Arc(Math.PI, Math.PI / 2, 2, new Plane(new Point(2, 0, -1), new Vector(0, 1, 0)));
            List<Point> p5 = Intersect.PlaneCurve(plane, arc1);
            string[] sections = new BHoM.Structural.SectionProperties.SectionDB().SectionNames().ToArray();

            TestObj obj = new TestObj();
            string objS = obj.ToJSON();

            BHoMObject bOo = BHoMObject.FromJSON(objS);

            Arc a = new Arc(new Point(0, 0, 0), new Point(1, 0, 0), new Point(0.5, 0.1, 0));
            string s = a.ToJSON();
            Arc b = GeometryBase.FromJSON(s) as Arc;

            Polyline p = new Polyline(new List<Point>() { new Point(0, 0, 0), new Point(1, 0, 0), new Point(0.5, 0.1, 0) });
            string s1 = p.ToJSON();
            Polyline p2 = GeometryBase.FromJSON(s1) as Polyline;

            Vector v = new Vector(0, 2, 5);
            string s2 = v.ToJSON();
            Vector r = GeometryBase.FromJSON(s2) as Vector;

            ObjectManager<Node> nodes = new ObjectManager<Node>();
            ObjectManager<Bar> bars = new ObjectManager<Bar>();
            int num = nodes.GetUniqueNumber();

            Stopwatch sw = new Stopwatch();

            sw.Start();
           // R.Arc rArc= new Rhino.Geometry.Arc(new R.Plane(new Rhino.Geometry.Point3d(2, 0, -1), new Rhino.Geometry.Vector3d(0, 1, 0)), 2, Math.PI / 2);

            for (int i = 0; i < 10000; i++)
            {
               // List<Point> p19 = Intersect.PlaneCurve(plane, arc1);
                Intersect.CurveCurve(line, c);
                // R.Intersect.CurveIntersections cI = R.Intersect.Intersection.CurvePlane(R.NurbsCurve.CreateFromArc(rArc), new Rhino.Geometry.Plane(R.Point3d.Origin, R.Vector3d.ZAxis),0.01);
                //nodes.Add((i+1).ToString(), new Node(i, i, i));
            }

            for (int i = 0; i < 100 - 1; i++)
            {
                //BHoM.Structural.SectionProperties.SectionCalculator sC = new BHoM.Structural.SectionProperties.SectionCalculator(crvs);

                //double Area = sC.Area;
                // bars.Add((i + 1).ToString(), new Bar(nodes[(i + 1).ToString()], nodes[(i + 2).ToString()]));
            }

           IEnumerable<Bar> barFilteredList = new ObjectFilter<Bar>().Where(bar => bar.Name.Contains("1"));
                      
                     
            //List<Bar> cBars = new List<Bar>();
            //ObjectFilter<Bar> bFilter = new ObjectFilter<Bar>();

            //foreach (Node n in nodes)
            //{
            //    cBars.AddRange(bFilter.Where(b => b.StartNode == n || b.EndNode == n));

            //}

            sw.Stop();

            Console.WriteLine("Time to Add {0} nodes and {1} bars was {2} ", nodes.Count, bars.Count, sw.Elapsed);
           

            //Console.WriteLine("Node {0} is located at {1}", 4, nodes[4.ToString()].Point.ToString());
            
            Console.ReadLine();
            ////PointForce pF = new PointForce(null, 1, 1, 1, 1, 1, 1);
            ////pF.Objects.Add(nodes[1]);
            //// string json = pF.ToJSON();

            ////BHoMObject bO= BHoMObject.FromJSON(json);
        }

        static void TestWrite()
        {
            Node n1 = new Node(1, 1, 1);
            n1.CustomData.Add("Number", 1);
            Project.ActiveProject.AddObject(new Node(1, 1, 1));

            ObjectManager<int, Node> nodes = new ObjectManager<int, Node>("Number", FilterOption.Property);
            int num = nodes.GetUniqueNumber();
            nodes.Add(2, new Node(0, 0, 0));
            ObjectManager<int, Bar> bars = new ObjectManager<int, Bar>("Number", FilterOption.Property);

            Bar b = new Bar(nodes[1], nodes[2]);

            bars.Add(1, b);

            string output = b.ToJSON();
            
            string json = Project.ActiveProject.ToJSON();
            using (StreamWriter fs = new StreamWriter(@"C:\Users\edalton\Documents\temp.js"))
            {
                fs.WriteLine(json);
                fs.Close();
            }
        }

        static void TestRead()
        {
            using (StreamReader fs = new StreamReader(@"C:\Users\edalton\Documents\temp.js"))
            {
                Project p = Project.FromJSON(fs.ReadToEnd());
                fs.Close();
            }
        }
    }
}
