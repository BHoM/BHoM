using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Acoustic
{
    public class Receiver : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Point Geometry { get; set; } = new Point();

        public string Category { get; set; } = "Omni";

        public int ReceiverID { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Receiver() { }

        /***************************************************/

        public Receiver(Point position)
        {
            Geometry = position;
        }

        /***************************************************/

        public Receiver(Point position, string category, int receiverID)
        {
            Geometry = position;
            Category = category;
            ReceiverID = receiverID;
        }
    }
}
