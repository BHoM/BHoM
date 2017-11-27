using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM Mesh face class
    /// </summary>
    [Serializable]
    public class MeshFace : BH.oM.Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>MeshFace nodes</summary>
        public List<Node> Nodes { get; set; } = new List<Node>();
        public PanelProperty PanelProperty { get; set; } = new ConstantThickness();
        

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty mesh face
        /// </summary>
        public MeshFace() { }
   
        /***************************************************/

        /// <summary>
        /// Constructs a 3 sided face with 3 nodes
        /// </summary>
        /// <param name="n0"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public MeshFace(Node n0, Node n1, Node n2, Node n3 = null)
        {
            Nodes.Add(n0);
            Nodes.Add(n1);
            Nodes.Add(n2);

            if (n3 != null)
                Nodes.Add(n3);
        }

    }
}
     
