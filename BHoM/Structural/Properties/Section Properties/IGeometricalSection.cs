using BH.oM.Geometry;

namespace BH.oM.Structural.Properties
{
    public interface IGeometricalSection
    {
        System.Collections.ObjectModel.ReadOnlyCollection<ICurve> Edges { get; }
    }
}
