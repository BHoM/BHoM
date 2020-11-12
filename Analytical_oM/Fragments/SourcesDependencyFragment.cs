using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    [Description("Dependency fragment used to define one or more Relations that originate at the specified sources and use the IBHoMObject owning this fragment as the target.")]
    public class SourcesDependencyFragment : IDependencyFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Collection of Guids of entities that are sources for Relations where the IBHoMObject owning this fragment is the target.")]
        public virtual List<Guid> Sources { get; set; }

        [Description("Collection of ICurves used to represent the Relations.")]
        public virtual List<ICurve> Curves { get; set; }

        /***************************************************/
    }
}
