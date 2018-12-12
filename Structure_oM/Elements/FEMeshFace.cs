using System.Collections.Generic;
using BH.oM.Structure.Properties;

namespace BH.oM.Structure.Elements
{
    public class FEMeshFace : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> NodeListIndices { get; set; } = new List<int>();      

        /***************************************************/
    }
}
     
