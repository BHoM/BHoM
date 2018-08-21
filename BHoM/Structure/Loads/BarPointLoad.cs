using BH.oM.Structural.Elements;
using BH.oM.Geometry;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : Load<Bar>  //Bar point load object - different to nodal or point load as it needs a 'position' variable
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double DistanceFromA { get; set; } = 0;

        public Vector Force { get; set; } = new Vector();

        public Vector Moment { get; set; } = new Vector();


        /***************************************************/
    }
}
