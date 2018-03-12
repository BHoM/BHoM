using BH.oM.Environmental.Properties;
using BH.oM.Environmental.Interface;
using BH.oM.Base;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environmental.Elements
{
    public class Emitter : BHoMObject, IEquipment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public EmitterProperties EmitterProperties { get; set; } = new EmitterProperties();
        public Level Level { get; set; } = new Level();

        /***************************************************/
    }
}
