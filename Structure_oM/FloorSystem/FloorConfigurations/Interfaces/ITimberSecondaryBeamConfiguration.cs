using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.FloorSystem
{
    public interface ITimberSecondaryBeamConfiguration<out TPrimary> : ISecondaryBeamConfiguration<TPrimary, TimberSection>
        where TPrimary : IGeometricalSection
    {

    }
}
