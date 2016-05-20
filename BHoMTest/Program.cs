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

namespace BHoMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
            for (int i = 0; i < 10000; i++)
            {
                nodes.Add((i+1).ToString(), new Node(i, i, i));
            }

            for (int i = 0; i < 10000 - 1; i++)
            {
                bars.Add((i + 1).ToString(), new Bar(nodes[(i + 1).ToString()], nodes[(i + 2).ToString()]));
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
           

            Console.WriteLine("Node {0} is located at {1}", 4, nodes[4.ToString()].Point.ToString());
            
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
