using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Acoustic
{
    public class AcousticRASTIParameters : Parameters
    {
        // Hard coded AcousticParameters, discuss further with M. Harrison
        public AcousticRASTIParameters()
        {
            Frequencies = new List<double> { 1.0, 2.0, 4.0, 8.0, 0.7, 1.4, 2.8, 5.6, 11.2 };    // Are the frequencies replicated at each octave?
            Octaves = new List<double> { 500, 2000 };
            ReverberationTimes = new List<double> { 0.001, 0.001 };
            NoiseLevels = new List<double> { 53.5 };
            Gains = new List<double> { 1.6, 5.3 };
            Speeches = new List<double> { 85 };
        }

        public override List<double> GetNoiseLevel()
        {
            return NoiseLevels;
        }

        public override double GetGain(double frequency, double octave)
        {
            return (frequency < 5) ? Gains[0] : Gains[1];
        }

        public override List<double> GetSpeech()
        {
            return Speeches;
        }
    }
}