using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
{
    public class AreaTemperatureLoad : Load<IAreaElement>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double TemperatureChange { get; set; } = 0;


        /***************************************************/
    }
}
