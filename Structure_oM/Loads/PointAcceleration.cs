using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
{
    public class PointAcceleration : Load<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector TranslationalAcceleration { get; set; } = new Vector();

        public Vector RotationalAcceleration { get; set; } = new Vector();


        /***************************************************/
    }
}
