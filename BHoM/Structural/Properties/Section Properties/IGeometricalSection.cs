using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Structural.Properties
{
    public interface IGeometricalSection : IObject
    {
        System.Collections.ObjectModel.ReadOnlyCollection<ICurve> Edges { get; }
    }
}
