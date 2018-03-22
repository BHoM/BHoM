using BH.oM.Base;

namespace BH.oM.Structural.Properties
{
    public class LoadingPanelProperty : BHoMObject, IProperty2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadPanelSupportConditions LoadApplication { get; set; } = LoadPanelSupportConditions.AllSides;

        public int ReferenceEdge { get; set; } = 1;


        /***************************************************/
    }
}
