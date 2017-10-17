using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    /// <summary>
    /// BH.oM Acoustic Ray
    /// </summary>
    public struct Ray
    {
        #region Fields

        private readonly ICurve _Path;
        private readonly int _SpeakerID;
        private readonly int _ReceiverID;
        private readonly List<int> _PanelsID;

        #endregion
        #region Properties

        public ICurve Path
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

        //public double Length // TODO Move to Engine
        //{
        //    get { return _Path.Length; }
        //}

        //public double Time
        //{
        //    get { return _Path.Length / 343; } // TODO Move to Engine
        //}

        public int Order
        {
            get { return _PanelsID.Count; }
        }

        #endregion

        #region Constructors

        public Ray(ICurve path, int source, int target, List<int> bouncingPattern = null)
        {
            _Path = path;
            _SpeakerID = source;
            _ReceiverID = target;
            _PanelsID = bouncingPattern;
        }

        #endregion
    }
}
