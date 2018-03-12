using BH.oM.Environmental.Interface;
using BH.oM.Environmental.Properties;
using BH.oM.Base;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environmental.Elements
{
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public AirHandlingUnitProperties AirHandlingUnitProperties { get; set; } = new AirHandlingUnitProperties();

        public Level Level { get; set; } = new Level();

        /***************************************************/
    }
}
