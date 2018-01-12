using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class BarPrestressLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Prestress { get; set; }  //TODO: Provide default values


        /***************************************************/
    }
}
