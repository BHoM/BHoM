using System.Collections.Generic;


namespace BH.oM.Geometry
{
    [Serializable]
    public class CompositeGeometry : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMGeometry> Elements = new List<IBHoMGeometry>();


        /***************************************************/
    }
}

