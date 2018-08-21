using System;

namespace BH.oM.Structural.Results
{
    public class BarStress : BarResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public double Axial { get; set; } = 0.0;

        public double ShearY { get; set; } = 0.0;

        public double ShearZ { get; set; } = 0.0;

        public double BendingY_Top { get; set; } = 0.0;

        public double BendingY_Bot { get; set; } = 0.0;

        public double BendingZ_Top { get; set; } = 0.0;

        public double BendingZ_Bot { get; set; } = 0.0;

        public double CombAxialBendingPos { get; set; } = 0.0;

        public double CombAxialBendingNeg { get; set; } = 0.0;

        /***************************************************/
    }
}