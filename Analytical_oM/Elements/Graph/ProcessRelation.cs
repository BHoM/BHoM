using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class ProcessRelation : Relation, IRelation
    {
        public virtual List<IProcess> Processes { get; set; }

    }
}
