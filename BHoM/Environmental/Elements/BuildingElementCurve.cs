using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Environmental.Interface;

namespace BH.oM.Environmental.Elements
{
    public class BuildingElementCurve : BHoMObject, IBuildingElementGeometry
    {
        public ICurve Curve { get; set; } = new Line();
    }
}
