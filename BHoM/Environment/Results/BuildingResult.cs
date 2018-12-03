using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class BuildingResult : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ProfileResult LatentAdditionProfile { get; set; } = new ProfileResult();
        public double CloudCover { get; set; } = 0;
        public ProfileResult CoolingProfile { get; set; } = new ProfileResult();
        public double DiffuseRadiation { get; set; } = 0; //Watts per Square Meter
        public double ExternalHumidity { get; set; } = 0;
        public double ExternalTemperature { get; set; } = 0;
        public double GlobalRadiation { get; set; } = 0;
        public ProfileResult HeatingProfile { get; set; } = new ProfileResult();
        public ProfileResult LatentRemovalProfile { get; set; } = new ProfileResult();
        public double WindDirection { get; set; } = 0; //0 to 360 degrees
        public double WindSpeed { get; set; } = 0;
    }
}
