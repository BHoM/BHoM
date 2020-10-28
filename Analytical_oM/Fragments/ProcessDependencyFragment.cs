using BH.oM.Analytical.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    public class ProcessDependencyFragment : DependencyFragment
    {
        public virtual List<IProcess> Processes { get; set; } = new List<IProcess>();
    }
}
