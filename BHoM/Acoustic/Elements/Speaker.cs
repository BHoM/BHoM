using System.Collections.Generic;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    [Serializable]
    public class Speaker : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Location { get; set; } = new Point();

        public Vector Direction { get; set; } = new Vector();

        public double EmissiveLevel { get; set; } = 100;

        public string Category { get; set; } = "Omni";

        public int SpeakerID { get; set; } = 0;

        public Dictionary<Frequency, double> Gains { get; set; } = new Dictionary<Frequency, double>();

        public Dictionary<Frequency, double[,]> Directivity { get; set; } = new Dictionary<Frequency, double[,]>();


        /***************************************************/
    }
}