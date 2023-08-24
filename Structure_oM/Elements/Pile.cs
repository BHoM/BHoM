using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Base;
using BH.oM.Quantities.Attributes;
using BH.oM.Base.Attributes;
using BH.oM.Base.Attributes.Enums;
using BH.oM.Geometry;

using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.Elements
{
    [Description("A pile object defined by it's geometry and section.")]
    public class Pile : BHoMObject, IFoundation
    {
        [Description("Defines the start position of the Pile. Note that Nodes can contain Supports.")]
        public virtual Node StartNode { get; set; }

        [Description("Defines the end position of the Pile. Note that Nodes can contain Supports.")]
        public virtual Node EndNode { get; set; }


        [Description("Section property of the Pile, containing all sectional constants and material as well as profile geometry and dimensions, where applicable.")]
        public virtual ISectionProperty PileSection { get; set; }

        [Angle]
        [Description("Controls the local axis orientation of the Pile \n" +
             "For non-vertical members the local z is aligned with the global Z and rotated with the orientation angle about the local x. \n" +
             "For vertical members the local y is aligned with the global Y and rotated with the orientation angle about the local x. \n" +
             "A Pile is vertical if its projected length to the horizontal plane is less than 0.0001, i.e. a tolerance of 0.1mm on verticality. \n" +
             "For general structural conventions please see the documentation.")]
        [DocumentationURL("https://bhom.xyz/documentation/Conventions/BHoM-Structural-Conventions/", DocumentationType.Documentation)]
        public virtual double OrientationAngle { get; set; } = 0;

    }
}
