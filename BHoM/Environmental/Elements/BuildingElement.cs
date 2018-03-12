using BH.oM.Base;
using BH.oM.Environmental.Interface;
using BH.oM.Environmental.Properties;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environmental.Elements
{
    public class BuildingElement : BHoMObject, IBuildingObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Level Level { get; set; } = new Level();
        public BuildingElementProperties BuildingElementProperties { get; set; } = new BuildingElementProperties();
        public IBuildingElementGeometry BuildingElementGeometry { get; set; } = new BuildingElementPanel();

        /***************************************************/
    }
}
