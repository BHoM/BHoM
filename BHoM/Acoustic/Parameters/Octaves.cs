using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Acoustic
{
    public static class Octaves
    {
        public const Frequency Hz63 = Frequency.Hz63;
        public const Frequency Hz125 = Frequency.Hz125;
        public const Frequency Hz250 = Frequency.Hz250;
        public const Frequency Hz500 = Frequency.Hz500;
        public const Frequency Hz1000 = Frequency.Hz1000;
        public const Frequency Hz2000 = Frequency.Hz2000;
        public const Frequency Hz4000 = Frequency.Hz4000;
        public const Frequency Hz8000 = Frequency.Hz8000;
        public const Frequency Hz16000 = Frequency.Hz16000;
        public const Frequency Sum = Frequency.Sum;

    }

    public enum Frequency
    {
        Hz63    = 63,
        Hz125   = 125,
        Hz250   = 250,
        Hz500   = 500,
        Hz1000  = 1000,
        Hz2000  = 2000,
        Hz4000  = 4000,
        Hz8000  = 8000,
        Hz16000 = 16000,
        Sum     = 0,
    }
    

}
