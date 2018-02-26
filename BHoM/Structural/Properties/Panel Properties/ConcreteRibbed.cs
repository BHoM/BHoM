namespace BH.oM.Structural.Properties
{
    public class Ribbed : Property2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PanelDirection Direction { get; set; } // TODO: Define default values

        public double TotalDepth { get; set; }

        public double StemWidth { get; set; }

        public double Spacing { get; set; }


        /***************************************************/
    }
}
