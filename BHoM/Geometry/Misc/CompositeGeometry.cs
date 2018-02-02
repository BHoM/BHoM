﻿using System.Collections.Generic;


namespace BH.oM.Geometry
{
    public class CompositeGeometry : IBHoMGeometry
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public List<IBHoMGeometry> Elements { get; set; } = new List<IBHoMGeometry>();


        /***************************************************/
    }
}

