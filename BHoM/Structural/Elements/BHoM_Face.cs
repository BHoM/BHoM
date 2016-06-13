using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    /// <summary>
    /// BHoM Face class
    /// </summary>
    [Serializable]
    public class Face
    {
        /// <summary>BHoM unique ID</summary>
        public System.Guid BHoM_Guid { get; private set; }

        /// <summary>Face number</summary>
        public int Number { get; set; }
        /// <summary>Group number</summary>
        public int Group { get; set; }
        /// <summary>Face name</summary>
        public string Name { get; set; }

        /// <summary>Face nodes</summary>
        public List<Node> Nodes { get; private set; }
        /// <summary>Face edges</summary>
        public List<Bar> Edges { get; private set; }
        /// <summary>Face neighbors</summary>
        public List<Face> Neighbours { get; private set; }

        /// <summary>
        /// Constructs an empty face
        /// </summary>
        public Face()
        {
            Number = -1;
            Group = -1;
            Name = "";
            Nodes = new List<Node>();
            Edges = new List<Bar>();
            Neighbours = new List<Face>();
        }

        /// <summary>
        /// Constructs a 3 sided face with 3 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public Face(Node n0, Node n1, Node n2) 
            : this()
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);
        }

        /// <summary>
        /// Constructs a 4 sided face with 4 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="n3"></param>
        public Face(Node n0, Node n1, Node n2, Node n3)
            : this()
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);
            Nodes.Add(n3);
        }

        /// <summary>Calculates the centroid of the face</summary>
        public BHoM.Geometry.Point CalculateCentroid()
        {
            List<BHoM.Geometry.Point> pts = new List<BHoM.Geometry.Point>(4);

            foreach (Node n in Nodes)
                pts.Add(n.Point);

            return BHoM.Geometry.Point.Average(pts);
        }

        /// <summary>Get the distance to the centroid from point p</summary>
        public double DistanceTo(BHoM.Geometry.Point p)
        {
            return this.CalculateCentroid().DistanceTo(p);
        }
        
    }

}
