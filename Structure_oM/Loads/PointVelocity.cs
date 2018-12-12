using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
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
