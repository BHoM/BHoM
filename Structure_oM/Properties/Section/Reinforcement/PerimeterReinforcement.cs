namespace BH.oM.Structure.Properties.Section.Reinforcement
{
    /// <summary>
    /// Perimeter Reinforcement is aimed at columns and is only valid on rectangular and circular sections
    /// </summary>
    public class PerimeterReinforcement : Reinforcement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ReinforcementPattern Pattern { get; set; }


        /***************************************************/
    }
}

