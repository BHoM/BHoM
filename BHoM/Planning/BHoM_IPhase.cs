using System;
using System.Collections.Generic;

namespace BHoM.Planning
{
    /// <summary>
    /// Phase interface class, holds interface properties for all objects that use phases
    /// </summary>
    public interface IPhase
    {
        /// <summary>
        /// Name of phase
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Phase sequential number
        /// </summary>
        int Number { get; set; }

        /// <summary>
        /// Phase duration
        /// </summary>
        TimeSpan Duration { get; set; }

        /// <summary>
        /// Phase starting time
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Phase ending time
        /// </summary>
        DateTime EndTime { get; set; }

     }
}
