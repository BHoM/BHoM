using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environmental.Elements;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
using BHEP = BH.oM.Environmental.Properties;

namespace BH.oM.Environmental.Elements
{

    public class BuildingElement : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public int BEType { get; set; } = 0;
        public int Ghost { get; set; } = 0;
        public int Ground { get; set; } = 0;
        public int MarkDelete { get; set; } = 0;
        public double Width { get; set; } = 0.0;
        public BHEP.BuildingElementProperties BEProperties { get; set; } = new BHEP.BuildingElementProperties();

    }

}
