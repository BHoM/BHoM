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
    public class OneWayBiscuitSlab : BHoMObject, IFloorConfiguration, IConcretePrimaryBeamConfiguration, IConcreteSlabConfiguration<ToppedSlab>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ToppedSlab Slab { get; set; } = null;

        [Description("ReinforcementIntent for the slab - extents are normalized")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("SectionProperty for the primary beam spanning the local X direction.")]
        public virtual ConcreteSection PrimaryBeam { get; set; } = null;

        [Description("Reinforcement applied to the beams. Can be left null if more detailed reinforcement is applied to the ConcreteSections for Primary beams.")]
        public virtual IBeamReinforcement BeamReinforcement { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; } = 0;

        /***************************************************/
    }
}

