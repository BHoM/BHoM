using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Structure.Properties.Section;
using BH.oM.Structure.Properties.Constraint;
using BH.oM.Structure.Properties;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar : BHoMObject, IElement1D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        public ISectionProperty SectionProperty { get; set; } = null;

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; } = 0;

        public BarRelease Release { get; set; } = null;

        public BarFEAType FEAType { get; set; } = BarFEAType.Flexural;

        public Constraint4DOF Spring { get; set; } = null;

        public Offset Offset { get; set; } = null;


        /***************************************************/
    }
}
