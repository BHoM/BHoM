using System.Collections.Generic;

namespace BH.oM.Geometry
{
    [Serializable]
    public class PolyCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
    }
}

