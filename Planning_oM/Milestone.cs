using BH.oM.Base;
using System;

namespace BH.oM.Planning
{
    public class Milestone : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DateTimeOffset? DueOn { get; set; }

        public ItemState State { get; set; }

        /***************************************************/
    }
}
