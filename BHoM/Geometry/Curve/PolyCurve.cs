using System.Collections.Generic;
using System.Linq;

namespace BH.oM.Geometry
{
    public class PolyCurve : ICurve
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<ICurve> Curves { get; set; } = new List<ICurve>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public PolyCurve() { }

        /***************************************************/

        public PolyCurve(IEnumerable<ICurve> curves)
        {
            Curves = curves.ToList();
        }

    }
}   

