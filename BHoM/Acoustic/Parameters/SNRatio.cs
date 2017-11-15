using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SNRatio : IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ParameterType Parameter { get; } = ParameterType.SNRATIO;

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;

        public Frequency Frequency { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SNRatio() { }

        /***************************************************/

        public SNRatio(double value, int receiverID, int speakerID, Frequency frequency)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
            Frequency = frequency;
        }
    }
}