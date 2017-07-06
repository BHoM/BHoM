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
    public class Receiver
    {
        #region Fields

        private Point _Position;
        private string _Category;
        private int _ReceiverID;

        #endregion

        #region Properties

        public Point Position
        {
            get { return _Position; }
            set { _Position = Position; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = Category; }
        }

        public int ReceiverID
        {
            get { return _ReceiverID; }
            set { _ReceiverID = ReceiverID; }
        }

        #endregion


        #region Constructor

        public Receiver(Point position, string category = null)
        {
            if (category == null)
                Category = category;

            Position = position;
            Category = category;
        }

        public Receiver(Point position) : this(position, null)
        {
        }

        #endregion

    }
}
