using System.Collections.Generic;
using System.Linq;


namespace BH.oM.Geometry
{
    public class CompositeGeometry : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMGeometry> Elements = new List<IBHoMGeometry>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CompositeGeometry() { }

        /***************************************************/

        public CompositeGeometry(IEnumerable<IBHoMGeometry> elements)
        {
            Elements = elements.ToList();
        }

    }
}

