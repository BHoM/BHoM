using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Environmental.Elements
{
    public class BuildingElementOpening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public PolyCurve PolyCurve { get; set; } = new PolyCurve();


        /***************************************************/
    }
}
