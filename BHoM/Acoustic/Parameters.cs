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
        public List<double> ReverberationTimes { get; set; }    //Should be the same thing.
        public List<double> NoiseLevels { get; set; }
        public List<double> Gains { get; set; }
        public List<double> Speeches { get; set; }

        public double GetRevTime(double frequency, double octave)
        {
            return ReverberationTimes[0];
        }

        public virtual double GetNoiseLevel(double frequency, double octave)
        {
            return NoiseLevels[0];
        }

        public virtual double GetGain(double frequency, double octave)
        {
            return Gains[0];
        }

        public virtual double GetSpeech(double frequency, double octave)
        {
            return Speeches[0];
        }
    }

    public class SPL : Parameters
    {

    }

    public class RASTI : Parameters
    {

    }

    public class RT : Parameters
    {

    }

    public class C80 : Parameters
    {

    }

    public class STearly
    {

    }
}
