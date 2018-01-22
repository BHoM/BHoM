using System;

namespace BH.oM.Structural.Results
{
    public class PanelStress : PanelResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double SXX_Top { get; set; } = 0.0;

        public double SYY_Top { get; set; } = 0.0;

        public double SXY_Top { get; set; } = 0.0;

        public double SXX_Bot { get; set; } = 0.0;

        public double SYY_Bot { get; set; } = 0.0;

        public double SXY_Bot { get; set; } = 0.0;

        public double TX { get; set; } = 0.0;

        public double TY { get; set; } = 0.0;

        /***************************************************/
    }
}
