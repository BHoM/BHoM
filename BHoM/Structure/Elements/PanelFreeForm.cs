using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structural.Properties;


namespace BH.oM.Structural.Elements
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
