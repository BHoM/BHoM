using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Geometry;

namespace BHoM.Acoustic
{
    public class Ray
    {
        #region Private Fields

        private Polyline _Path { get; set; }
        private int _SpeakerID { get; set; }
        private int _ReceiverID { get; set; }
        private List<int> _S { get; set; }

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

        #endregion

        #region Constructor
            /*
        public Ray(Polyline path = null, string source = null, string target = null, List<string> bouncingPattern = null)
        {
            Path = path;
            Source = source;
            Target = target;
            BouncingPattern = bouncingPattern;
        }

        #endregion

        #region Properties

        public double Length()
        {
            return Path.Length;
        }

        public double ToF()             // Time of Flight
        {
            return Path.Length / 343;
        }

        public int Order()
        {
            return BouncingPattern.Count;
        }

        public Point Origin()
        {
            return Path.EndPoint;
        }*/
        #endregion
    }
}
