using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    public class Speaker : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Geometry { get; set; } = new Point();

        public Vector Direction { get; set; } = new Vector();

        public string Category { get; set; } = "Omni";

        public int SpeakerID { get; set; } = -1;

        public Dictionary<Frequency, double> Gains { get; set; } = new Dictionary<Frequency, double>();

        public Dictionary<Frequency, double[,]> Directivity { get; set; } = new Dictionary<Frequency, double[,]>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Speaker() { }

        /***************************************************/

        public Speaker(Point position, Vector direction = null, string category = "Omni",
                       int speakerID = 0, Dictionary<Frequency, double> gains = null)
        {
            Geometry = position;
            Direction = direction;
            Category = category;
            SpeakerID = speakerID;
            Gains = gains;
        }
    }
}