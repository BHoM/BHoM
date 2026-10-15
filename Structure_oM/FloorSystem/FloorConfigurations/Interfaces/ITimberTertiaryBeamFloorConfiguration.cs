using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.FloorSystem
{
    public interface ITimberTertiaryBeamFloorConfiguration : ITimberFrameConfiguration, ITertiaryBeamConfiguration<TimberSection, TimberSection, TimberSection>
    {

    }
}
