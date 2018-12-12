using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Geometry;

namespace BH.oM.Environment.Elements
{
    public class Opening : BHoMObject, IBuildingObject, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve OpeningCurve { get; set; } = new PolyCurve();

        /***************************************************/
    }
}
