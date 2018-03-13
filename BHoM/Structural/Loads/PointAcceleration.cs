using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
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
