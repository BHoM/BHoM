using System.Collections.Generic;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Ray : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Polyline Path { get; set; } = new Polyline();

        public int SpeakerID { get; set; } = 0;

        public int ReceiverID { get; set; } = 0;

        public List<int> PanelsID { get; set; } = new List<int>();


        /***************************************************/
    }
}
