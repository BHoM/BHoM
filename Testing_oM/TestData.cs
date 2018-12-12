using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Testing
{
    public class TestData : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<object> Inputs { get; set; } = new List<object>();

        public object Output { get; set; } = null;


        /***************************************************/
    }
}
