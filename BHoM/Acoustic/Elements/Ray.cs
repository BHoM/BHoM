using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Ray : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Polyline Geometry { get; set; } = new Polyline();

        public int SpeakerID { get; set; } = 0;

        public int ReceiverID { get; set; } = 0;

        public List<int> PanelsID { get; set; } = new List<int>();
    }
}
