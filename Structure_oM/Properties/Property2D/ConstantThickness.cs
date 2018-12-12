using BH.oM.Base;
using BH.oM.Common.Materials;


namespace BH.oM.Structure.Properties.Surface
{
    public class ConstantThickness : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Thickness { get; set; }

        public Material Material { get; set; }

        public PanelType PanelType { get; set; } = PanelType.Slab;  //TODO: Required to get Etabs working. To be moved to physical objects

        /***************************************************/
    }
}
