using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;
using BH.oM.Base;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environment.Elements
{
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public AirHandlingUnitProperties AirHandlingUnitProperties { get; set; } = new AirHandlingUnitProperties();

        /***************************************************/
    }
}
