using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public interface IObject
    {
        System.Guid BHoM_Guid { get; }

        string Name { get; set; }

        Dictionary<string, object> CustomData { get; set; }
    }
}
