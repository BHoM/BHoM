using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SNRatio: BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ParameterType Parameter { get; } = ParameterType.SNRATIO;

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;

        public Frequency Frequency { get; set; } = Frequency.Hz1000;


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