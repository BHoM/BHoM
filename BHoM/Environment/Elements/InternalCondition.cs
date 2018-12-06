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

        public Emitter Emitter { get; set; } = new Emitter();

        public bool IncludeSolarInMeanRadiantTemp { get; set; } = true;

        public List<SimulationDayType> DayTypes { get; set; } = new List<SimulationDayType>();

        public InternalGain InternalGain { get; set; } = new InternalGain();

        public Thermostat Thermostat { get; set; } = new Thermostat();
        /***************************************************/
    }
}
