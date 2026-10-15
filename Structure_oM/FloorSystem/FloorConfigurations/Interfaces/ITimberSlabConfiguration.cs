using BH.oM.Quantities.Attributes;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SurfaceProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public interface ITimberSlabConfiguration<out T> : ISlabConfiguration<T>
        where T : ISurfaceProperty
    {

    }
}
