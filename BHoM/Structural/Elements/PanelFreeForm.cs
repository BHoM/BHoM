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

        public Property2D Property { get; set; } = null;

        public SurfaceConstraint PlanarSpring { get; set; } = null;


        /***************************************************/
    }
}
