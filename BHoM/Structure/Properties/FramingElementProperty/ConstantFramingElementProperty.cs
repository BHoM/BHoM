using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Structure.Properties
{
    public class ConstantFramingElementProperty : BHoMObject, IFramingElementProperty
    {
        public ISectionProperty SectionProperty { get; set; }

        public double OrientationAngle { get; set; } = 0;
    }
}
