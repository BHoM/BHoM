using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class PointVelocity : Load<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector TranslationalVelocity { get; set; } = new Vector();

        public Vector RotationalVelocity { get; set; } = new Vector();


        /***************************************************/
    }
}
