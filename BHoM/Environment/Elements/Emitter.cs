using BH.oM.Environment.Properties;
using BH.oM.Environment.Interface;
using BH.oM.Base;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environment.Elements
{
    public class Emitter : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public EmitterProperties EmitterProperties { get; set; } = new EmitterProperties();
        public EmitterType EmitterType { get; set; } = EmitterType.Heating;

        /***************************************************/
    }
}
