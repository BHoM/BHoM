using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
