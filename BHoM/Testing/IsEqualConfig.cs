using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;

namespace BH.oM.Testing
{
    public class IsEqualConfig : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double NumericTolerance { get; set; } = 1e-6;

        public bool IgnoreGuid { get; set; } = true;

        public bool IgnoreCustomData { get; set; } = true;

        public List<string> PropertiesToIgnore { get; set; } = new List<string>();

        /***************************************************/
    }
}
