using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.SectionProperties;

namespace BH.oM.Structure.FloorSystem
{
    public interface IConcretePrimaryBeamConfiguration : IPrimaryBeamConfiguration<ConcreteSection>
    {
        IBeamReinforcement BeamReinforcement { get; set; }
    }
}
