using BH.oM.Base;
using BH.oM.Geometry;
using System.Collections.ObjectModel;

namespace BH.oM.Structural.Properties
{
    public interface IProfile  : IBHoMObject
    {
        ShapeType Shape { get; }

        ReadOnlyCollection<ICurve> Edges { get; }
    }
}
