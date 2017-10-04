using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM Face class
    /// </summary>
    [Serializable]
    public class Panel : BH.oM.Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>Face nodes</summary>
        public List<Node> Nodes { get; set; } = new List<Node>();
        public PanelProperty PanelProperty { get; set; }
        

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty face
        /// </summary>
        public Panel() { }
   
        /***************************************************/

        /// <summary>
        /// Constructs a 3 sided face with 3 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public Panel(Node n0, Node n1, Node n2, Node n3 = null)
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
