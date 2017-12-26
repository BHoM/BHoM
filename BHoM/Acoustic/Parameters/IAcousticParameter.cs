namespace BH.oM.Acoustic
{
    public interface IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        double Value { get; set; }

        int ReceiverID { get; set; }

        int SpeakerID { get; set; }

        Frequency Frequency { get; set; }


        /***************************************************/
    }
}
