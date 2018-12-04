using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Properties
{
    public class MaterialPropertiesGas : BHoMObject, IMaterialProperties
    {
        public double ThermalConductivity { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public double ConvectionCoefficient { get; set; } = 0.0;
        public double VapourDiffusionFactor { get; set; } = 0.0;
    }
}
