using BH.oM.Base;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;
using BH.oM.Geometry;
using System.Collections.Generic;

namespace BH.oM.Environment.Elements
{
    public class BuildingElement : BHoMObject, IBuildingObject, IElement2D
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public BuildingElementProperties BuildingElementProperties { get; set; } = new BuildingElementProperties();

        public ICurve PanelCurve { get; set; } = new PolyCurve();
        public List<Opening> Openings { get; set; } = new List<Opening>();

        /***************************************************/
    }
}
