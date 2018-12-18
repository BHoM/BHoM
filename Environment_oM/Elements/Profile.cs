using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Elements
{
    public class Profile : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ProfileType ProfileType { get; set; } = ProfileType.Hourly;

        public double MultiplicationFactor { get; set; } = 1.0;
        public double SetBackValue { get; set; } = 0.0; //Value for those outside the schedule

        public string Function { get; set; } = ""; //Function built query defined as a string within simulation

        public List<double> Values { get; set; } = new List<double>(); //List of values for each hour of simulation under hourly profile or hours in a year for yearly profile

        public ProfileCategory Category { get; set; } = ProfileCategory.Gain;

        /***************************************************/
    }
}
