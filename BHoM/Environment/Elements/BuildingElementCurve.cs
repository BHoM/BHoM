using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Elements
{
    public class BuildingElementCurve : BHoMObject, IBuildingElementGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; } = new Line();

        /***************************************************/
    }
}
