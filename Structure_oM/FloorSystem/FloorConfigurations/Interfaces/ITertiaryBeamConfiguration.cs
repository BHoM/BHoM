using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Base interface for framing systems containing primary beams spanning between columns and secondary beams spanning between primary beams and tertrary beams spanning between secondary beams.")]
    public interface ITertiaryBeamConfiguration<out TPrimary, out TSecondary, out TTertiary> : ISecondaryBeamConfiguration<TPrimary, TSecondary>
        where TPrimary : IGeometricalSection
        where TSecondary : IGeometricalSection
        where TTertiary : IGeometricalSection
    {
        TTertiary TertiaryBeam { get; }
        int NumTertiary { get; set; }

        [Length]
        [Description("Distance from top of slab to top of tertiary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        double TertiaryBeamTopLevel { get; set; }
    }
}
