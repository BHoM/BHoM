using BH.oM.Structural.Properties;
using BH.oM.Base;

namespace BH.oM.Structural.Elements
{
    public interface IAreaElement : IObject
    {
        Property2D Property { get; set; }
    }
}
