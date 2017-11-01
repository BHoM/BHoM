using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SPL : Parameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Sound Pressure level
        /// </summary>
        public override ParameterTypes Name { get; set; } = ParameterTypes.SPL;

        /// <summary>
        /// Sound Level result value in dB
        /// </summary>
        public override double Value { get; set; } = 0;

        /// <summary>
        /// Receiver at SPL calculation
        /// </summary>
        public override int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Speaker origin of SPL calculation
        /// </summary>
        public override int SpeakerID { get; set; } = 0;

        /// <summary>
        /// Frequency of the analysed value
        /// </summary>
        public override Frequency Octave { get; set; } = Octaves.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SPL() { }

        /***************************************************/

        public SPL(double value, int receiverID, int speakerID, Frequency octave)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
            Octave = octave;
        }
    }
}