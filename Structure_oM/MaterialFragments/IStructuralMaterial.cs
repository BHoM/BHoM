using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Physical.Materials;

namespace BH.oM.Structure.MaterialFragments
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
