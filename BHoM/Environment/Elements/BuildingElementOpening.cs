using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Environment.Elements
{
    public class BuildingElementOpening : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Opening { get; set; } = new PolyCurve();

        /***************************************************/
    }
}
