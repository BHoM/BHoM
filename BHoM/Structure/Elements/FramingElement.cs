using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Structure.Elements
{
    public class FramingElement : BHoMObject, IPhysical
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Line LocationCurve { get; set; } = null;

        public Properties.IFramingElementProperty Property { get; set; } = null;

        public StructuralUsage1D StructuralUsage { get; set; } = StructuralUsage1D.Beam;

        /***************************************************/
    }
}
