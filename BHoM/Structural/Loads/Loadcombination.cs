using BH.oM.Base;
using System;
using System.Collections.Generic;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Loadcombination, different to loadcase as combination also contains information
    /// on the combinations of loads with load factors
    /// </summary>
    public class LoadCombination : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Tuple<double, ICase>> LoadCases { get; set; } = new List<Tuple<double, ICase>>();

        public int Number { get; set; } = 0;  // TODO: Do we still need this? Why not use Name or Guid ?


        /***************************************************/
    }
}
