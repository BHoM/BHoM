using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Properties.SectionProperty SectionProperty { get; set; } = null;

        public Properties.BarEndReleases EndReleases { get; set; } = null;

        public Properties.BarConstraint Spring { get; set; } = null;

        public Properties.Offset Offset { get; set; } = null;

        //TODO: Move to future beam class??
        public BarStructuralUsage StructuralUsage { get; set; } = BarStructuralUsage.Undefined;

        /// <summary>
        /// Sets the type of elements that should be used in analysis software
        /// </summary>
        public BarFEAType FEAType { get; set; } = default(BarFEAType);

        public Node StartNode { get; set; } = null;

        public Node EndNode { get; set; } = null;

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Bar() { }

        /***************************************************/

        public Bar(Node startNode, Node endNode, string barName = "")
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            Name = barName;
        }

    }
}
