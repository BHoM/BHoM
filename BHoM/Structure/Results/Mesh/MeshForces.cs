using System.ComponentModel;
using System.Collections.Generic;

namespace BH.oM.Structure.Results
{
    public class MeshForces : MeshResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<MeshNodeForce> MeshNodeForces { get; set; } 

        /***************************************************/
    }
}
