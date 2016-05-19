using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Loadcombination, different to loadcase as combination also contains information
    /// on the combinations of loads with load factors
    /// </summary>
    [Serializable]
    public class LoadCombination : BHoMObject, ICase
    {

        //Combination
        public CaseType CaseType
        {
            get
            {
                return CaseType.Combination;
            }
        }

        public int Number
        {
            get; set;
        }
    }
}
