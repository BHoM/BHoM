using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public interface IConcreteDropheadSlabConfiguration<out T> : IConcreteSlabConfiguration<T>
        where T : ISurfaceProperty
    {
        [Description("Drophead in the slabs over columns. For a slab without dropheads this will be null.")]
        Drophead Drophead { get; set; }
    }
}
