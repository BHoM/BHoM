using System.Collections.Generic;

namespace BH.oM.Base
{
    [Serializable]
    public class BHoMGroup : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<BHoMObject> Elements { get; set; } = new List<BHoMObject>();


        /***************************************************/
    }
}

