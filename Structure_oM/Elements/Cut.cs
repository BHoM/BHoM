using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;


namespace BH.oM.Structure.Elements
{
    public class Cut : BHoMObject
    {
        public virtual ICurve curve { get; set; } = null;

        public virtual BHoMObject cutObject { get; set; } = null;

        public virtual double thickness { get; set; } = 0;
    }

}
