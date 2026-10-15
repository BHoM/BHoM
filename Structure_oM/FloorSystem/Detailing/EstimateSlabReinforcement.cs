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
    [Description("Class for slab reinforcement for floor configuration where the reinforcement has been defined as a density.")]
    public class EstimateSlabReinforcement : BHoMObject, ISlabReinforcement
    {
        [Description("Amount of reinforcement in the main slab.")]
        public virtual ReinforcementDensity SlabReinforcement { get; set; } = null;

        [Description("Amount of Prestress tendon in the slab. Will be null if the slab does not contain any prestress tendons.")]
        public virtual ReinforcementDensity PrestressTendonDensity { get; set; } = null;

    }
}
