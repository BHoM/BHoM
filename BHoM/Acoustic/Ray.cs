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
    public struct Ray : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Polyline Geometry;

        public int SpeakerID;

        public int ReceiverID;

        public List<int> PanelsID;

        /***************************************************/

        public Guid BHoM_Guid { get; set; }

        public string Name { get; set; }

        public HashSet<string> Tags { get; set; }

        public Dictionary<string, object> CustomData { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Ray(Polyline path, int source, int target, List<int> bouncingPattern = null, Dictionary<string, object> customData = null)
        {
            Geometry = path;
            SpeakerID = source;
            ReceiverID = target;
            PanelsID = bouncingPattern;
            CustomData = customData;

            BHoM_Guid = Guid.NewGuid();
            Name = "";
            Tags = new HashSet<string>();
        }
    }
}
