using System;
using System.ComponentModel;

namespace BH.oM.Structure.Results
{
    public class MeshNodeStress: MeshNodeResult
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Normal stress in X direction in N/m2")]
        public double SXX { get; set; } = 0.0;

        [Description("Normal stress in Y direction in N/m2")]
        public double SYY { get; set; } = 0.0;

        [Description("Normal stress in XY direction in N/m2")]
        public double SXY { get; set; } = 0.0;

        [Description("Shear stress in X direction in N/m2")]
        public double TXX { get; set; } = 0.0;

        [Description("Shear stress in Y direction in N/m2")]
        public double TYY { get; set; } = 0.0;

        /***************************************************/
    }
}
