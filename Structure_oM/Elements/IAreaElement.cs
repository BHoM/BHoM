using BH.oM.Structure.Properties;
using BH.oM.Base;

namespace BH.oM.Structure.Elements
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
