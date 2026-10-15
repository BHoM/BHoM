using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;

namespace BH.oM.Structure.FloorSystem
{
    public class TimberJoistFloor : BHoMObject, IFloorConfiguration, ITimberTertiaryBeamFloorConfiguration, ITimberSlabConfiguration<ConstantThickness>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ConstantThickness Slab { get; set; } = null;

        [Description("SectionProperty for the girder spanning the local X direction")]
        public virtual TimberSection PrimaryBeam { get; set; } = null;

        [Description("SectionProperty for the infill beams spanning the local Y direction")]
        public virtual TimberSection SecondaryBeam { get; set; } = null;

        [Description("SectionProperty for the tertiary beams spanning between secondary beams in the local X direction")]
        public virtual TimberSection TertiaryBeam { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of tertiary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double TertiaryBeamTopLevel { get; set; }

        [Description("Number of infill beams in a panel, counting one edge beam, but not the other.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Description("Number of tertiary beams.")]
        public virtual int NumTertiary { get; set; } = 0;

        /***************************************************/


    }
}

