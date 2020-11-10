using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    [Description("Dependency fragment used to define one or more Relations that terminate at the specified targets and use the IBHoMObject owning this fragment as the source.")]
    public class TargetsDependencyFragment : IDependencyFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("Collection of Guids of entities that are targets for Relations where the IBHoMObject owning this fragment is the source.")]
        public virtual List<Guid> Targets { get; set; }

        [Description("Collection of ICurves used to represent the Relations.")]
        public virtual List<ICurve> Curves { get; set; }

        /***************************************************/
    }
}
