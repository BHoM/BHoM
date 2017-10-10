using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Room
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// This is not used until Polysurface is implemented in BHoM. Use Area and Volume properties instead
        /// </summary>
        public PolySurface Geometry { get; set; } = new PolySurface();
        
        /// <summary>
        /// Area of the geometrical room space
        /// </summary>
        public double Area { get; set; } = 0;

        /// <summary>
        /// Volume of the geometrical room space
        /// </summary>
        public double Volume { get; set; } = 0;

        /// <summary>
        /// Receiver point used to sample the room
        /// </summary>
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