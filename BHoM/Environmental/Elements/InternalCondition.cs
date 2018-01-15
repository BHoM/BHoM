using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Properties;

namespace BH.oM.Environmental.Elements
{
    public class InternalCondition : BHoMObject
    {
        public EmitterProperties EmitterProperties;
        public List<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
