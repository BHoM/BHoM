using System.Collections.Generic;
using BH.oM.Structure.Properties;

namespace BH.oM.Structure.Elements
{
    public class FEMeshFace : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> NodeListPositions { get; set; } = new List<int>();      

        /***************************************************/
    }
}
     
