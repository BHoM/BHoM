using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.Environmental.Interface
{
    public interface IBuildingElementGeometry : IObject
    {
        ICurve Curve { get; }
    }
}
