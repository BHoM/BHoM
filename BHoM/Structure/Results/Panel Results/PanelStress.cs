using System;

namespace BH.oM.Structure.Results
{
    public class PanelStress : PanelResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double SXX { get; set; } = 0.0;

        public double SYY { get; set; } = 0.0;

        public double SXY { get; set; } = 0.0;

        public double TXX { get; set; } = 0.0;

        public double TYY { get; set; } = 0.0;

        /***************************************************/
    }
}
