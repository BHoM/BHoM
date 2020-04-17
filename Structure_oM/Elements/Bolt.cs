using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structure.Elements
{
    public class Bolt : BHoMObject
    {
        public virtual double Diameter { get; set; }

        public virtual string Standard { get; set; }

        public virtual Line Centerline { get; set; }

    }

}
