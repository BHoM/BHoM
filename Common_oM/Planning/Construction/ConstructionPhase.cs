using BH.oM.Base;
using System;

namespace BH.oM.Common.Planning
{
    public class ConstructionPhase : BHoMObject, IPhase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public DateTime StartTime { get; set; } = new DateTime();

        public DateTime EndTime { get; set; } = new DateTime();


        /***************************************************/
    }
}
