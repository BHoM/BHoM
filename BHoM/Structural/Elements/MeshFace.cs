using System.Collections.Generic;
using BH.oM.Structural.Properties;

namespace BH.oM.Structural.Elements
{
    public class MeshFace : Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Node> Nodes { get; set; } = new List<Node>();

        public IProperty2D Property { get; set; } = new ConstantThickness();
        

        /***************************************************/
    }
}
     
