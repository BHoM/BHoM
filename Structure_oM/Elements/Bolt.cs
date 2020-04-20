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
    public class Bolt : BHoMObject
    {
        [Description("Represents the Diameter of the Bolt")]
        public virtual double Diameter { get; set; }

        [Description("Represents Centerline of the Bolt from Top of Bolt Head to end of Shank")]
        public virtual Line Centerline { get; set; }

    }

}
