using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHG = BHoM.Geometry;

namespace BHoM.Acoustic
{
    public class Zone
    {
        public Zone(List<BHG.Point> points, double area, double volume)
        {
            Area = area;
            Volume = volume;
            SamplePoints = points;
        }

        public double Area { get; set; }
        public double Volume { get; set; }
        public List<BHG.Point> SamplePoints { get; set; }
    }
}