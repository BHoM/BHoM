using BH.oM.Base;
using BH.oM.Common;
using BH.oM.Environment.Interface;
using BH.oM.Environment.Properties;
using BH.oM.Geometry;
using System.Collections.Generic;

namespace BH.oM.Environment.Elements
{
    public class Panel : BHoMObject, IBuildingObject, IElement2D
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
