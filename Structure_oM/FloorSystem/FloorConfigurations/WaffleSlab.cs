using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.FloorSystem
{
    public class WaffleSlab : BHoMObject, IFloorConfiguration, IConcreteDropheadSlabConfiguration<Waffle>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual Waffle Slab { get; set; } = null;

        [Description("ReinforcementIntent for the slab - extents are normalized")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("Drophead in the slabs over columns. For a slab without dropheads this will be null.")]
        public virtual Drophead Drophead { get; set; } = null;

        /***************************************************/


    }
}

