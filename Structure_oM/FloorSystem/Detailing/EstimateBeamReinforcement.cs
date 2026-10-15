using BH.oM.Base;
using BH.oM.Structure.Fragments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Class for beam reinforcement for floor configuration where the reinforcement has been defined as a density.")]
    public class EstimateBeamReinforcement : BHoMObject, IBeamReinforcement
    {
        [Description("Amount of reinforcement in the Primary Beam.")]
        public virtual ReinforcementDensity PrimaryReinforcement { get; set; } = null;

        [Description("Amount of reinforcement in the Secondary Beam.")]
        public virtual ReinforcementDensity SecondaryReinforcement { get; set; } = null;
    }
}
