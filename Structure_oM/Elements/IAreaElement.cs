using BH.oM.Structure.Properties.Surface;
using BH.oM.Base;

namespace BH.oM.Structure.Elements
{
    public interface IAreaElement : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        ISurfaceProperty Property { get; set; }

        /***************************************************/
    }
}
