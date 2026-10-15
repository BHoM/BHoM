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
    [Description("Hybrid system for timber slab on top of a steel frame.")]
    public class HybridTimberOnSteel : BHoMObject, IFloorConfiguration, ISteelFrameConfiguration, ITimberSlabConfiguration<ISurfaceProperty>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ISurfaceProperty Slab { get; set; } = null;

        [Description("SectionProperty for the girder spanning the local X direction.")]
        public virtual ISteelSection PrimaryBeam { get; set; } = null;

        [Description("SectionProperty for the infill beams spanning the local Y direction.")]
        public virtual ISteelSection SecondaryBeam { get; set; } = null;

        [Length]
        [Description("Distance from top of slab to top of primary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double PrimaryBeamTopLevel { get; set; }

        [Length]
        [Description("Distance from top of slab to top of secondary beam. Set to slab thickness for slab on top but set to zero for within depth of slab.")]
        public virtual double SecondaryBeamTopLevel { get; set; }

        [Description("Number of infill beams in a panel, counting one edge beam, but not the other.")]
        public virtual int NumSecondary { get; set; } = 0;

        [Length]
        [Description("Thickness of intumescent paint covering exposed primary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        public virtual double IntumescentPaintThicknessPrimary { get; set; }

        [Length]
        [Description("Thickness of intumescent paint covering exposed secondary beam steelwork. Allowance used for when computing takeoffs of the configuration.")]
        public virtual double IntumescentPaintThicknessSecondary { get; set; }

        [Description("Material of the instumescent paint.")]
        public virtual Material IntumescentPaintMaterial { get; set; }


        /***************************************************/

    }
}


