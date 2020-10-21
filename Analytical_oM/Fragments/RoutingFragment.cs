using BH.oM.Analytical.Elements;
using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Analytical.Fragments
{
    public class RoutingFragment : IFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual double? MinCostToSource { get; set; } = null;
        public virtual double? Cost { get; set; } = null;
        public virtual bool Visited { get; set; } = false;
        public virtual Guid NearestToSource { get; set; }
        public virtual double? StraightLineDistanceToTarget { get; set; } = null;
        /***************************************************/
    }
}