using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class Thermostat : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public bool ProportionalControl { get; set; } = false;

        public double ControlRange { get; set; } = 0.0; //Degrees Celcius contorl range

        public List<Profile> Profiles { get; set; } = new List<Profile>();

        /***************************************************/
    }
}
