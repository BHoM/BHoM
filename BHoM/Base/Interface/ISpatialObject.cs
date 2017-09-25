using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;

namespace BH.oM.Base
{
    public interface ISpatialObject
    {
        IBHoMGeometry Geometry { get; set; }

        Location Location { get; set; }
    }
}
