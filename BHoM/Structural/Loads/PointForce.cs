using BH.oM.Geometry;
using BH.oM.Structural.Elements;

namespace BH.oM.Structural.Loads
{
    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public class PointForce : Load<Node> 
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Vector Force { get;  set; }

        public Vector Moment { get;  set; }


        /***************************************************/
    }
}
