using BH.oM.Analytical.Elements;
using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    public class LayoutHelperFragment : IFragment
    {
        public virtual List<EntityGroup> EntityGroups { get; set; } = new List<EntityGroup>();
    }
}
