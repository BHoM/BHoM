using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structure.Properties.Surface
{
    public class LoadingPanelProperty : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadPanelSupportConditions LoadApplication { get; set; } = LoadPanelSupportConditions.AllSides;

        public int ReferenceEdge { get; set; } = 1;

        public Material Material { get; set; }

        /***************************************************/
    }
}
