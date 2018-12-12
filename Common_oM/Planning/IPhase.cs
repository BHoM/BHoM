using BH.oM.Base;
using System;

namespace BH.oM.Common.Planning
{
    public interface IPhase : IBHoMObject
    {
        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }
     }
}
