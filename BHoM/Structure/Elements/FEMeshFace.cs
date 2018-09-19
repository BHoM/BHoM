using System.Collections.Generic;
using BH.oM.Structure.Properties;

namespace BH.oM.Structure.Elements
{
    public class FEMeshFace : Base.BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<int> NodeListPositions { get; set; } = new List<int>();
        
        public IProperty2D Property { get; set; } = new ConstantThickness();
        

        /***************************************************/
    }
}
     
