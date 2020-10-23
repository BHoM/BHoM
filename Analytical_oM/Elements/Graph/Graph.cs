using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Elements
{
    public class Graph : BHoMObject
    {
        public virtual Dictionary<Guid, IBHoMObject> Entities { get; set; } = new Dictionary<Guid, IBHoMObject>();

        public virtual List<IRelation> Relations { get; set; } = new List<IRelation>();

    }
}
