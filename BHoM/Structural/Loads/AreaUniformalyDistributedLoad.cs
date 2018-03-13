using BH.oM.Structural.Elements;
using BH.oM.Geometry;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Uniformly distributed area load
    /// </summary>
    public class AreaUniformalyDistributedLoad : Load<IAreaElement>  
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Pressure { get; set; } = new Vector();


        /***************************************************/
    }
}
