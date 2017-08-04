using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BHoM Face class
    /// </summary>
    [Serializable]
    public class Face : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>Face number</summary>
        public int Number { get; set; } = -1;

        /// <summary>Group number</summary>
        public int Group { get; set; } = -1;

        /// <summary>Face nodes</summary>
        public List<Node> Nodes { get; set; } = new List<Node>();

        /// <summary>Face edges</summary>
        public List<Bar> Edges { get; set; } = new List<Bar>();

        /// <summary>Face neighbors</summary>
        public List<Face> Neighbours { get; set; } = new List<Face>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty face
        /// </summary>
        public Face() { }

        /***************************************************/

        /// <summary>
        /// Constructs a 3 sided face with 3 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public Face(Node n0, Node n1, Node n2, Node n3 = null)
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);

            if (n3 != null)
                Nodes.Add(n3);
        }

    }
}
      





        ///// <summary>Calculates the centroid of the face</summary>
        //public BH.oM.Geometry.Point CalculateCentroid()
        //{
        //    List<BH.oM.Geometry.Point> pts = new List<BH.oM.Geometry.Point>(4);

        //    foreach (Node n in Nodes)
        //        pts.Add(n.Point);

        //    return BH.oM.Geometry.Point.Average(pts);
        //}

        ///// <summary>Get the distance to the centroid from point p</summary>
        //public double DistanceTo(BH.oM.Geometry.Point p)
        //{
        //    return this.CalculateCentroid().DistanceTo(p);
        //}

//    }

//}
