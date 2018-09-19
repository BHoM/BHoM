using System.Collections.Generic;
using BH.oM.Structure.Properties;

namespace BH.oM.Structure.Elements
{
    public class FEMesh : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Node> Nodes { get; set; } = new List<Node>();

        public List<FEMeshFace> MeshFaces { get; set; } = new List<FEMeshFace>();

        /***************************************************/
    }
}
