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
    /// BHoM Acoustic Receiver
    /// </summary>
    public struct Receiver
    {
        #region Fields

        private readonly Point _Position;
        private readonly string _Category;
        private readonly int _ReceiverID;

        #endregion

        #region Properties

        public Point Position
        {
            get { return _Position; }
        }

        public string Category
        {
            get { return _Category; }
        }

        public int ReceiverID
        {
            get { return _ReceiverID; }
        }

        #endregion


        #region Constructors

        public Receiver(Point position, string category = "Omni", int receiverID = 0)
        {
            _Position = position;
            _Category = category;
            _ReceiverID = receiverID;
        }

        #endregion

    }
}
