using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class PointVelocity : Load<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector TranslationalVelocity { get; set; }

        public Vector RotationalVelocity { get; set; }

        public int RobotLoadRecordNumber { get; private set; }  //TODO: Remove this


        /***************************************************/
    }
}
