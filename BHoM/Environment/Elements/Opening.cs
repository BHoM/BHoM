using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Elements
{
    public class Opening : BHoMObject, IBuildingObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve OpeningCurve { get; set; } = new PolyCurve();

        /***************************************************/
    }
}
