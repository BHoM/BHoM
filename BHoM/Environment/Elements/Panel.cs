using System.Collections.Generic;

using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Environment.Properties;
using BH.oM.Environment.Interface;

namespace BH.oM.Environment.Elements
{
    public class Panel : BHoMObject, IBuildingObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public ICurve PanelCurve { get; set; } = new PolyCurve();
        public List<Opening> Openings { get; set; } = new List<Opening>();

        public PanelProperties PanelProperties { get; set; } = new PanelProperties();

        /***************************************************/
    }
}
