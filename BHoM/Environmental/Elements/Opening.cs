using BHG = BH.oM.Geometry;
using BHB = BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;

namespace BH.oM.Environmental.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Opening : BHB.BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BHG.Polyline Polyline { get; set; }

    }

}