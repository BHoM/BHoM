using BH.oM.Base;
using System.Collections.Generic;

namespace BH.oM.Humans
{
    public class Human : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IHumanRole> Roles { get; set; } = new List<IHumanRole>();        


        /***************************************************/
    }
}



