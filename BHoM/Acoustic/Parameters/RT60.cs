using BH.oM.Base;
using System;

namespace BH.oM.Acoustic
{
    [Serializable]
    public class RT60 : BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = 0;

        public Frequency Frequency { get; set; } = Frequency.Hz1000;


        /***************************************************/
    }
}
