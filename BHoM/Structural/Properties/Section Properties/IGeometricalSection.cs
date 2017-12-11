using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.Structural.Properties
{
    public interface IGeometricalSection
    {
        System.Collections.ObjectModel.ReadOnlyCollection<ICurve> Edges { get; }
    }
}
