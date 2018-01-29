using System.Collections.Generic;

namespace BH.oM.Base
{
    public class BHoMGroup<T> : BHoMObject where T:IObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<T> Elements { get; set; } = new List<T>();


        /***************************************************/
    }
}

