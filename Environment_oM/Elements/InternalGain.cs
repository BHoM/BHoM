using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class InternalGain : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public List<Profile> Profiles { get; set; } = new List<Profile>();

        public IGCoefficientProperties CoefficientProperties { get; set; } = new IGCoefficientProperties();
        public IGRadiationProperties RadiationProperties { get; set; } = new IGRadiationProperties();

        public double PersonGain { get; set; } = 0;
        public double Illuminance { get; set; } = 0;

        public double OutsideAirRatePerPerson { get; set; } = 0;

        /***************************************************/
    }
}
