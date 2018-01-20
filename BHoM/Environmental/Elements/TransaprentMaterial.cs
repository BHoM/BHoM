using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class TransparentMaterial : BHoMObject, IMaterial
    {
        public MaterialType MaterialType { get; set; }
        public string Description { get; set; }
        public double Thickness { get; set; }
        public double Conductivity { get; set; }
        public double VapourDiffusionFactor { get; set; }
        public double SolarTransmittance { get; set; }
        public double SolarReflectanceExternal { get; set; }
        public double SolarReflectanceInternal { get; set; }
        public double LightTransmittance { get; set; }
        public double LightReflectanceExternal { get; set; }
        public double LightReflectanceInternal { get; set; }
        public double EmissivityInternal { get; set; }
        public double EmissivityExternal { get; set; }
    }
}
