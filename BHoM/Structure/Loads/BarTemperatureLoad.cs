using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class BarTemperatureLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double TemperatureChange { get; set; } = 0;

        /***************************************************/
    }
}
