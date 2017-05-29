using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Acoustic
{

    public class Parameters : BHoMObject
    {
        public double Value { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public List<string> BouncingPattern { get; set; }
        public List<double> Octaves { get; set; }


        public List<double> Frequencies { get; set; }           // Ask Matthew H. why both Frequencies and Octaves?
        public List<double> Gains { get; set; }

    }
}
