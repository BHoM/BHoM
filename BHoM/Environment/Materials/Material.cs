using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Materials
{
    public class Material : BHoMObject, IMaterial
    {
        public MaterialType MaterialType { get; set; } = MaterialType.Undefined;
        public double Thickness { get; set; } = 0;
        public IMaterialProperties MaterialProperties { get; set; } = null;
    }
}
