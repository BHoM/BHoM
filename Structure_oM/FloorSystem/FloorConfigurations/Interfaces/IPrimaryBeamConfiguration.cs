using BH.oM.Structure.SectionProperties;
using BH.oM.Quantities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Base interface for framing systems containing a Primary beam.")]
    public interface IPrimaryBeamConfiguration<out TPrimary> : IFloorConfiguration
        where TPrimary : IGeometricalSection
    {
        [Description("Section for the primary beams spanning between columns.")]
        TPrimary PrimaryBeam { get; }

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        double PrimaryBeamTopLevel { get; set; }
    }
}
