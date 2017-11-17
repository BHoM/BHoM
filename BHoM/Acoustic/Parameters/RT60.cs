using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class RT60 : IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ParameterType Parameter { get; set; } = ParameterType.RT60;

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = 0;

        public Frequency Frequency { get; set; } = Frequency.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RT60() { }

        /***************************************************/

        public RT60(double value, int receiverID, int speakerID)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
        }
    }
}
