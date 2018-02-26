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
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Thickness { get; set; } = 0.0;
        public string Description { get; set; } = string.Empty;
        public double ConvectionCoefficient { get; set; } = 0.0;
        public double VapourDiffusionFactor { get; set; } = 0.0;

        /***************************************************/
    }
}
