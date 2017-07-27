﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using R = Rhino.Geometry;
using BHoM.Geometry;
using BHoM.Structural.Properties;
using BHoM.Base;
using BHoM.Global;
using BHoM.Structural.Loads;
using BHoM.Structural.Results;
using BHoM.Structural.Elements;
using BHoM.Base.Results;
using System.Xml;
using Newtonsoft.Json.Linq;
using BHoM.Structural.Databases;
using BHoM.Base.Data;

namespace BHoMTest
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; }
        public Database(string name) { Name = name; Tables = new List<Table>(); }
    }

    public class Table
    {
        public string Name { get; set; }
        public List<IDataRow> Rows { get; set; }
        public Table(string name, List<IDataRow> rows) { Name = name; Rows = rows; }
    }

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
          // var mat =   BHoM.Materials.Material.Default(BHoM.Materials.MaterialType.Steel);
           //CreateJSONDB();
            TestReadJsonDB();
        }

        private static void TestReadJsonDB()
        {
            JsonFileDB<CableSectionRow> section = new JsonFileDB<CableSectionRow>(BHoM.Base.Data.Database.Cables);
            section.TableName = "PfeiferFullLocked";
            CableSectionRow r = section.GetDataRow<CableSectionRow>("Diameter", "0.12");

        }

        public static void CreateJSONDB()
        {
            Database b = new Database("Cables");
            SQLAccessor<CableSectionRow> sql = new SQLAccessor<CableSectionRow>(BHoM.Base.Data.Database.Cables, "PfeiferFullLocked");
            foreach (string table in sql.TableNames())
            {
                if (table != "PfeiferFullLocked")
                    continue;
                sql.TableName = table;
                List<IDataRow> rows = sql.Query("SELECT * FROM " + table).ToList<IDataRow>();
                Table t = new Table(table, rows);
                b.Tables.Add(t);
            }


            string json = JSONWriter.Write(b);
            using (StreamWriter fs = new StreamWriter(@"C:\Users\inaslund\Documents\GitHub\Cables.txt"))
            {
                fs.Write(json);
                fs.Close();
            }
        }

        public static void BrepJoin()
        {
            List<Point> p1 = new List<Point>();
            p1.Add(new Point(0, 0, 0));
            p1.Add(new Point(10, 0, 0));
            p1.Add(new Point(10, 10, 0));
            p1.Add(new Point(0, 10, 0));
            p1.Add(new Point(0, 0, 0));

            Polyline pl = new Polyline(p1);

            List<Point> p2 = new List<Point>();
            p2.Add(new Point(10, 1, 0));
            p2.Add(new Point(10, 9, 0));
            p2.Add(new Point(20, 9, 0));
            p2.Add(new Point(20, 1, 0));
            p2.Add(new Point(10, 1, 0));

            Polyline pl2 = new Polyline(p2);

           Surface s1= Surface.CreateFromBoundary(pl);
            Surface s2 = Surface.CreateFromBoundary(pl2);

            Brep.Join(new List<Brep>() { s1, s2 });

        
        
            //TestWriteJson();
            TestDesignElementCreation();
            Console.Read();
            
        }



        private static void TestDesignElementCreation()
        {
            Point p1, p2, p3, p4, p5, p6, p7;
            p1 = new Point(0, 0, 0);
            p2 = new Point(0, 1, 0);
            p3 = new Point(0, 2, 0);
            p4 = new Point(0, 3, 0);
            p5 = new Point(0, 4, 0);
            p6 = new Point(0, 5, 0);
            p7 = new Point(0, 6, 0);


            Bar b1 = new Bar(p1, p2);
            Bar b2 = new Bar(p3, p2);
            Bar b3 = new Bar(p3, p4);
            Bar b4 = new Bar(p5, p4);
            Bar b5 = new Bar(p5, p6);
            Bar b6 = new Bar(p6, p7);

            DesignElement elem = new DesignElement(new Bar[] { b1, b2, b3, b4, b5, b6 });

            List<double> majSupPos = (new double[] { 0, 3, 5 }).ToList();
            List<double> minSupPos = (new double[] { 0, 2, 4, 6 }).ToList();

            elem.GenerateSpans(majSupPos, SpanDirection.MajorAxis, true);
            elem.GenerateSpans(minSupPos, SpanDirection.MinorAndLateralTorsional, true);

            //elem.GetSpanCombinations();
            //Beam beam = new Beam();
            //beam.AddBars(new Bar[] { b3, b1, b4, b2});
        }



        public static void TestWriteJson()
        {


            /**********************************/

            Line line = new Line(new Point(1, 2, 3), new Point(3, 4, 5));
            string json = JSONWriter.Write(line);
            Console.WriteLine(json);

            var item = JsonReader.ReadObject(json);

            /**********************************/

            Bar bar = new Bar(new Point(0, 0, 0), new Point(1, 2, 3));
            bar.SectionProperty = new SteelSection(ShapeType.Circle, 200, 200, 1, 1, 1, 1);
            bar.SectionProperty.Material = new BHoM.Materials.Material("TestMaterial");

            string json1 = JSONWriter.Write(bar);
            Console.WriteLine(json1);

            var item1 = JsonReader.ReadObject(json1);

            /**********************************/

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["A"] = 1;
            dic["B"] = new int[] { 2, 3, 4 };
            dic["C"] = new List<string> { "X", "Y", "Z" };
            dic["D"] = @"\\srv\Project\stuff.file";

            string json2 = JSONWriter.Write(dic);
            Console.WriteLine(json2);

            var item2 = JsonReader.ReadObject(json2);

            /**********************************/

            string json3 = "{\"A\":[1,2,3], \"B\":2}";
            var item3 = JsonReader.ReadObject(json3);
        }
        

        static void TestProject()
        {
            List<BHoMObject> collection = new List<BHoMObject>();

            // Add a panel
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0, 0));
            points.Add(new Point(0, 1, 0));
            points.Add(new Point(1, 1, 0));
            points.Add(new Point(0, 0, 0));

            BHoM.Geometry.Group<Curve> edges = new BHoM.Geometry.Group<Curve>();
            for (int i = 1; i < points.Count; i++)
                edges.Add(new Line(points[i - 1], points[i]));

            Panel panel = new Panel(edges);
            panel.PanelProperty = new ConstantThickness("test", 0.25, PanelType.Slab);
            collection.Add(panel);

            // Add a bar
            Node startNode = new Node(1, 2, 3, "N1");
            Node endNode = new Node(4,5,6, "N2");
            Bar bar = new Bar(startNode, endNode, "testBar");
            collection.Add(bar);

            string json = BHoMJSON.WritePackage(collection);

            List<BHoMObject> objects = BHoMJSON.ReadPackage(json);
        }

        static void TestJSON2()
        {

            string json = "{\"Type\":\"BHoM.Structural.Panel\",\"Primitive\":\"BHoM.Structural.Panel; BHoM; Version=1.0.0.0; Culture=neutral; PublicKeyToken=null\",\"Properties\":{\"Edges\":{\"Primitive\":\"group\",\"groupType\":\"BHoM.Geometry.Curve\",\"group\":[{\"Primitive\":\"line\",\"start\":[18.5527278433439,0.647867078636319,45.315],\"end\":[20.9634789624637,-2.40652705182553,45.315]},{\"Primitive\":\"line\",\"start\":[20.9634789624637,-2.40652705182553,45.315],\"end\":[19.8252869247859,-3.30487140799036,45.315]},{\"Primitive\":\"line\",\"start\":[19.8252869247859,-3.30487140799036,45.315],\"end\":[21.4405330528925,-5.3513698017116,45.315]},{\"Primitive\":\"line\",\"start\":[21.4405330528925,-5.3513698017116,45.315],\"end\":[15.9309504513109,-9.69993513261395,45.315]},{\"Primitive\":\"line\",\"start\":[15.9309504513109,-9.69993513261395,45.315],\"end\":[20.4193086231399,-15.3866336668278,45.315]},{\"Primitive\":\"line\",\"start\":[20.4193086231399,-15.3866336668278,45.315],\"end\":[15.4786819336972,-19.286137402097,45.315]},{\"Primitive\":\"line\",\"start\":[15.4786819336972,-19.286137402097,45.315],\"end\":[21.6090839034293,-27.0532866715617,45.315]},{\"Primitive\":\"line\",\"start\":[21.6090839034293,-27.0532866715617,45.315],\"end\":[59.5345962173439,2.880299941271,45.315]},{\"Primitive\":\"line\",\"start\":[59.5345962173439,2.880299941271,45.315],\"end\":[48.9158845088935,16.3339070306786,45.315]},{\"Primitive\":\"line\",\"start\":[48.9158845088935,16.3339070306786,45.315],\"end\":[41.1255022473884,10.1851678853345,45.315]},{\"Primitive\":\"line\",\"start\":[41.1255022473884,10.1851678853345,45.315],\"end\":[42.0238466035529,9.04697584765641,45.315]},{\"Primitive\":\"line\",\"start\":[42.0238466035529,9.04697584765641,45.315],\"end\":[38.9695268966916,6.6362834690844,45.315]},{\"Primitive\":\"line\",\"start\":[38.9695268966916,6.6362834690844,45.315],\"end\":[38.0711825405269,7.77447550676216,45.315]},{\"Primitive\":\"line\",\"start\":[38.0711825405269,7.77447550676216,45.315],\"end\":[34.1219325940382,4.65743876509753,45.315]},{\"Primitive\":\"line\",\"start\":[34.1219325940382,4.65743876509753,45.315],\"end\":[31.8110184936057,7.58533602506226,45.315]},{\"Primitive\":\"line\",\"start\":[31.8110184936057,7.58533602506226,45.315],\"end\":[30.9194973068434,6.88168233568717,45.315]},{\"Primitive\":\"line\",\"start\":[30.9194973068434,6.88168233568717,45.315],\"end\":[27.9084980181773,10.696584040468,45.315]},{\"Primitive\":\"line\",\"start\":[27.9084980181773,10.696584040468,45.315],\"end\":[29.1330345821453,11.6630778084287,45.315]},{\"Primitive\":\"line\",\"start\":[29.1330345821453,11.6630778084287,45.315],\"end\":[24.5676327138692,17.4473809195925,45.315]},{\"Primitive\":\"line\",\"start\":[24.5676327138692,17.4473809195925,45.315],\"end\":[-41.5581049985984,17.4473809195925,45.315]},{\"Primitive\":\"line\",\"start\":[-41.5581049985984,17.4473809195925,45.315],\"end\":[-41.5581049985984,-17.5602601367444,45.315]},{\"Primitive\":\"line\",\"start\":[-41.5581049985984,-17.5602601367444,45.315],\"end\":[-24.4580312812881,-17.5602601367444,45.315]},{\"Primitive\":\"line\",\"start\":[-24.4580312812881,-17.5602601367444,45.315],\"end\":[-24.4580312812881,-0.212562545568443,45.315]},{\"Primitive\":\"line\",\"start\":[-24.4580312812881,-0.212562545568443,45.315],\"end\":[17.4625733379682,-0.212562545568443,45.315]},{\"Primitive\":\"line\",\"start\":[17.4625733379682,-0.212562545568443,45.315],\"end\":[18.5527278433439,0.647867078636319,45.315]}]},\"ThicknessProperty\":\"55f3838c-79ec-41ca-a934-d0b6e52cd834\",\"BHoM_Guid\":\"9dff7ffc-3f19-4956-b5f8-ced406a083a6\",\"CustomData\":{\"RevitId\":827391}}}";
            var obj = BHoMObject.FromJSON(json, Project.ActiveProject);
        }

        static void TestBarNodes()
        {
            Point p1 = new Point(1, 1, 1);
            Point p2 = new Point(2, 2, 1);
            Node n1 = new Node(p1);
            Node n2 = new Node(p2);

            Bar b = new Bar(p1, p2);
            b.StartNode = null;
        }


        static void TestWrite()
        {
            Node n1 = new Node(1, 1, 1);
            n1.CustomData.Add("Number", 1);

            Project project = Project.ActiveProject;
            Project.ActiveProject.AddObject(new Node(1, 1, 1));

            ObjectManager<int, Node> nodes = new ObjectManager<int, Node>(project, "Number", FilterOption.UserData);
            int num = nodes.GetUniqueNumber();
            nodes.Add(2, new Node(0, 0, 0));
            ObjectManager<int, Bar> bars = new ObjectManager<int, Bar>(project, "Number", FilterOption.UserData);

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
            ResultServer<BarForce<int, string, int>> results = new ResultServer<BarForce<int, string, int>>();// Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test1.mdf"));

            List<BarForce<int, string, int>> resultsList = new List<BarForce<int, string, int>>();
            Random r = new Random();
            List<string> barNums = new List<string>();
            List<string> cases = new List<string>();
            int counter = 0;
            int tolalCount = 0;
            results.ClearData();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int j = 0; j < 5/*loadCase.Length*/; j++)
            {
                for (int timeStep = 1; timeStep < 5; timeStep++)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        for (int segment = 0; segment < 3; segment++)
                        {
                            resultsList.Add(new BarForce<int, string, int>((i + 1), j.ToString(), segment, 3, timeStep, (double)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20, (float)r.NextDouble() * 20));
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
            List<BarForce<int, string, int>> barForce1 = results.ToList();


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

        public static void TestReflection()
        {
            TestClass c = new TestClass();
            System.Reflection.FieldInfo[] fInfo = c.GetType().GetFields();
            
        }



        public void ConvertData(string fileName)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(fileName);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                switch (node.Name)
                {
                    case "STEEL_ANGLE":

                        break;
                    case "STEEL_BOX":
                        break;
                    case "STEEL_CHANNEL":
                        break;
                    case "STEEL_DOUBLE_ANGLE":
                        break;
                    case "STEEL_I_SECTION":
                        break;
                        case "STEEL_PIPE":
                        break;
                    case "STEEL_TEE":
                        break;

                }

            }


        }




    }

    public class TestClass : BHoMObject
    {
        private int i;
        public string s;

        public int Int { get; set; }

    }
}
