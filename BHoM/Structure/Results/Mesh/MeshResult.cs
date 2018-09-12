using System;
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

        public List<NodeResult> NodeResults { get; set; } = new List<NodeResult>();

    }
}
