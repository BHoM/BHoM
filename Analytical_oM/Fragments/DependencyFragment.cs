using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    public class DependencyFragment : IDependencyFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual Guid Source { get; set; }

        public virtual Guid Target { get; set; }
        /***************************************************/

    }
}
