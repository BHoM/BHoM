using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
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
