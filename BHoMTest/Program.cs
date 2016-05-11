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

namespace BHoMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestWrite();
            //TestRead();
            ObjectCollection<Node> nodes = new ObjectCollection<Node>();
            int num = nodes.UniqueNumber();
            nodes.Add(new Node(0, 0, 0, num));

            PointForce pF = new PointForce(null, 1, 1, 1, 1, 1, 1);
            pF.Objects.Add(nodes[1]);
            string json = pF.ToJSON();

            BHoMObject bO= BHoMObject.FromJSON(json);
        }

        static void TestWrite()
        {
            Project.ActiveProject.AddObject(new Node(1, 1, 1, 1));

            ObjectCollection<Node> nodes = new ObjectCollection<Node>();
            int num = nodes.UniqueNumber();
            nodes.Add(new Node(0, 0, 0, num));
            ObjectCollection<Bar> bars = new ObjectCollection<Bar>();

            Bar b = new Bar(nodes[1], nodes[2], 1);

            bars.Add(b);

            string output = b.ToJSON();

            // Project.ActiveProject.RemoveObject(b.BHoM_Guid);

            //BHoMObject b2 = BHoMObject.FromJSON(output);

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
            Node n = new ObjectCollection<Node>()[1];
        }
    }
}
