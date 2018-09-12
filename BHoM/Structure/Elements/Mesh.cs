using System.Collections.Generic;

namespace BH.oM.Structure.Elements
{
    public class Mesh : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<MeshFace> MeshFaces { get; set; } = new List<MeshFace>();

        /***************************************************/
    }
}
     
