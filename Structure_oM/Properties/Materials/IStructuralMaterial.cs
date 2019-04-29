using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Physical.Properties;

namespace BH.oM.Structure.Properties.Materials
{
    public interface IStructuralMaterial : IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        double DampingRatio { get; set; }

        /***************************************************/
    }
}
