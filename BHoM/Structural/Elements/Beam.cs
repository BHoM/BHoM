using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Structural.Elements
{
    public class Beam : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Bar> AnalyticBars { get; set; } = new List<Bar>();

        public ICurve LocationCurve { get; set; } = null;

        public Properties.ISectionProperty SectionProperty { get; set; } = null;

        public BarStructuralUsage StructuralUsage { get; set; } = BarStructuralUsage.Beam;

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; } = 0.0;


        /***************************************************/
    }
}
