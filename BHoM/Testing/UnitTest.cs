using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Testing
{
    public class UnitTest : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public MethodBase Method { get; set; } = null;

        public List<TestData> Data { get; set; } = new List<TestData>();


        /***************************************************/
    }
}
