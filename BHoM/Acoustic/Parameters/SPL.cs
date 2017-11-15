using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public class SPL : IAcousticParameter
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ParameterType Parameter { get; set; } = ParameterType.SPL;

        public double Value { get; set; } = 0.0;

        public int ReceiverID { get; set; } = 0;

        public int SpeakerID { get; set; } = -1;

        public Frequency Frequency { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public SPL() { }

        /***************************************************/

        public SPL(double value, int receiverID, int speakerID, Frequency frequency)
        {
            Value = value;
            ReceiverID = receiverID;
            SpeakerID = speakerID;
            Frequency = frequency;
        }

        /***************************************************/
        /**** Static Operators Override                 ****/
        /***************************************************/

        public static SPL operator +(SPL a, SPL b)
        {
            return new SPL((10 * Math.Log10(Math.Pow(10, a.Value / 10))) + (10 * Math.Log10(Math.Pow(10, b.Value / 10))),
                            a.ReceiverID,
                            -1,
                            a.Frequency);
        }

    }
}