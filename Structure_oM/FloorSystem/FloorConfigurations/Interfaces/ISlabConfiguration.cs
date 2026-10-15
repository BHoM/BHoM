using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public interface ISlabConfiguration<out T> : IFloorConfiguration
        where T : ISurfaceProperty
    {
        [Description("SurfaceProperty for the slab.")]
        T Slab { get; }
    }
}
