using BH.oM.Geometry;
using BH.oM.Structure.Elements;

namespace BH.oM.Structure.Loads
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

        public Vector Force { get;  set; } = new Vector();

        public Vector Moment { get;  set; } = new Vector();


        /***************************************************/
    }
}
