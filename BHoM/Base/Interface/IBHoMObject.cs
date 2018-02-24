using System;
using System.Collections.Generic;

namespace BH.oM.Base
{
    public interface IBHoMObject : IObject
    {
        Guid BHoM_Guid { get; set; }

        string Name { get; set; }

        HashSet<string> Tags { get; set; }

        Dictionary<string, object> CustomData { get; set; }

        IBHoMObject GetShallowClone(bool newGuid = false);
    }
}
