using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environmental.Properties;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class ElementOpening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PolyCurve PolyCurve { get; set; } = new PolyCurve();


        /***************************************************/
    }
}
