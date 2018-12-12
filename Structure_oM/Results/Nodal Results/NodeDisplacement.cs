using System;

namespace BH.oM.Structure.Results
{
    public class NodeDisplacement : NodeResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double UX { get; set; } = 0.0;

        public double UY { get; set; } = 0.0;

        public double UZ { get; set; } = 0.0;

        public double RX { get; set; } = 0.0;

        public double RY { get; set; } = 0.0;

        public double RZ { get; set; } = 0.0;

        /***************************************************/
    }
}
