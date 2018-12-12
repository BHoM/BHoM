using System.Collections.Generic;

namespace BH.oM.Geometry
{
    public class CompositeGeometry : IGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IGeometry> Elements { get; set; } = new List<IGeometry>();
        
        /***************************************************/
    }
}
