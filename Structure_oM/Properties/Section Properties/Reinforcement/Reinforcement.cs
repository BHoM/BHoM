using BH.oM.Base;
using BH.oM.Common.Materials;

namespace BH.oM.Structure.Properties.Section.Reinforcement
{
    public abstract class Reinforcement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Diameter { get; set; }

        public int BarCount { get; set; }

        public Material Material { get; set; }

        public double StartLocation { get; set; } = 0;  // location of the beginning of the reinforcement as a ratio of the bar length

        public double EndLocation { get; set; } = 1; // location of the end of the reinforcement as a ratio of the bar length


        /***************************************************/
    }
}
