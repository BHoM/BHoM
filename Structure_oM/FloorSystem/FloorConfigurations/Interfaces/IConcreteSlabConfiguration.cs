using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public interface IConcreteSlabConfiguration<out T> : ISlabConfiguration<T>
        where T : ISurfaceProperty
    {
        [Description("ReinforcementIntent for the slab - extents are normalized")]
        ISlabReinforcement SlabReinforcement { get; set; }
    }
}
