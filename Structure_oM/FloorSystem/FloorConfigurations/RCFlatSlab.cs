using System.Collections.Generic;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Reinforcement;
using BH.oM.Base;
using System.ComponentModel;
using BH.oM.Quantities.Attributes;

namespace BH.oM.Structure.FloorSystem
{
    public class RCFlatSlab : BHoMObject, IFloorConfiguration, IConcreteDropheadSlabConfiguration<ConstantThickness>
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        [Description("SurfaceProperty for the slab.")]
        public virtual ConstantThickness Slab { get; set; } = null;

        [Description("ReinforcementIntent for the slab - extents are normalized")]
        public virtual ISlabReinforcement SlabReinforcement { get; set; } = null;

        [Description("Drophead in the slabs over columns. For a slab without dropheads this will be null.")]
        public virtual Drophead Drophead { get; set; } = null;

        //[Description("Minimum structural bays in the local x direction.")]
        //public virtual int MinBaysX { get; set; } = 0;

        //[Description("Minimum structural bays in the local y direction.")]
        //public virtual int MinBaysY { get; set; } = 0;

        /***************************************************/


    }
}

