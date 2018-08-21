using BH.oM.Structural.Properties;
using BH.oM.Base;

namespace BH.oM.Structural.Elements
{
    public interface IAreaElement : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        IProperty2D Property { get; set; }

        /***************************************************/
    }
}
