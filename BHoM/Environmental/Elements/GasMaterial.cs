using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class GasMaterial : BHoMObject, IMaterial
    {
        public MaterialType MaterialType
        {
            get
            {
                return MaterialType.Gas;
            }
        }
        public double Thickness { get; set; }
        public string Description { get; set; }
        public double ConvectionCoefficient { get; set; }
        public double VapourDiffusionFactor { get; set; }
    }
}
