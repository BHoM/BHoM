using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class RASTI : IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ParameterType Parameter { get; } = ParameterType.RASTI;

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = 0;

        public Frequency Frequency { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public RASTI() { }

        /***************************************************/

        public RASTI(double value, int receiverID, int speakerID)
        {
            Parameter = ParameterType.RASTI;
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
        }
    }
}