using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM Face class
    /// </summary>
    [Serializable]
    public class PanelFace : BH.oM.Base.BHoMObject
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
        public List<PanelFace> Neighbours { get; set; } = new List<PanelFace>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty face
        /// </summary>
        public PanelFace() { }

        /***************************************************/

        /// <summary>
        /// Constructs a 3 sided face with 3 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public PanelFace(Node n0, Node n1, Node n2, Node n3 = null)
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);

            if (n3 != null)
                Nodes.Add(n3);
        }

    }
}
        //TODO: Do we really need this?
        ///// <summary>Get the distance to the centroid from point p</summary>
        //public double DistanceTo(BH.oM.Geometry.Point p)
        //{
        //    return this.CalculateCentroid().DistanceTo(p);
        //}

//    }

//}
