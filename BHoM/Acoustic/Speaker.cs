using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;

namespace BHoM.Acoustic
{
    public class Speaker
    {
        /// <summary>
        /// Source emissive point
        /// </summary>
        public Point Position { get; set; }
        /// <summary>
        /// Main emissive direction for directivity factor
        /// </summary>
        public Vector Direction { get; set; }
        /// <summary>
        /// Source dirctivity type as string
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Automatically generated identifier of a source
        /// </summary>
        public string SpeakerID { get; set; }       // Ask Arnauld how to generate it automatically

        #region Constructor

        /// <summary>
        /// Instantiate a new source by emissive point, direction and directivity type.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        /// <param name="direction">Defines main directivity vector</param>
        /// <param name="category">Defines source directivity type</param>
        public Speaker(Point position, Vector direction = null, string category = null)
        {
            if (direction == null)
                direction = new Vector(0, 0, 1);
            if (category == null)
                category = "Omni";

            Position = position;
            Direction = direction;
            Category = category;
        }

        /// <summary>
        /// Instantiate a new source by emissive point and category. Emits on Z axis.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        /// <param name="category">Defines source directivity type</param>
        public Speaker(Point position, string category) : this(position, null, category)
        {
        }

        /// <summary>
        /// Instantiate a new source by emissive point. By default, emits on Z axis as Omnidirectional source.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        public Speaker(Point position) : this(position, null, null)
        {
        }

        #endregion

        #region Properties

        public double GetGainAngleFactor(double angle, double octave) // take out octave
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }

        /*
        /// <summary>
        /// Returns a list of the max emissive power in dB at eight frequency bands 125 250 500 1k 2k 4k 8k 16k
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<double> mSPL(Speaker speaker)       // Get values from  Json derived from CATT sd files.
        {
        }
        /// <summary>
        /// Returns a list of the nominal emissive power in dB at eight frequency bands 125 250 500 1k 2k 4k 8k 16k
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<double> nSPL(Speaker speaker)       // Get values from  Json derived from CATT sd files.
        {

        }
        /// <summary>
        /// Returns a two dimensional 19x36 array that stores directivity index of the source. 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public double[,] dSPL(Speaker speaker)          // Get values from  Json derived from CATT sd files.
        {
            
        }
        */
        #endregion

    }
}