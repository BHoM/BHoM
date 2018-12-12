using BH.oM.Base;
using BH.oM.Structure.Properties.Section;

namespace BH.oM.Structure.Properties.Framing
{
    public class ConstantFramingElementProperty : BHoMObject, IFramingElementProperty
    {
        public ISectionProperty SectionProperty { get; set; }

        public double OrientationAngle { get; set; } = 0;
    }
}
