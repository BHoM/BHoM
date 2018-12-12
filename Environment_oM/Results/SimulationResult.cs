using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class SimulationResult : BHoMObject
    {
        public SimulationResultType SimulationResultType { get; set; } = SimulationResultType.Undefined;
        public List<ProfileResult> SimulationResults { get; set; } = new List<ProfileResult>();
    }
}
