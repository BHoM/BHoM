using System.Collections.Generic;

namespace BH.oM.Base
{
    public class BHoMGroup : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<BHoMObject> Elements { get; set; } = new List<BHoMObject>();


        /***************************************************/
    }
}

