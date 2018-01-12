using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Architecture.Elements
{
    public class Grid : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
    }
}
