using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
{
    public class PointDisplacement : Load<Node>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Translation { get; set; } = new Vector();

        public Vector Rotation { get; set; } = new Vector();

        /***************************************************/
    }
}
