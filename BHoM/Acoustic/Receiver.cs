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
    /// BHoM Acoustic Receiver
    /// </summary>
    public struct Receiver
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Spatial position of the receiver
        /// </summary>
        public Point Geometry { get; set; }

        /// <summary>
        /// Directivity pattern category of the receiver. Default is set to omnidirectional. Format to be agreed
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Receiver identifier, this is unique for each model
        /// </summary>
        public int ReceiverID { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Receiver(Point position, string category = "Omni", int receiverID = 0)
        {
            Geometry = position;
            Category = category;
            ReceiverID = receiverID;
        }
    }
}
