using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Planning
{
    public class CodeAssembly : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Repository { get; set; }

        public List<string> References { get; set; }


        /***************************************************/
    }
}
