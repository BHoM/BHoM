using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    /// <summary>
    /// BHoM Acoustic Speaker
    /// </summary>
    public struct Speaker
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Spatial position of the speaker
        /// </summary>
        public Point Geometry { get; set; }

        /// <summary>
        /// Main emissive direction. The arrow of the vector represents the front of the source
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Directivity pattern category of the speaker. Format to be agreed, whereas CATT .sd1 proposed
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Speaker identifier, this is unique for each model
        /// </summary>
        public int SpeakerID { get; set; }

        /// <summary>
        /// Speaker gains used for STI calculations
        /// </summary>
        public Dictionary<Frequency, double> Gains { get; set; }     // value for each frequency

        /// <summary>
        /// Directivity pattern stored in a three-dimensional array.
        /// First dimension represents the frequency, the second longitudinal sections, the third latitudinal sections.
        /// </summary>
        //public double[] Directivity { get; set; } = new double[8,36,19]


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Speaker(Point position, Vector direction = null, string category = "Omni", int speakerID = 0, Dictionary<Frequency, double> gains = null)
        {
            Geometry = position;
            Direction = direction;
            Category = category;
            SpeakerID = speakerID;
            Gains = gains;
        }
    }
}