using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public abstract class Load
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; private set; }

         /// <summary>A list of node numbers that the nodal load is applicable to</summary>
        public List<int> ObjectNumbers { get; set; }

        /// <summary>Stores a load record number specific to Robot</summary>
        public int RecordNumber { get; set; }

       

    }
}
