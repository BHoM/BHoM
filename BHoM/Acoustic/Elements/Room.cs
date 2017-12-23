using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    [Serializable] public class Room : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PolySurface Geometry { get; set; } = new PolySurface();
        
        public double Area { get; set; } = 0;

        public double Volume { get; set; } = 0;

        public List<Receiver> Samples { get; set; } = new List<Receiver>();
    }
}