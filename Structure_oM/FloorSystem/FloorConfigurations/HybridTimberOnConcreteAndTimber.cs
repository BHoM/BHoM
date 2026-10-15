using BH.oM.Base;
using BH.oM.Physical.Materials;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Structure.FloorSystem.FloorConfigurations
{
    [Description("Hybrid system for timber slab on top of a concrete frame.")]
    public class HybridTimberOnConcreteAndTimber : BHoMObject, IFloorConfiguration, IConcretePrimaryBeamConfiguration, ITimberSecondaryBeamConfiguration<ConcreteSection>, ITimberSlabConfiguration<ISurfaceProperty>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ISurfaceProperty Slab { get; set; } = null;

        [Description("SectionProperty for the girder spanning the local X direction.")]
        public virtual ConcreteSection PrimaryBeam { get; set; } = null;

        [Description("SectionProperty for the infill beams spanning the local Y direction.")]
        public virtual TimberSection SecondaryBeam { get; set; } = null;

        [Description("Number of infill beams in a panel, counting one edge beam, but not the other.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Description("Reinforcement applied to the beams. Can be left null if more detailed reinforcement is applied to the ConcreteSections for Primary beams.")]
        public virtual IBeamReinforcement BeamReinforcement { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        /***************************************************/

    }
}


