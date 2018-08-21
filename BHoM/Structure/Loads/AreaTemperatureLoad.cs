using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
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
