using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.Environment.Results
{
    public class ProfileResults : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ProfileResultUnits ResultUnit { get; set; } = ProfileResultUnits.Undefined;
        public ProfileResultsCategory ResultCategory { get; set; } = ProfileResultsCategory.Undefined;
        public ProfileResultType ResultType { get; set; } = ProfileResultType.Undefined;
        public List<double> Results { get; set; } = new List<double>();
    }
}
