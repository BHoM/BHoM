using BH.oM.Structural.Elements;

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

        public BH.oM.Geometry.Vector Pressure { get; set; }  //TODO: Provide default values


        /***************************************************/
    }
}
