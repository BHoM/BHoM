using BH.oM.Base;

namespace BH.oM.Structure.Properties.Constraint
{
    public class LinkConstraint : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public bool XtoX { get; set; } = false;

        public bool YtoY { get; set; } = false;

        public bool ZtoZ { get; set; } = false;


        public bool XtoYY { get; set; } = false;

        public bool XtoZZ { get; set; } = false;

        public bool YtoXX { get; set; } = false;

        public bool YtoZZ { get; set; } = false;

        public bool ZtoXX { get; set; } = false;

        public bool ZtoYY { get; set; } = false;


        public bool XXtoXX { get; set; } = false;

        public bool YYtoYY { get; set; } = false;

        public bool ZZtoZZ { get; set; } = false;


        /***************************************************/
    }
}