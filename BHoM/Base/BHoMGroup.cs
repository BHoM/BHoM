using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /**** Constructors                              ****/
        /***************************************************/

        public BHoMGroup() { }

        /***************************************************/

        public BHoMGroup(IEnumerable<BHoMObject> elements)
        {
            Elements = elements.ToList();
        }
    }
}

