using BH.oM.Environmental.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class Emitter : Equipment
    {
        public EmitterProperties EmitterProperties { get; set; } = new EmitterProperties();

        public override IEquipmentProperties EquipmentProperties
        {
            get
            {
                return EmitterProperties;
            }

            set
            {
                EmitterProperties = value as EmitterProperties;
            }
        }
    }
}
