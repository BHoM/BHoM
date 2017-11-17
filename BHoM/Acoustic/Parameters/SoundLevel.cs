using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SoundLevel : BHoMObject, IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;    // -1 represents Sum of all sources

        public Frequency Frequency { get; set; } = Frequency.Hz1000;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SoundLevel() { }

        /***************************************************/

        public SoundLevel(double value, int receiverID, int speakerID, Frequency frequency)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
            Frequency = frequency;
        }


        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static SoundLevel operator +(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel((10 * Math.Log10(Math.Pow(10, a.Value / 10))) + (10 * Math.Log10(Math.Pow(10, b.Value / 10))),
                            a.ReceiverID, -1, a.Frequency);
        }
        
        /***************************************************/

        public static SoundLevel operator -(SoundLevel a, SoundLevel b)
        {
            return new SoundLevel((10 * Math.Log10(Math.Pow(10, a.Value / 10))) - (10 * Math.Log10(Math.Pow(10, b.Value / 10))),
                            a.ReceiverID, -1, a.Frequency);
        }
    }
}