using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Elements
{
    public class SteelConnection : BHoMObject
    {
        public List<int> ConnectingElementIds { get; set; } = null;

        public List<Panel> Plates { get; set; } = null;

        public List<Bolt> Bolts { get; set; } = null;

        public List<Weld> Welds { get; set; } = null;

        public List<Cut> Cuts { get; set; } = null;

    }

}