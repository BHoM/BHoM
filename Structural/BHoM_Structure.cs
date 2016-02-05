using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    [Serializable]
    public class Structure
    {
        public List<Node> Nodes { get; private set; }
        public List<Bar> Bars { get; private set; }
        public List<Face> Faces { get; private set; }
        public Dictionary<string, BHoM.Structural.Constraint> Constraints {get; private set;}
        public Dictionary<int, Storey> Storeys { get; private set; }
        public double WindBaseShearX { get; private set; }
        public double WindBaseShearY { get; private set; }
        public double SeismicBaseShearX { get; private set; }
        public double SeismicBaseShearY { get; private set; }
                

        public List<SectionProperty> SectionProperties { get;  private set; }
        
        public double Tolerance { get; private set; }

        public Structure()
        {
            Nodes = new List<Node>();
            Bars = new List<Bar>();
            Faces = new List<Face>();
            Constraints = new Dictionary<string, Constraint>();
        }
 
      
        /// <summary>
        /// Adds a node in the structure. Private
        /// TODO: implement index clash checks
        /// </summary>
        /// <param name="node">The node to add</param>
        private void AddNode(Node node)
        {
            if (NodeNumberClash(node) || !node.HasValidNumber())
                node.SetNumber(FindMaxNodeNumber() + 1);
            Nodes.Add(node);
        }


        /// <summary>
        /// Adds node to structure and returns. If within tolerance with preexisting node original node will be returned instead
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Node AddOrGetNode(Node n)
        {
            foreach (Node n1 in Nodes)
                if (Math.Abs(n1.X - n.X) < Tolerance && Math.Abs(n1.Y - n.Y) < Tolerance && Math.Abs(n1.Z - n.Z) < Tolerance)
                    return n1;
            AddNode(n);
            return n;
        }

        /// <summary>
        /// Adds a beam in the structure. First checks uniqueness of end nodes with preexisting nodes in structure.
        /// This is based on set tolerance of Structure, merging as appropriate
        /// </summary>
        /// <param name="element">The element to add</param>
        public void AddBar(Bar b)
        {
            b.SetStartNode(AddOrGetNode(b.StartNode));
            b.SetEndNode(AddOrGetNode(b.EndNode));

            if (BarNumberClash(b) || !b.HasValidNumber())
                b.SetNumber(FindMaxBarNumber() + 1);

            Bars.Add(b);
        }


        public bool NodeNumberClash(Node n)
        {
            return (Nodes.FindIndex(x => x.Number == n.Number) != -1);
        }

        public bool BarNumberClash(Bar b)
        {
            return (Bars.FindIndex(x => x.Number == b.Number) != -1);
        }

        public bool FaceNumberClash(Face f)
        {
            return (Faces.FindIndex(x => x.Number == f.Number) != -1);
        }


        public int FindMaxNodeNumber()
        {
            if(Nodes.Count > 0 )
                return Nodes.Max(x => x.Number);
            return 0;
        }

        public int FindMaxBarNumber()
        { 
            if (Bars.Count > 0)
                return Bars.Max(x => x.Number);
            return 0;
        }

        public int FindMaxFaceNumber()
        {
            if (Faces.Count > 0)
                return Faces.Max(x => x.Number);
            return 0;
        }


        private void SetTopology()
        {
            foreach (Node n in Nodes)
                n.ResetTopology();

            foreach(Bar b in Bars)
            {
                ////lace up topology
                b.StartNode.AddBar(b);
                b.EndNode.AddBar(b);
            }

            foreach(Face f in Faces)
            {


            }

        }

        public Node GetNodeByNumber(int n)
        {
            return Nodes.Find(delegate(Node node) { return node.Number == n; });
        }

        public Bar GetBarByNumber(int n)
        {
            return Bars.Find(delegate(Bar bar) { return bar.Number == n; });
        }

        public Face GetFaceByNumber(int n)
        {
            return Faces.Find(delegate(Face face) { return face.Number == n; });
        }



        /// <summary>
        /// Calculates the counter clockwise Oring for each node  
        /// </summary>
        /// <returns>True if succeded</returns>
        public bool SortNodalBars()
        {
            foreach (Node n in Nodes)
            {
                n.SetCoordinateSystemAsDefault();
                n.SortConnectedBars();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SortNodalFaces()
        {
            return false;
        }


        /// <summary>
        /// WIP - currently duplicates faces. also does not control winding. 
        /// Create face from bars by looping through the bars and trying to find closed edge loops - defining face.
        /// First tries to create a triangular panel, if not, quad - aborts after.
        /// Concave quads are excluded (angles greater than 180 between bars)
        /// Creation of five sided and above are not supported
        /// Assumes nodal bar lists are already sorted correctly anticlockwise
        /// Also assumes a manifold topology - i.e. suited to meshed slabs and gridshells - and not spaceframes etc.
        /// </summary>
        /// <returns></returns>
        public bool CreateFacesFromBars()
        {
            if (Nodes.Count < 3) { return false; }
            if (Bars.Count < 3) { return false; }

            SetTopology();

            SortNodalBars();

            foreach (Node n0 in Nodes)
            {
                if (n0.Valence < 2) continue;

                //Assumes bars are sorted in counter clockwise order
                List<Bar> sortedBars = n0.ConnectedBars;

                for (int i = 0; i < sortedBars.Count; i++)
                {

                    //get pair of adjacent bars - iPlus1 wraps round to 0 when count is met
                    int iPlus1 = (i + 1) % sortedBars.Count;

                    if (n0.Angles[i] > 180) break; // not creating convex faces

                    Bar b0 = sortedBars[i];
                    Bar b1 = sortedBars[iPlus1];

                    //get the two nodes at the other two ends.
                    Node n1 = b0.GetOtherEnd(n0);
                    Node n2 = b1.GetOtherEnd(n0);


                    //Check to see if a bar connecting to node1 also connects to node2 
                    Bar b2 = FindBarWithCommonNodeInBarList(n1.ConnectedBars, n2);
                    if (b2 != null) //i.e. bar3 was found and Triangular Face exists
                    {
                        //create tri face;
                        Face face = new Face(n0, n1, n2);
                        face.Edges.Add(b0);
                        face.Edges.Add(b1);
                        face.Edges.Add(b2);
                        Faces.Add(face); //TODO: check for uniqueness

                    }
                    else
                    //Check to see if a quad exists
                    {
                        Bar b3;
                        Node n3;
                        if (FindBarPairWithCommonNodeInBarLists(n1.ConnectedBars, n2.ConnectedBars, n1, n2, n0, out b2, out b3, out n3))
                        {
                            //create quad face
                            Face face = new Face(n0, n1, n3, n2); //create in anticlockwise order
                            if (CheckFaceUniquenessBySortedNodeNumbers(face))
                            {
                                face.Edges.Add(b0);
                                face.Edges.Add(b1);
                                face.Edges.Add(b2);
                                face.Edges.Add(b3);
                                n0.AddFace(face);
                                face.Number = Faces.Count + 1;
                                Faces.Add(face);
                            }
                        }

                    }

                }

            }

            return true;
        }

        /// <summary>
        /// WIP TODO: check efficiency
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private bool CheckFaceUniquenessBySortedNodeNumbers(Face f)
        {
            List<int> fnum0 = new List<int>(new int[] { f.Nodes[0].Number, f.Nodes[1].Number, f.Nodes[2].Number, f.Nodes[3].Number });
            fnum0.Sort();

            foreach (Face face in Faces)
            {
                List<int> fnum1 = new List<int>(new int[] { face.Nodes[0].Number, face.Nodes[1].Number, face.Nodes[2].Number, face.Nodes[3].Number });
                fnum1.Sort();

                if (fnum1.SequenceEqual(fnum0)) return false;
            }

            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="bars"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static Bar FindBarWithCommonNodeInBarList(List<Bar> bars, Node node)
        {
            int number = node.Number;
            foreach (Bar bar in bars)
            {
                if (bar.StartNode.Number == number) return bar;
                if (bar.EndNode.Number == number) return bar;
            }

            return null;
        }


        private static bool FindBarPairWithCommonNodeInBarLists(List<Bar> bars0, List<Bar> bars1, Node node0, Node node1, Node nExclude, out Bar bar2, out Bar bar3, out Node node3)
        {

            double numExclude = nExclude.Number;

            foreach (Bar bar0 in bars0)
            {
                node3 = bar0.GetOtherEnd(node0);
                int number = node3.Number;

                if (number == numExclude) continue;

                foreach (Bar bar1 in bars1)
                {
                    if (bar1.GetOtherEnd(node1).Number == number)
                    {
                        bar2 = bar0;
                        bar3 = bar1;
                        return true;
                    }

                }

            }

            bar2 = null;
            bar3 = null;
            node3 = null;
            return false;
        }


        public Face FindNearestFace(BHoM.Geometry.Point p)
        {
            double minD = Faces.Min(face => face.DistanceTo(p));

            foreach (Face face in Faces)
                if (face.DistanceTo(p) == minD) return face;

            return null;

        }



        /// <summary>
        /// Sets the internal tolerance for which structural node merging etc. will be performed
        /// </summary>
        /// <param name="tol"></param>
        public void SetTolerance(double tol)
        {
            Tolerance = tol;
        }


        public BHoM.Structural.Constraint SetConstraint(BHoM.Structural.Constraint constraint)
        {
            if (this.Constraints.ContainsKey(constraint.Name))
            {
                return this.Constraints[constraint.Name];
            }
            else
            {
                this.Constraints.Add(constraint.Name, constraint);
                return constraint;
            }
        }

    }
}
