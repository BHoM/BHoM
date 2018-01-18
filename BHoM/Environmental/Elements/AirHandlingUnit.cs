using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environmental.Interface;
using BH.oM.Environmental.Properties;
using BH.oM.Base;
using BH.oM.Structural.Elements;

namespace BH.oM.Environmental.Elements
{
    public class AirHandlingUnit : BHoMObject, IEquipment
    {
        public AirHandlingUnitProperties AirHandlingUnitProperties;

        public Storey Storey { get; set; } = new Storey();
    }
}
