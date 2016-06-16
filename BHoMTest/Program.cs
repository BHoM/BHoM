using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Structural;
using BHoM.Structural.SectionProperties;
using BHoM.Global;
using BHoM.Structural.Loads;
using System.IO;
using System.Diagnostics;
using R = Rhino.Geometry;
using BHoM.Structural.Results;
using BHoM.Structural.Results.Bars;
using MongoDB.Driver;
using MongoDB.Bson;

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
            TestMongo();

            Console.Read();
        }

        static void TestMongo()
        {
            // Create a fake project
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 10; i++)
                nodes.Add(new Node(i, 2, 3));

            List<Bar> bars = new List<Bar>();
            for (int i = 1; i < 10; i++)
                bars.Add(new Bar(nodes[i - 1], nodes[i]));

            var project = Project.ActiveProject;
            foreach (Node node in nodes)
                project.AddObject(node);
            foreach (Bar bar in bars)
                project.AddObject(bar);

            /*// Start mongo server
            string mongoFolder = "c:\\Mongo\\test";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "mongod";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.Arguments = "--dbpath " + mongoFolder;
            Process mongod = Process.Start(start);*/


            // Create database
            var mongo = new MongoClient();
            var database = mongo.GetDatabase("project");
            var collection = database.GetCollection<BsonDocument>("bhom");

            // Test writing to and from JSON
            string json = project.Objects.First().ToJSON();
            Node n = (Node) Node.FromJSON(json);

            // Write the first project element into the database
            //string json = project.Objects.First().ToJSON();
            BsonDocument doc = BsonDocument.Parse(json);
            collection.InsertOne(doc);

            // Write project into database
            var documents = project.Objects.Select(x => BsonDocument.Parse(x.ToJSON()));
            collection.InsertMany(documents);

            // Get the number of elements in the database
            var count = collection.Count(new BsonDocument());
            Console.WriteLine("{0} elements are in eth database", count);

            var filter = new BsonDocument();
            var result = collection.Find(filter);
            var js = result.ToList().Select(x => BHoMObject.FromJSON(x.ToString()));

            //mongod.Kill();
        }

        static void TestWrite()
        {
            Node n1 = new Node(1, 1, 1);
            n1.CustomData.Add("Number", 1);
            Project.ActiveProject.AddObject(new Node(1, 1, 1));

            ObjectManager<int, Node> nodes = new ObjectManager<int, Node>("Number", FilterOption.UserData);
            int num = nodes.GetUniqueNumber();
            nodes.Add(2, new Node(0, 0, 0));
            ObjectManager<int, Bar> bars = new ObjectManager<int, Bar>("Number", FilterOption.UserData);

            Bar b = new Bar(nodes[0], nodes[2]);

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

        static void TestFastSQL()
        {
            Console.WriteLine("Program Test Running...");
            string[] loadCase = new string[] { "DL", "LL", "SDL", "DL+LL", "LC1", "LC2", "LC3", "LC4", "LC5", "LC6", "LC1", "LC2", "LC3", "LC4", "LC5" };
            ResultServer<BarForce> results = new ResultServer<BarForce>(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test1.mdf"));

            List<BarForce> resultsList = new List<BarForce>();
            Random r = new Random();
            List<string> barNums = new List<string>();
            List<string> cases = new List<string>();
            int counter = 0;
            int tolalCount = 0;
            results.ClearData();
            Stopwatch sw = new Stopwatch();
            sw.Start();


            for (int j = 0; j < 50/*loadCase.Length*/; j++)
            {
                for (int timeStep = 1; timeStep < 5; timeStep++)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        for (int segment = 0; segment < 3; segment++)
                        {
                            resultsList.Add(new BarForce((i + 1), j, segment, timeStep, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20));
                            counter++;
                            tolalCount++;
                            if (counter == 1000000)
                            {
                                results.StoreData(resultsList);
                                resultsList.Clear();
                                counter = 0;
                                Console.WriteLine("Added block = {0}", sw.Elapsed);

                            }
                        }
                    }
                }

            }
            results.StoreData(resultsList);
            resultsList.Clear();

            for (int i = 0; i <= 2000; i++)
            {
                barNums.Add(i.ToString());
            }

            for (int i = 0; i < 50; i++)
            {
                cases.Add(i.ToString());
            }

            // barNums.Reverse();      

            Console.WriteLine("Time Elapsed to store {0} results to DB = {1}", tolalCount, sw.Elapsed);
            //System.IO.
            sw.Restart();

            results.NameSelection = barNums;
            results.LoadcaseSelection = cases;

            results.LoadData();

            Console.WriteLine("Time Elapsed to load {0} results into memory = {1}, ", results.ResultCount.ToString(), sw.Elapsed);
            sw.Restart();

            results.MaxEnvelope();

            Console.WriteLine("Time taken to Envelope all results = {0}", sw.Elapsed);

            sw.Restart();
            List<BarForce> barForce1 = results.ToList();


            Console.WriteLine("Time taken to type convert all data to List = {0}", sw.Elapsed);

            sw.Restart();
            List<object[]> barForce3 = results.ToListData();


            Console.WriteLine("Time taken to load raw data to list = {0}", sw.Elapsed);
            sw.Restart();

            results.OrderBy = ResultOrder.Loadcase;

            Console.WriteLine("Time taken To reorder = {0}", sw.Elapsed);

            sw.Restart();


            sw.Stop();
            Console.ReadLine();
        }

        static void TestJSON()
        {
            //results.ClearData();
            //TestWrite();
            // Polyline line = new Polyline(new List<Point>() { new Point(-150, 10, 0), new Point(150, 10, 0) });

            // Polyline line1 = new Polyline(
            //     new List<Point>() {
            //         new Point(-50, -200, 0),
            //         new Point(-50, 200, 0),
            //         new Point(100,100,0),
            //         new Point(100,-100,0)
            //     });

            // Circle c = new Circle(100, new Plane(new Point(0, 0, 0), new Vector(0, 0, 1)));

            // Group<Curve> crvs = new Group<Curve>(new List<Curve>() { c,line });

            // string groupJson = crvs.ToJSON();

            // GeometryBase jsonResult = GeometryBase.FromJSON(groupJson);

            // SectionProperty prop = SectionProperty.LoadFromDB("L250x250x25");

            // SectionCalculator sc = new SectionCalculator(prop.Edges);
            // double area = sc.Area;
            // double cy = sc.CentreY;
            // double cx = sc.CentreX;
            // Plane plane = new Plane(new Point(0, 0, 0), new Vector(0, 0, 1));
            // Arc arc1 = new Arc(Math.PI, Math.PI / 2, 2, new Plane(new Point(2, 0, -1), new Vector(0, 1, 0)));
            // List<Point> p5 = Intersect.PlaneCurve(plane, arc1, 0.001);
            // //string[] sections = new BHoM.Structural.SectionProperties.DataBaseAdapter()

            // TestObj obj = new TestObj();
            // string objS = obj.ToJSON();

            // BHoMObject bOo = BHoMObject.FromJSON(objS);

            // Arc a = new Arc(new Point(0, 0, 0), new Point(1, 0, 0), new Point(0.5, 0.1, 0));
            // string s = a.ToJSON();
            // Arc b = GeometryBase.FromJSON(s) as Arc;

            // Polyline p = new Polyline(new List<Point>() { new Point(0, 0, 0), new Point(1, 0, 0), new Point(0.5, 0.1, 0) });
            // string s1 = p.ToJSON();
            // Polyline p2 = GeometryBase.FromJSON(s1) as Polyline;

            // Vector v = new Vector(0, 2, 5);
            // string s2 = v.ToJSON();
            // Vector r = GeometryBase.FromJSON(s2) as Vector;

            // ObjectManager<Node> nodes = new ObjectManager<Node>();
            // ObjectManager<Bar> bars = new ObjectManager<Bar>();
            // int num = nodes.GetUniqueNumber();

            // Stopwatch sw = new Stopwatch();

            // sw.Start();
            //// R.Arc rArc= new Rhino.Geometry.Arc(new R.Plane(new Rhino.Geometry.Point3d(2, 0, -1), new Rhino.Geometry.Vector3d(0, 1, 0)), 2, Math.PI / 2);

            // for (int i = 0; i < 100000; i++)
            // {
            //     List<Point> p19 = Intersect.PlaneCurve(plane, arc1, 0.001);
            //     //Intersect.CurveCurve(line, c);
            //     // R.Intersect.CurveIntersections cI = R.Intersect.Intersection.CurvePlane(R.NurbsCurve.CreateFromArc(rArc), new Rhino.Geometry.Plane(R.Point3d.Origin, R.Vector3d.ZAxis),0.01);
            //     //nodes.Add((i+1).ToString(), new Node(i, i, i));
            // }

            // for (int i = 0; i < 100 - 1; i++)
            // {
            //     //BHoM.Structural.SectionProperties.SectionCalculator sC = new BHoM.Structural.SectionProperties.SectionCalculator(crvs);

            //     //double Area = sC.Area;
            //     // bars.Add((i + 1).ToString(), new Bar(nodes[(i + 1).ToString()], nodes[(i + 2).ToString()]));
            // }

            //IEnumerable<Bar> barFilteredList = new ObjectFilter<Bar>().Where(bar => bar.Name.Contains("1"));


            // //List<Bar> cBars = new List<Bar>();
            // //ObjectFilter<Bar> bFilter = new ObjectFilter<Bar>();

            // //foreach (Node n in nodes)
            // //{
            // //    cBars.AddRange(bFilter.Where(b => b.StartNode == n || b.EndNode == n));

            // //}

            // sw.Stop();

            // Console.WriteLine("Time to Add {0} nodes and {1} bars was {2} ", nodes.Count, bars.Count, sw.Elapsed);


            // //Console.WriteLine("Node {0} is located at {1}", 4, nodes[4.ToString()].Point.ToString());

            // Console.ReadLine();
            ////PointForce pF = new PointForce(null, 1, 1, 1, 1, 1, 1);
            ////pF.Objects.Add(nodes[1]);
            //// string json = pF.ToJSON();

            ////BHoMObject bO= BHoMObject.FromJSON(json);
        }
    }
}
