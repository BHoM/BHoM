using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;

namespace BHoM.Acoustic
{

    public class AcousticParameters : BHoMObject
    {
        public List<double> Frequencies { get; set; }       // Ask Matthew H. why both Frequencies and Octaves? Should be the same thing.
        public List<double> Octaves { get; set; }
        public List<double> ReverberationTimes { get; set; }
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
}
