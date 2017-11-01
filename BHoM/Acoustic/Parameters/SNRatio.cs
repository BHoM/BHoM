using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SNRatio : Parameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Rapid Speech Transmission Index
        /// </summary>
        public override ParameterTypes Name { get; set; } = ParameterTypes.SN;

        /// <summary>
        /// STI result between 0 and 1
        /// </summary>
        public override double Value { get; set; } = 0;

        /// <summary>
        /// Receiver at STI calculation
        /// </summary>
        public override int ReceiverID { get; set; } = 0;

        /// <summary>
        /// Frequency of the analysed value
        /// </summary>
        public override Frequency Octave { get; set; } = Octaves.Sum;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SNRatio() { }

        /***************************************************/

        public SNRatio(double value, int receiverID, int speakerID, Frequency octave)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
            Octave = octave;
        }
    }
}