using BH.oM.Base;
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    public class SpatialDependencyFragment : DependencyFragment, IDependencyFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual ICurve Curve { get; set; }

        /***************************************************/

    }
}
