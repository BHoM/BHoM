using BH.oM.Base;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Interface implemented by all loading related classes
    /// </summary>
    public interface ILoad : IObject        
    {
        LoadType GetLoadType();

        /// <summary>Loadcase as BH.oM object</summary>
        BH.oM.Structural.Loads.Loadcase Loadcase { get; set; }

        LoadAxis Axis { get; set; }

        bool Projected { get; set; }
    }
}
