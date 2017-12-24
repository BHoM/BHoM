using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    public class BarPrestressLoad : Load<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double PrestressValue { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public BarPrestressLoad() { }


        /***************************************************/
        /**** ILoad Interface                           ****/
        /***************************************************/

        public override LoadType GetLoadType()
        {
            return LoadType.Pressure;
        }

    }
}
