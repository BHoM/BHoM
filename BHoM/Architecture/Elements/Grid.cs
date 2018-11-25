using BH.oM.Base;
using BH.oM.Common;
using BH.oM.Geometry;

namespace BH.oM.Architecture.Elements
{
    public class Grid : BHoMObject, IElement1D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; } = null;


        /***************************************************/
    }
}
