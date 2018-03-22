using BH.oM.Base;
using BH.oM.Common.Materials;


namespace BH.oM.Structural.Properties
{
    public class Waffle : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double[] Modifiers { get; set; } = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        public double Thickness { get; set; }

        public Material Material { get; set; }

        public double TotalDepthX { get; set; }

        public double TotalDepthY { get; set; }

        public double StemWidthX { get; set; }

        public double StemWidthY { get; set; }

        public double SpacingX { get; set; }

        public double SpacingY { get; set; }


        /***************************************************/
    }
}
