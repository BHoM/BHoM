using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    [Serializable]
    public class Face
    {
        public int Number { get; set; }
        public int Group { get; set; }
        public string Name { get; set; }

        public List<Node> Nodes { get; private set; }
        public List<Bar> Edges { get; private set; }
        public List<Face> Neighbours { get; private set; }

        public Face()
        {
            Number = -1;
            Group = -1;
            Name = "";
            Nodes = new List<Node>();
            Edges = new List<Bar>();
            Neighbours = new List<Face>();
        }


        public Face(Node n0, Node n1, Node n2) 
            : this()
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);
        }


        public Face(Node n0, Node n1, Node n2, Node n3)
            : this()
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);
            Nodes.Add(n3);
        }

        public BHoM.Geometry.Point CalculateCentroid()
        {
            List<BHoM.Geometry.Point> pts = new List<BHoM.Geometry.Point>(4);

            foreach (Node n in Nodes)
                pts.Add(n.Position);

            return BHoM.Geometry.Point.Average(pts);
        }

        public double DistanceTo(BHoM.Geometry.Point p)
        {
            return this.CalculateCentroid().DistanceTo(p);
        }
    }

}
