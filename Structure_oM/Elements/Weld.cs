using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using System.ComponentModel;


namespace BH.oM.Structure.Elements
{
    public class Weld : BHoMObject
    {
        [Description("Path of Root of Weld")]
        public virtual ICurve WeldPath { get; set; }

        [Description("Object to be Supported")]
        public virtual BHoMObject ObjWelded { get; set; } = null;

        [Description("Object to be welded to (supporting member)")]
        public virtual BHoMObject ObjWeldedTo { get; set; } = null;

        // WeldContour Enum (none/flush/convex/concave/...)

        // Pitch double

        // WeldProcess Enum (shielded metal/submerged arc/gas metal arc/flux cored arc/electroslag/electrogas)

        // WeldType (shop weld/site weld)

    }

}
