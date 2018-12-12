using BH.oM.Base;
using BH.oM.Common.Materials;


namespace BH.oM.Structure.Properties.Surface
{
    public class Waffle : BHoMObject, ISurfaceProperty
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Thickness { get; set; }

        public Material Material { get; set; }

        public double TotalDepthX { get; set; }

        public double TotalDepthY { get; set; }

        public double StemWidthX { get; set; }

        public double StemWidthY { get; set; }

        public double SpacingX { get; set; }

        public double SpacingY { get; set; }

        public PanelType PanelType { get; set; } = PanelType.Slab;   //TODO: Required to get Etabs working. To be moved to physical objects


        /***************************************************/
    }
}
