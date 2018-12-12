using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Structure.Properties.Framing;

namespace BH.oM.Structure.Elements
{
    public class FramingElement : BHoMObject, IPhysical
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line LocationCurve { get; set; } = null;

        public IFramingElementProperty Property { get; set; } = null;

        public StructuralUsage1D StructuralUsage { get; set; } = StructuralUsage1D.Beam;

        /***************************************************/
    }
}
