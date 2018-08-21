using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;


namespace BH.oM.Structure.Elements
{
    public class Opening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Edge> Edges { get; set; } = new List<Edge>();


        /***************************************************/
    }
}

