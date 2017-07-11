using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Geometry
{
    public interface ICurve : IBHoMGeometry
    {
        Point GetStart();

        Point GetEnd();

        Vector GetStartDir();

        Vector GetEndDir();

        bool IsClosed();  
    }
}
