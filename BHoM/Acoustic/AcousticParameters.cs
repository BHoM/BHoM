using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{

    public class AcousticParameters
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Frequency spectrum of the acoustic speaker
        /// </summary>
        public List<double> Frequencies { get; set; } = new List<double>();

        /// <summary>
        /// Frequency spectrum of the acoustic speaker
        /// </summary>
        public List<double> Octaves { get; set; } = new List<double>();

        /// <summary>
        /// Reverberation times of the room
        /// </summary>
        public List<double> ReverberationTimes { get; set; } = new List<double>();

        /// <summary>
        /// 
        /// </summary>
        public List<double> NoiseLevels { get; set; } = new List<double>();

        /// <summary>
        /// 
        /// </summary>
        public List<double> Gains { get; set; } = new List<double>();

        /// <summary>
        /// 
        /// </summary>
        public List<double> Speeches { get; set; } = new List<double>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public AcousticParameters() { }

    }
}
