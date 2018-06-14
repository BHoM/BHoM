using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BH.oM.Planning;
using BH.oM.Base;

namespace BH.oM.Reflection.Testing
{
    public class TestResult : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public MethodBase Method { get; set; } = null;

        public List<bool> Results { get; set; } = new List<bool>();

        public Issue Issue { get; set; } = null;

        /***************************************************/
    }
}
