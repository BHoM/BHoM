using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    public class Room : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PolySurface Boundaries { get; set; } = new PolySurface();
        
        public double Area { get; set; } = 0;

        public double Volume { get; set; } = 0;

        public List<Receiver> Samples { get; set; } = new List<Receiver>();


        /***************************************************/
    }
}