using System.Collections.Generic;
using BH.oM.Structure.Properties;

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
