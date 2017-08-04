using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public interface IObject 
    {
        Guid BHoM_Guid { get; set; }

        string Name { get; set; }

        HashSet<string> Tags { get; set; }

        Dictionary<string, object> CustomData { get; set; }
    }
}
