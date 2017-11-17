using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    public class Room : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PolySurface Geometry { get; set; } = new PolySurface();
        
        public double Area { get; set; } = 0;

        public double Volume { get; set; } = 0;

        public List<Receiver> Samples { get; set; } = new List<Receiver>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Room(List<Point> points, double area, double volume)
        {
            Area = area;
            Volume = volume;
            Samples = points.Select( x => new Receiver(x)).ToList();
        }

        /***************************************************/

        public Room(List<Receiver> receivers, double area, double volume)
        {
            Area = area;
            Volume = volume;
            Samples = receivers;
        }
    }
}