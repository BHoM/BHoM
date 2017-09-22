using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BH.oM.Geometry
{
    public class GeometryGroup : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Dictionary<string, IBHoMGeometry> Elements = new Dictionary<string, IBHoMGeometry>();


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public GeometryGroup() { }

        /***************************************************/

        public GeometryGroup(IEnumerable<IBHoMGeometry> elements)
        {
            Dictionary<string, IBHoMGeometry> geometryGroup = new Dictionary<string, IBHoMGeometry>();
            for (int i = 0; i < elements.Count(); i++)
            {
                geometryGroup.Add(i.ToString(),elements.ElementAt(i));
            }

            Elements = geometryGroup;
        }

    }
}

