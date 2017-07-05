using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Acoustic
{
    /// <summary>
    /// BHom Acoustic parameters class
    /// </summary>
    public class Parameters : BHoMObject
    {
        private double Value { get; set; }
        private string Source { get; set; }
        private string Target { get; set; }
        private List<string> BouncingPattern { get; set; }
        public List<double> Octaves { get; set; }


        public List<double> Frequencies { get; set; }           // Ask Matthew H. why both Frequencies and Octaves?
        public List<double> Gains { get; set; }


    }
}
