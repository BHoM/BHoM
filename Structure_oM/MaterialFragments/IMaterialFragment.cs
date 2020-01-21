using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Physical.Materials;
using BH.oM.Base;

namespace BH.oM.Structure.MaterialFragments
{
    public interface IMaterialFragment : IBHoMFragment, IMaterialProperties
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        double Density { get; set; }
        double DampingRatio { get; set; }
        double EmbodiedCarbon { get; set; }

        /***************************************************/
    }
}
