using BH.oM.Base;

namespace BH.oM.Geometry
{
    public class IntegrationSlice : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Width { get; set; } = 0;

        public double Length { get; set; } = 0;

        public double Centre { get; set; } = 0;

        public double[] Placement { get; set; } = new double[0];


        /***************************************************/
    }
}
