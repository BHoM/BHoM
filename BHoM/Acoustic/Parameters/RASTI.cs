using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Rasti() { }

        /***************************************************/

        public Rasti(double value, int receiverID)
        {
            Value = value;
            ReceiverID = receiverID;
        }
    }
}