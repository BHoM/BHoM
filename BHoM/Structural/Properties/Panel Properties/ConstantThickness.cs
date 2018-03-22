using BH.oM.Base;
using BH.oM.Common.Materials;


namespace BH.oM.Structural.Properties
{
    public class ConstantThickness : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double[] Modifiers { get; set; } = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        public double Thickness { get; set; }

        public Material Material { get; set; }

        /***************************************************/
    }
}
