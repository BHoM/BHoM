using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class InternalCondition : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public EmitterProperties EmitterProperties { get; set; } = new EmitterProperties();
        public List<Profile> Profiles { get; set; } = new List<Profile>();

        /***************************************************/
    }
}
