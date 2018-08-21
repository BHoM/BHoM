﻿using BH.oM.Structure.Properties;
using BH.oM.Geometry;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// BH.oM edge class to describe the edges of panels (or other objects) by a curve plus properties
    /// </summary>
    public class Edge : Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
                
        public ICurve Curve { get; set; }
        public Constraint4DOF Constraint { get; set; } = null;

        
        /***************************************************/
    }
}
       