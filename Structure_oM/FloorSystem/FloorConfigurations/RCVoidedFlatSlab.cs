using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Physical.Materials;

namespace BH.oM.Structure.FloorSystem
{
    public class RCVoidedFlatSlab : BHoMObject, IFloorConfiguration, IConcreteSlabConfiguration<BiDirectionalVoided>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual BiDirectionalVoided Slab { get; set; } = null;

        [Description("ReinforcementIntent for the slab - extents are normalized.")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("Material in the voided zone of the slab. If null, assumed to be no material in the voided zone (air).")]
        public virtual Material VoidMaterial { get; set; } = null;

        /***************************************************/


    }
}

