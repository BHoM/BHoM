using BHoM.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Point load along a bar
    /// </summary>
    public class BarPointLoad : BHoMObject, ILoad<Bar>
    {
        /// <summary>
        /// Loadcase of load
        /// </summary>
        public Loadcase Loadcase { get; set; }

        /// <summary>
        ///  Bars which have been assigned with this loading value
        /// </summary>
        public List<Bar> Objects { get; set; }

        internal BarPointLoad() { }
        //Bar point load object - different to nodal or point load as it needs a 'position' variable
    }

    /// <summary>
    /// Uniform load on bar
    /// </summary>
    public class BarUniformlyDistributedLoad : BHoMObject, ILoad<Bar>
    {
        /// <summary>
        /// Loadcase of load
        /// </summary>
        public Loadcase Loadcase { get; set; }

        /// <summary>
        ///  Bars which have been assigned with this loading value
        /// </summary>
        public List<Bar> Objects { get; set; }
        //Bar uniformly distributed load. This should include ability to define uniformly distributed moments. 

        internal BarUniformlyDistributedLoad() { }

    }

    /// <summary>
    /// bar temperature load class
    /// </summary>
    public class BarTemperatureLoad : BHoMObject, ILoad<Bar>
    {
        /// <summary>
        /// Loadcase of load
        /// </summary>
        public Loadcase Loadcase { get; set; }

        /// <summary>
        ///  Bars which have been assigned with this loading value
        /// </summary>
        public List<Bar> Objects { get; set; }
    
        internal BarTemperatureLoad() { }
        //Bar temp load object. Expansion in XYZ
    }

    /// <summary>
    /// Varying load on a bar
    /// </summary>
    public class BarVaryingDistributedLoad : BHoMObject, ILoad<Bar>
    {
        /// <summary>
        /// Loadcase of load
        /// </summary>
        public Loadcase Loadcase { get; set; }

        /// <summary>
        ///  Bars which have been assigned with this loading value
        /// </summary>
        public List<Bar> Objects { get; set; }
    
        internal BarVaryingDistributedLoad() { }
        //patch load for bars. Should include patch moments. 
    }
}
