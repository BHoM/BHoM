using BH.oM.Base;
using BH.oM.Common;
using BH.oM.Geometry;
using BH.oM.Structure.Properties.Constraint;

namespace BH.oM.Structure.Elements
{
    /// <summary>
    /// BH.oM edge class to describe the edges of panels (or other objects) by a curve plus properties
    /// </summary>
    public class Edge : BHoMObject, IElement1D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
                
        public ICurve Curve { get; set; }
        public Constraint4DOF Constraint { get; set; } = null;

        
        /***************************************************/
    }
}
       