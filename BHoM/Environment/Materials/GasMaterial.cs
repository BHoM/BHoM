using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Materials
{
    public class GasMaterial : BHoMObject, IMaterial
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Description { get; set; } = string.Empty;
        public IMaterialProperties MaterialProperties { get; set; } = new DefaultMaterialProperties();

        public double ConvectionCoefficient { get; set; } = 0.0;
        public double VapourDiffusionFactor { get; set; } = 0.0;

        /***************************************************/
    }
}
