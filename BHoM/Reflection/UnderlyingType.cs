using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Reflection
{
    public class UnderlyingType : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Type Type { get; set; } = null;

        public int Depth { get; set; } = 0;


        /***************************************************/
    }
}
