using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structural.Properties;
using BH.oM.Geometry;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// BH.oM Face class
    /// </summary>
    [Serializable]
    public class Edge : BH.oM.Base.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
                
        public ICurve Curve { get; set; }
        public EdgeConstraint Constraint { get; set; } = null;
        
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        /// <summary>
        /// Constructs an empty panel
        /// </summary>
        public Edge() { }
   
        /***************************************************/   

    }
}
       