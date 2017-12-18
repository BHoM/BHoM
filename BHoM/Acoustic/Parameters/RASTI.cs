using BH.oM.Base;

namespace BH.oM.Acoustic
{
    public class Rasti : BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;

        public Frequency Frequency { get; set; } = Frequency.Hz1000;
    }
}