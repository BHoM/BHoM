using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;
using System.Threading;

namespace BH.oM.Acoustic
{
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
        /**** Constructors                              ****/
        /***************************************************/

        public Speaker() { }

        /***************************************************/

        public Speaker(Point location, Vector direction = null, double emissiveLevel = 100, string category = "Omni")
        {
            SpeakerID = Interlocked.Increment(ref globalInstanceCount);
            Location = location;
            Direction = direction;
            EmissiveLevel = emissiveLevel;
            Category = category;
            Gains = new Dictionary<Frequency, double>() { { Frequency.Hz500, 1.6 }, { Frequency.Hz2000, 5.3 } };
        }

        /***************************************************/

        public Speaker(Point location, Vector direction, string category, Dictionary<Frequency, double> gains = null, Dictionary<Frequency, double[,]> directivity = null)
        {
            SpeakerID = Interlocked.Increment(ref globalInstanceCount);
            Location = location;
            Direction = direction;
            Category = category;
            Gains = gains;
            Directivity = directivity;
        }


        /***************************************************/
        /**** Static shared fields                      ****/
        /***************************************************/

        public static int globalInstanceCount = -1;
    }
}