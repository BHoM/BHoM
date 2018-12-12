using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class IGRadiationProperties : BHoMObject
    {
        public double LightingRadiation { get; set; } = 0.3;
        public double OccupantRadiation { get; set; } = 0.2;
        public double EquipmentRadiation { get; set; } = 0.1;
    }
}
