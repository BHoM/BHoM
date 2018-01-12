using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class BarTemperatureLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Geometry.Vector TemperatureChange { get; set; }  //TODO: Provide default values


        /***************************************************/
    }
}
