using System.Collections.Generic;

using BH.oM.Base;
using BH.oM.Geometry;
using BH.oM.Environment.Interface;
using BH.oM.Architecture.Elements;

namespace BH.oM.Environment.Elements
{
    public class Space : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Number { get; set; } = "";
        public Point Location { get; set; } = new Point();

        public List<InternalCondition> InternalConditions { get; set; } = new List<InternalCondition>();
        public double HeatingLoad { get; set; } = 0.0;
        public double CoolingLoad { get; set; } = 0.0;

        /***************************************************/
    }
}
