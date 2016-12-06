using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHG = BHoM.Geometry;

namespace BHoM.Acoustic
{
    public class Speaker
    {
        public Speaker(BHG.Point pos, BHG.Vector dir, string category)
        {
            Position = pos;
            Direction = dir;
            Category = category;
        }

        public BHG.Point Position { get; set; }
        public BHG.Vector Direction { get; set; }
        public string Category { get; set; }

        public double GetGainAngleFactor(double angle, double octave) // take out octave
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }
    }
}