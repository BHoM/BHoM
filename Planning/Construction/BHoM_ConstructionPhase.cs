using System;

namespace BHoM.Planning.Construction
{
    /// <summary>
    /// Construction phase class for use across all BHoM projects. By default, construction phases should be
    /// added to all objects intended for the construction site, or construction phase modelling
    /// </summary>
    public class ConstructionPhase : IPhase
    {

        /// <summary>
        /// Construction stage duration
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return Duration;
            }
            set
            {
                Duration = value;
            }
        }

        /// <summary>
        /// Construction stage name
        /// </summary>
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        /// <summary>
        /// Construction stage sequential number
        /// </summary>
        public int Number
        {
            get
            {
                return Number;
            }
            set
            {
                Number = value;
            }
        }

        /// <summary>
        /// Construction stage start time
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return StartTime;
            }
            set
            {
                StartTime = value;
            }
        }

        /// <summary>
        /// Construction stage end time
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return EndTime;
            }
            set
            {
                EndTime = value;
            }
        }

    }
}
