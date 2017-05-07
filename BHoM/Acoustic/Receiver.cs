using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Base;
using BHoM.Geometry;

namespace BHoM.Acoustic
{
    class Receiver
    {   

        public Point Position { get; set; }
        public string Category { get; set; }
        public string ReceiverID { get; set; }          // Ask Arnauld how to generate it automatically

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
