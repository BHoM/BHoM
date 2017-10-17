using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Zone
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Area { get; set; } = 0;

        public double Volume { get; set; } = 0;

        public List<Point> SamplePoints { get; set; } = new List<Point>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Zone(List<Point> points, double area, double volume)
        {
            Area = area;
            Volume = volume;
            SamplePoints = points;
        }
    }
}