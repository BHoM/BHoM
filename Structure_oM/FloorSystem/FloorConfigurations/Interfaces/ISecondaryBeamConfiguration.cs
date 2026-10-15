
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
    [Description("Base interface for framing systems containing primary beams spanning between columns and secondary beams spanning between primary beams.")]
    public interface ISecondaryBeamConfiguration<out TPrimary, out TSecondary> : IPrimaryBeamConfiguration<TPrimary>
        where TPrimary : IGeometricalSection
        where TSecondary : IGeometricalSection
    {
        TSecondary SecondaryBeam { get; }
        int NumSecondary { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        double SecondaryBeamTopLevel { get; set; }
    }
}
