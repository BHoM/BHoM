using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;
using System.Linq;


namespace BH.oM.Structural.Elements
{
    public class Opening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Edges { get; set; } = new List<ICurve>();


        /***************************************************/
    }
}

