using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Environment.Elements;

namespace BH.oM.Environment.Properties
{
    public class BuildingElementProperties : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BuildingElementType BuildingElementType { get; set; } = BuildingElementType.Undefined;
        public List<Construction> Construction { get; set; } = new List<Construction>();

        /***************************************************/
    }
}
