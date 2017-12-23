using BH.oM.Base;
using System;

namespace BH.oM.Acoustic
{
    [Serializable] public class SoundLevel : BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;    // -1 represents Sum of all sources

        public Frequency Frequency { get; set; } = Frequency.Hz1000;


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static SoundLevel operator +(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel()
            {
                Value = 10 * Math.Log10(Math.Pow(10, a.Value / 10) + (Math.Pow(10, b.Value / 10))),
                ReceiverID = a.ReceiverID,
                SpeakerID = - 1,
                Frequency = a.Frequency
            };
        }
        
        /***************************************************/

        public static SoundLevel operator -(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel()
            {
                Value = 10 * Math.Log10(Math.Pow(10, a.Value / 10) - (Math.Pow(10, b.Value / 10))),
                ReceiverID = a.ReceiverID,
                SpeakerID = -1,
                Frequency = a.Frequency
            };
        }
    }
}