namespace BH.oM.Structural.Properties
{
    public enum LoadPanelSupportConditions
    {
        AllSides,
        ThreeSides,
        TwoSides,
        TwoAdjacentSides,
        OneSide,
        Cantilever
    }

    public class LoadingPanelProperty : Property2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadPanelSupportConditions LoadApplication { get; set; } = LoadPanelSupportConditions.AllSides;

        public int ReferenceEdge { get; set; } = 1;


        /***************************************************/
    }
}
