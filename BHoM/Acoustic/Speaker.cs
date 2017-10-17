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
        #region Fields

        private readonly Point _Position;
        private readonly Vector _Direction;
        private readonly string _Category;
        private readonly int _SpeakerID;
        private List<double> _Gains;     // value for each frequency
        //private readonly double[] _Directivity;   //public double[,,] Directivity { get; set; }  // [8,36, 19]

        #endregion

        #region Properties

        public Point Position
        {
            get { return _Position; }
        }

        public Vector Direction
        {
            get { return _Direction; }
        }

        public string Category
        {
            get { return _Category; }
        }

        public int SpeakerID
        {
            get { return _SpeakerID; }
        }

        public List<double> Gains
        {
            get { return _Gains; }
            set { }
        }

        public double GetGain(double frequency, double octave)
        {
            return (frequency < 5) ? Gains[0] : Gains[1];
        }

        public double GetGainAngleFactor(double angle, double octave) // take out octave
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }

        #endregion

        #region Constructors

        public Speaker(Point position, Vector direction = null, string category = "Omni", int speakerID = 0, List<double> gains = null)
        {
            if (direction == null) { direction = new Vector(1, 0, 0); }
            if (gains == null) { gains = new List<double> { 1, 1 }; }

            _Position = position;
            _Direction = direction;
            _Category = category;
            _SpeakerID = speakerID;
            _Gains = gains;
        }

        #endregion
    }
}