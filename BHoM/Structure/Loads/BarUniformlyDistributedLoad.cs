using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
{
    public class BarUniformlyDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Force { get; set; } = new Vector();

        public Vector Moment { get; set; } = new Vector();


        /***************************************************/
    }
}
