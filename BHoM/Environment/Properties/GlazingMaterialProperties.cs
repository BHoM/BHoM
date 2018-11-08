using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class GlazingMaterialProperties : BHoMObject, IMaterialProperties
    {
        public double ThermalConductivity { get; set; } = 0.0;
        public double Thickness { get; set; } = 0.0;
        public double gValue { get; set; } = 0.0;
        public double gValueShading { get; set; } = 0.0;
        public double LtValue { get; set; } = 0.0;
        public bool IsBlind { get; set; } = false;
    }
}
