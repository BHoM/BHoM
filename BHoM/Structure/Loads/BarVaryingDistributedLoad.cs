using BH.oM.Structural.Elements;
using BH.oM.Geometry;

namespace BH.oM.Structural.Loads
{
    public class BarVaryingDistributedLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; } = 0;

        public Vector ForceA { get; set; } = new Vector();

        public Vector MomentA { get; set; } = new Vector();

        public double DistanceFromB { get; set; } = 0;

        public Vector ForceB { get; set; } = new Vector();

        public Vector MomentB { get; set; } = new Vector();


        /***************************************************/
    }
}
