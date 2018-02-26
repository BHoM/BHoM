using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class PolyCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
    }
}   

