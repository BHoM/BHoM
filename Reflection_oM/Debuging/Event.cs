using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Debuging
{
    public class Event : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DateTime Time { get; set; } = DateTime.Now;

        public string StackTrace { get; set; } = "";

        public string Message { get; set; } = "";

        public EventType Type { get; set; } = EventType.Unknown;


        /***************************************************/
    }
}
