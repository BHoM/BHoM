using BH.oM.Structural.Properties;
using BH.oM.Base;

namespace BH.oM.Structural.Elements
{
    public interface IAreaElement : IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        Property2D Property { get; set; }


        /***************************************************/
    }
}
