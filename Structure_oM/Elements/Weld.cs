using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;


namespace BH.oM.Structure.Elements
{
    public class Weld : BHoMObject
    {

        public virtual ICurve weldPath { get; set; }

        public virtual BHoMObject objWelded { get; set; } = null;

        public virtual BHoMObject objWeldedTo { get; set; } = null;

        // WeldContour Enum (none/flush/convex/concave/...)

        // Pitch double

        // WeldProcess Enum (shielded metal/submerged arc/gas metal arc/flux cored arc/electroslag/electrogas)

        // WeldType (shop weld/site weld)


    }

}
