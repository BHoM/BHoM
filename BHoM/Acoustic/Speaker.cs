using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;

namespace BHoM.Acoustic
{
    /// <summary>
    /// BHoM Acoustic Speaker
    /// </summary>
    public class Speaker
    {
        #region Fields

        /// <summary>
        /// Source emissive point
        /// </summary>
        private Point _Position;
        /// <summary>
        /// Main emissive direction for directivity factor
        /// </summary>
        private Vector _Direction;
        /// <summary>
        /// Source dirctivity type as string
        /// </summary>
        private string _Category;
        /// <summary>
        /// Automatically generated identifier of a source
        /// </summary>
        private int _SpeakerID;
        /// <summary>
        /// Acoustic Gain
        /// </summary>
        private List<double> _Gains;     // value for each frequency
        /// <summary>
        /// Directivity factor measured on a sphere each 10deg longitudinally
        /// </summary>
        private double[,,] _Directivity;  // [8,36, 19]

        #endregion

        #region Properties

        public Point Position
        {
            get { return _Position; }
            set { _Position = Position; }
        }

        public Vector Direction
        {
            get { return _Direction; }
            set { _Direction = Direction; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = Category; }
        }

        public int SpeakerID
        {
            get { return _SpeakerID; }
            set { _SpeakerID = SpeakerID; }
        }

        public List<double> Gains
        {
            get { return _Gains; }
            set { _Gains = Gains; }
        }

        public double[,,] Directivity
        {
            get { return _Directivity; }
            set { _Directivity = _Directivity; }
        }

        /***************** Additional Properties ******************/

        public double GetGain(double frequency, double octave)
        {
            return (frequency < 5) ? Gains[0] : Gains[1];
        }

        public double GetGainAngleFactor(double angle, double octave) // take out octave
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }

        #endregion

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
                direction = new Vector(1, 0, 0);
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
    }
}