using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class PointDisplacement : Load<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Translation { get; set; }

        public Vector Rotation { get; set; }

        public int RobotLoadRecordNumber { get; private set; }  //TODO: Remove this


        /***************************************************/
    }
}
