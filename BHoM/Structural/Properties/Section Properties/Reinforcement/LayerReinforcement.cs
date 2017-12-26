namespace BH.oM.Structural.Properties
{
    [Serializable]
    public class LayerReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Depth { get; set; }

        //[DisplayName("IsVertical")]
        //[Description("Set as vertical reinforcement layer")]
        public bool IsVertical { get; set; } = false;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public LayerReinforcement() { }

        /***************************************************/

        public LayerReinforcement(double diameter, double depth, int count, bool isVertical = false)
        {
            Diameter = diameter;
            BarCount = count;
            Depth = depth;
            IsVertical = isVertical;
        }


        ///***************************************************/
        ///**** Override Reinforcement                    ****/
        ///***************************************************/

        //public override bool IsLongitudinal()
        //{
        //    return true;
        //}

        ///***************************************************/


    }
}
