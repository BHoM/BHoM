using BH.oM.Base;
using BH.oM.Common;
using System.Collections.Generic;

namespace BH.oM.Structure.Elements
{
    public class Opening : BHoMObject, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Edge> Edges { get; set; } = new List<Edge>();
        
        /***************************************************/
    }
}

