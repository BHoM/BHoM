﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Global;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public abstract class Load : BHoMObject
    {
        /// <summary>Loadcase as BHoM object</summary>
        public BHoM.Structural.Loads.Loadcase Loadcase { get; set; }

         /// <summary>A list of structural elements numbers that the nodal load is applicable to</summary>
        public ObjectCollection Objects { get; set; }
        
    }
}
