using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Physical.Reinforcement
{
    public class ReinforcementFragment : IFragment
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual List<IReinforcingBar> ReinforcingBars { get; set; } = new List<IReinforcingBar>();

        /***************************************************/
    }
}
