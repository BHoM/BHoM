using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Loads
{
    public class GravityLoad : Load<BHoMObject>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector GravityDirection { get; set; } = new Vector { X = 0, Y = 0, Z = -1 };


        /***************************************************/
    }
}
