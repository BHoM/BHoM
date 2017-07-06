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
    public class Ray
    {
        #region Private Fields

        private Polyline _Path;
        private int _SpeakerID;
        private int _ReceiverID;
        private List<int> _PanelsID;

        #endregion

        #region Public Properties

        public Polyline Path
        {
            get { return _Path; }
            set { _Path = Path; }
        }

        public int SpeakerID
        {
            get { return _SpeakerID; }
            set { _SpeakerID = SpeakerID; }
        }

        public int ReceiverID
        {
            get { return _ReceiverID; }
            set { _ReceiverID = ReceiverID; }
        }

        public List<int> PanelsID
        {
            get { return _PanelsID; }
            set { _PanelsID = PanelsID; }
        }


        /********** Additional Properties**********/

        public double Length
        {
            get { return Path.Length; }
        }

        public double Time
        {
            get { return Path.Length / 343; }
        }

        public int Order
        {
            get { return PanelsID.Count; }
        }

        #endregion

        #region Constructor

        public Ray(Polyline path, int source, int target, List<int> bouncingPattern = null)
        {
            Path = path;
            SpeakerID = source;
            ReceiverID = target;
            PanelsID = bouncingPattern;
        }

        #endregion
    }
}
