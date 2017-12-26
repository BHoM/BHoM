using System;
using BH.oM.Structural.Properties;
using BH.oM.Geometry;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM edge class to describe the edges of panels (or other objects) by a curve plus properties
    /// </summary>
    [Serializable]
    public class Edge : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve Curve { get; set; }
        public Constraint4DOF Constraint { get; set; } = null;

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Edge() { }

        /***************************************************/

    }
}
