using System.Collections.Generic;
using BH.oM.Base;

namespace BH.oM.Structure.Loads
{

    /// <summary>
    /// Nodal load class. Use NodalLoad() to construct an empty instance, then use the Set methods to set forces, moments etc. A second
    /// constructor allows for a default force and moment nodal load instance.
    /// </summary>
    public abstract class Load<T> : BHoMObject, ILoad where T : IBHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Loadcase Loadcase { get; set; }

        public BHoMGroup<T> Objects { get; set; } = new BHoMGroup<T>();

        public LoadAxis Axis { get; set; } = LoadAxis.Global;

        public bool Projected { get; set; } = false;


        /***************************************************/
    }
}






