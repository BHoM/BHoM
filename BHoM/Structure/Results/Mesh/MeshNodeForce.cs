using System;

namespace BH.oM.Structure.Results
{
    public class MeshNodeForce : MeshNodeResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double NXX { get; set; } = 0.0;

        public double NYY { get; set; } = 0.0;

        public double NXY { get; set; } = 0.0;

        public double MXX { get; set; } = 0.0;

        public double MYY { get; set; } = 0.0;

        public double MXY { get; set; } = 0.0;

        public double VX { get; set; } = 0.0;

        public double VY { get; set; } = 0.0;

        /***************************************************/
    }
}
