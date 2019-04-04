using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Analytical.Elements.Empty;
using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Analytical.ExampleEmpty
{
    public class Panel : BHoMObject, IPanel
    {
        public List<Edge> ExternalEdges { get; set; }

        public List<Opening> Openings { get; set; }
    }
}
