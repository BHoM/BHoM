using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.Properties.Surface;
using BH.oM.Structure.Properties.Constraint;

namespace BH.oM.Structure.Elements
{
    public class PanelFreeForm : BHoMObject, IAreaElement
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ISurface Surface { get; set; } = null;

        public IProperty2D Property { get; set; } = null;

        public Constraint3DOF PlanarSpring { get; set; } = null;


        /***************************************************/
    }
}
