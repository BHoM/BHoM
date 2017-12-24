using System;

namespace BH.oM.Planning.Construction
{
    /// <summary>
    /// Construction phase class for use across all BH.oM projects. By default, construction phases should be
    /// added to all objects intended for the construction site, or construction phase modelling
    /// </summary>
    public class ConstructionPhase : IPhase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public TimeSpan Duration { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
