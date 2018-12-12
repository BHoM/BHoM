using BH.oM.Structure.Elements;
using BH.oM.Geometry;

namespace BH.oM.Structure.Loads
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
