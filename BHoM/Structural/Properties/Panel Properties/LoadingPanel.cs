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

    [Serializable]
    public class LoadingPanelProperty : Property2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public LoadPanelSupportConditions LoadApplication { get; set; }

        public int ReferenceEdge { get; set; } = 1;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LoadingPanelProperty() { }
    }
}
