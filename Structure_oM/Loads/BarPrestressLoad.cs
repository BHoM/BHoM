using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
{
    public class BarPrestressLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Prestress { get; set; } = 0;


        /***************************************************/
    }
}
