using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
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
