using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;
using BH.oM.Architecture.Elements;
using System.Collections.Generic;
using System;

namespace BH.oM.Environment.Elements
{
    public class BuildingElement : BHoMObject, IBuildingObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BuildingElementProperties BuildingElementProperties { get; set; } = new BuildingElementProperties();
        public IBuildingElementGeometry BuildingElementGeometry { get; set; } = new BuildingElementPanel();

        /***************************************************/
    }
}
