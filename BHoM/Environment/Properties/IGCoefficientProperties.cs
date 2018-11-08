using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class IGCoefficientProperties : BHoMObject
    {
        public double LightingViewCoefficient { get; set; } = 0.49;
        public double OccupantViewCoefficient { get; set; } = 0.227;
        public double EquipmentViewCoefficient { get; set; } = 0.372;
    }
}
