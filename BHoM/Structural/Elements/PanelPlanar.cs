using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM panel class - a planar surface object with a list of 'edges' (curves with properties) for both external and internal edges (openings)
    /// </summary>
    [Serializable]
    public class PanelPlanar : BH.oM.Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Edge> InternalEdges = new List<Edge>();
        public List<Edge> ExternalEdges = new List<Edge>();
        public Property2D Property { get; set; } = new ConstantThickness();      

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty panel
        /// </summary>
        public PanelPlanar() { }
   
        /***************************************************/   

    }
}
       