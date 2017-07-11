using System;

namespace BH.oM.Planning.Construction
{
    /// <summary>
    /// Construction phase class for use across all BHoM projects. By default, construction phases should be
    /// added to all objects intended for the construction site, or construction phase modelling
    /// </summary>
    public class ConstructionPhase : IPhase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Construction stage duration
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Construction stage name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Construction stage sequential number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Construction stage start time
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Construction stage end time
        /// </summary>
        public DateTime EndTime { get; set; }

    }
}
