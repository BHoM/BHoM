using System.ComponentModel;
using BH.oM.Common;
using BH.oM.Geometry;
using System.Collections.Generic;

namespace BH.oM.Structure.Results
{
    public class MeshResults : IResultCollection
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string ObjectId { get; set; } = "";

        public MeshResultLayer ResultLayer { get; set; } 

        [Description("Position within the element thickness that result is extracted from, normalised to 1. 0 = lower surface, 0.5 = middle, 1 = top surface")]
        public double LayerPosition { get; set; }

        public MeshResultSmoothingType Smoothing { get; set; }

        public List<NodeResult> NodeResults { get; set; } = new List<NodeResult>();

    }
}
