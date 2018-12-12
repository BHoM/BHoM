using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection.Debugging
{
    public class Log : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Event> AllEvents { get; set; } = new List<Event>();

        public List<Event> CurrentEvents { get; set; } = new List<Event>();


        /***************************************************/
    }
}
