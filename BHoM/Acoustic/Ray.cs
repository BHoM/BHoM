using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Geometry;

namespace BHoM.Acoustic
{
    /// <summary>
    /// BHoM Acoustic Ray
    /// </summary>
    public struct Ray
    {
        #region Fields

        private readonly Curve _Path;
        private readonly int _SpeakerID;
        private readonly int _ReceiverID;
        private readonly List<int> _PanelsID;

        #endregion
        #region Properties

        public Curve Path
        {
            get { return _Path; }
        }

        public int SpeakerID
        {
            get { return _SpeakerID; }
        }

        public int ReceiverID
        {
            get { return _ReceiverID; }
        }

        public List<int> PanelsID
        {
            get { return _PanelsID; }
        }

        /********** Additional Properties**********/

        public double Length
        {
            get { return _Path.Length; }
        }

        public double Time
        {
            get { return _Path.Length / 343; }
        }

        public int Order
        {
            get { return _PanelsID.Count; }
        }

        #endregion

        #region Constructors

        public Ray(Curve path, int source, int target, List<int> bouncingPattern = null)
        {
            _Path = path;
            _SpeakerID = source;
            _ReceiverID = target;
            _PanelsID = bouncingPattern;
        }

        #endregion
    }
}
