using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Environmental.Elements_Legacy
{
    public class Opening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Polyline Contour { get; set; } = new Polyline();


        /***************************************************/
    }

}