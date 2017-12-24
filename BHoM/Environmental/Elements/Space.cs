using BH.oM.Geometry;
using BH.oM.Base;
using System.Collections.Generic;


namespace BH.oM.Environmental.Elements
{
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<Polyline> Contours { get; set; } = new List<Polyline>();


        /***************************************************/
    }

}