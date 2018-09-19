using System.Collections.Generic;

using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environment.Properties;

namespace BH.oM.Environment.Elements
{
    public class Panel : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve PanelCurve { get; set; } = new PolyCurve();
        public List<BuildingElementOpening> Openings { get; set; } = new List<BuildingElementOpening>();

        public BuildingPanelProperties PanelProperties { get; set; } = new BuildingPanelProperties();

        /***************************************************/
    }
}
