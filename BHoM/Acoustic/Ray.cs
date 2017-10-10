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
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        /// <summary>
        /// Ray geometric path from speaker to receiver
        /// </summary>
        public Polyline Geometry;

        /// <summary>
        /// Speaker source of the ray represented by ID
        /// </summary>
        public int SpeakerID;

        /// <summary>
        /// Receiver target of the ray represented by ID
        /// </summary>
        public int ReceiverID;

        /// <summary>
        /// Useful panels for ray bounces, represented by ID
        /// </summary>
        public List<int> PanelsID;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ray(Polyline path, int source, int target, List<int> bouncingPattern = null)
        {
            Geometry = path;
            SpeakerID = source;
            ReceiverID = target;
            PanelsID = bouncingPattern;
        }
    }
}
