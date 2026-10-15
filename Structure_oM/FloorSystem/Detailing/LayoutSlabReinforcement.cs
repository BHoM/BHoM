using BH.oM.Base;
using BH.oM.Structure.Reinforcement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    [Description("Class for slab reinforcement for floor configuration where the layout has been explicitly defined.")]
    public class LayoutSlabReinforcement : BHoMObject, ISlabReinforcement
    {
        [Description("ReinforcementIntent for the slab - extents are normalized")]
        public virtual PanelRebarIntent Reinforcement { get; set; } = null;
    }
}
