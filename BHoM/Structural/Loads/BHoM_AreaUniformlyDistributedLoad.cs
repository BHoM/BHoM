using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Uniformly distributed area load
    /// </summary>
    [Serializable]
    public class AreaUniformalyDistributedLoad : Load
    {
       public BHoM.Geometry.Vector Pressure { get; private set; }
       public AreaUniformalyDistributedLoad(double px, double py, double pz)
        {
            Pressure = new Geometry.Vector(px, py, pz);
        }
        //Perhaps we can have one area load object for all 'area' type objects - panels, walls, floors, finite elements
    }
}
