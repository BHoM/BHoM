using BH.oM.Geometry;
using System.Collections.Generic;
using BH.oM.Base;

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

