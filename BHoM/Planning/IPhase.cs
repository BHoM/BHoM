using System;

namespace BH.oM.Planning
{
    /// <summary>
    /// Phase interface class, holds interface properties for all objects that use phases
    /// </summary>
    public interface IPhase
    {
        string Name { get; set; }

        int Number { get; set; }

        TimeSpan Duration { get; set; }

        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }

     }
}
